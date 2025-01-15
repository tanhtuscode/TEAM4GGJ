using UnityEngine;
using System.Collections.Generic;
using System;

[System.Serializable]
public enum AudioChannel
{
    Ambient,
    Music,
    SoundFX,
}

public class Audio
{
    [SerializeField] private AudioClip clip;
    [SerializeField] private AudioChannel channel = AudioChannel.SoundFX;
    [SerializeField, Range(0f, 1f)] private float volume = 1f;
    [SerializeField] private bool loop = true;
    [SerializeField] private float delay = 0;

    public bool IsEmpty => Clip == null;
    public AudioClip Clip => clip;
    public AudioChannel Channel => channel;
    public float Volume => volume;
    public bool Loop => loop;
    public float Delay => delay;

    public void Play()
    {
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.Play(this);
        }
    }
}