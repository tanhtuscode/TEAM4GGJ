using UnityEngine;

/// <summary>
/// Generic singleton base class for MonoBehaviour-based managers.
/// 
/// Usage:
/// 1. Create your manager class inheriting from this base:
///    public class MyManager : SingletonBehaviour<MyManager> { }
/// 
/// 2. Create a prefab for your manager and add the manager component to it
/// 
/// 3. Place the prefab in a Resources folder (Assets/Resources/MyManager)
///    The prefab name must match exactly with the manager class name
/// 
/// 4. Access your manager from anywhere using:
///    MyManager.Instance.YourMethod();
/// 
/// Features:
/// - Automatic instance creation on first access
/// - DontDestroyOnLoad support
/// - Prefab-based instantiation
/// - Automatic cleanup on application quit
/// 
/// Example:
/// public class GameManager : SingletonBehaviour<GameManager> 
/// {
///     public void Initialize() { }
///     
///     private void Start()
///     {
///         // Your initialization code
///     }
/// }
/// 
/// // In other scripts:
/// GameManager.Instance.Initialize();
/// </summary>
public abstract class SingletonLoadResource<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;

    /// <summary>
    /// Global access point for the singleton instance.
    /// Will automatically create the instance if it doesn't exist.
    /// </summary>
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                AutoCreateInstance();
            }
            return instance;
        }
        protected set => instance = value;
    }

    /// <summary>
    /// Automatically creates an instance of the manager by loading its prefab from Resources.
    /// Called when Instance is accessed for the first time if no instance exists.
    /// The prefab must be located in a Resources folder and named exactly like the manager class.
    /// </summary>
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void AutoCreateInstance()
    {
        if (instance != null) return;

        // Get the resource path from the class name
        string resourcePath = typeof(T).Name;
        GameObject prefab = Resources.Load<GameObject>(resourcePath);

        if (prefab != null)
        {
            // Instantiate the prefab and set up the singleton
            GameObject go = Instantiate(prefab);
            go.name = $"{typeof(T).Name} (Singleton)";

            instance = go.GetComponent<T>();
            if (instance == null)
            {
                Debug.LogError($"Prefab {resourcePath} does not have component {typeof(T).Name}");
                Destroy(go);
                return;
            }

            // Prevent the instance from being destroyed when loading new scenes
            DontDestroyOnLoad(go);

        }
        else
        {
            Debug.LogWarning($"Could not find prefab {resourcePath} in Resources folder");
        }
    }

    /// <summary>
    /// Cleanup when the application quits.
    /// Can be overridden in derived classes, but make sure to call base.OnApplicationQuit()
    /// </summary>
    protected virtual void OnApplicationQuit()
    {
        instance = null;
    }

    public virtual void Initialize()
    {

    }
}