using UnityEngine;
using UnityEngine.XR;

public class AudioManager : SingletonLoadResource<AudioManager>
{
    private AudioSource soundFXSource;
    private AudioSource musicSource;
    private AudioSource ambientSource;

    public bool HasInitialized { get; private set; }
    public override void Initialize()
    {
        base.Initialize();

        // InitializeAudioSources()
        soundFXSource = this.gameObject.AddComponent<AudioSource>();
        soundFXSource.playOnAwake = false;
        soundFXSource.loop = false;

        musicSource = this.gameObject.AddComponent<AudioSource>();
        musicSource.playOnAwake = false;
        musicSource.loop = true;

        ambientSource = this.gameObject.AddComponent<AudioSource>();
        ambientSource.playOnAwake = false;
        ambientSource.loop = true;

        HasInitialized = true;
    }

    public void Play(Audio audio)
    {
        if (audio.IsEmpty)
        {
            Debug.LogWarning("Audio is empty");
            return;
        }

        HandleAudioSource(audio);

    }

    private void HandleAudioSource(Audio audio)
    {
        switch (audio.Channel)
        {
            case AudioChannel.Ambient:
                PlayAudio(ambientSource, audio);
                break;
            case AudioChannel.Music:
                PlayAudio(musicSource, audio);
                break;
            case AudioChannel.SoundFX:
                PlayAudio(soundFXSource, audio);
                break;
        }
    }

    private void PlayAudio(AudioSource source, Audio audio)
    {
        source.clip = audio.Clip;
        source.volume = audio.Volume;
        source.loop = audio.Loop;
        source.PlayDelayed(audio.Delay);
    }
}