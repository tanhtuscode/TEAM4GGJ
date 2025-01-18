using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


[Serializable]
public struct SoundList
{
    [HideInInspector] public string name;
    [SerializeField] private AudioClip audioClip;
    public AudioClip Clip
    {
        get => audioClip;
    }
}
[ExecuteInEditMode, RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    private static SoundManager _instance;

    public static SoundManager Instance => _instance;
        
    private AudioSource _audioSource;

    private void Awake()
    {
        _instance = this;
        _audioSource = GetComponent<AudioSource>();
    }

    public float Volume { get; set; } = 1;
    [SerializeField] private GameObject audioPref;
    [SerializeField] private SoundList[] soundLists;
    
    [SerializeField] private AudioClip[] clipsBG;
    private Queue<GameObject> soundQueue = new Queue<GameObject>();

    private void Start()
    {
        if (Application.isPlaying)
        {
            if (SceneManager.GetActiveScene().buildIndex == 0)
            {
                _audioSource.clip = clipsBG[0];
            }
            else
            {
                _audioSource.clip = clipsBG[1];
            }
        
            _audioSource.Play();
        }
    }

#if UNITY_EDITOR
    private void OnEnable()
    {
        string[] names = Enum.GetNames(typeof(ETypeSound));
        Array.Resize(ref soundLists, names.Length);
        for (int i = 0; i < soundLists.Length; i++)
        {
            soundLists[i].name = names[i];
        }
    }
#endif

    private IEnumerator DisableAfterPlaySound(GameObject go, ETypeSound sound)
    {
        var audioSource = go.GetComponent<AudioSource>();
        audioSource.volume = Volume;
        audioSource.PlayOneShot(soundLists[(int)sound].Clip);
        yield return new WaitWhile(() => audioSource.isPlaying);
        go.gameObject.SetActive(false);
        soundQueue.Enqueue(go);
    }
    
    public void PlaySound(ETypeSound sound)
    {
        if (soundQueue.Count > 0)
        {
            GameObject go = soundQueue.Dequeue();
            go.SetActive(true);
            StartCoroutine(DisableAfterPlaySound(go, sound));
        }
        else
        {
            GameObject go = Instantiate(audioPref, transform.position, Quaternion.identity);
            StartCoroutine(DisableAfterPlaySound(go, sound));
        }
    }
}
