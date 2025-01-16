using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public abstract class SingletonAutoCreate<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;
    private static bool applicationIsQuitting = false;

    public static T Instance
    {
        get
        {
            if (applicationIsQuitting)
            {
                Debug.LogWarning($"[Singleton] Instance '{typeof(T)}' đã bị hủy khi thoát game. Sẽ không tạo mới.");
                return null;
            }

            if (instance == null)
            {
                instance = FindObjectOfType<T>();

                if (instance == null)
                {
                    GameObject singleton = new GameObject();
                    instance = singleton.AddComponent<T>();
                    singleton.name = $"[Singleton] {typeof(T)}";

                    DontDestroyOnLoad(singleton);

                    Debug.Log($"[Singleton] Tạo instance mới của {typeof(T)}");
                }
                else
                {
                    Debug.Log($"[Singleton] Sử dụng instance có sẵn của {typeof(T)}");
                    DontDestroyOnLoad(instance.gameObject);
                }
            }

            return instance;
        }
    }

    protected virtual void OnEnable()
    {
        if (instance == null)
        {
            instance = this as T;
            DontDestroyOnLoad(gameObject);
        }
    }

    protected virtual void Awake()
    {
        if (instance == null)
        {
            instance = this as T;
            DontDestroyOnLoad(gameObject);
            OnAwake();
        }
        else if (instance != this)
        {
            Destroy(gameObject);
            Debug.LogWarning($"[Singleton] Đã hủy bản sao của {typeof(T)}");
        }
    }

    protected virtual void OnAwake() { }

    protected virtual void OnApplicationQuit()
    {
        applicationIsQuitting = true;
    }
}
