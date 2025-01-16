using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;

namespace Hajime.Audios
{
    public class AudioManager : SingletonAutoCreate<AudioManager>
    {
        #region Auto Create Instance
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
        private static void AutoCreateInstance() { var _ = Instance; }
        #endregion

        private AudioSource soundFXSource, musicSource, ambientSource;

        #region Public Properties
        public bool HasInitialized { get; private set; }
        #endregion

        protected override void OnAwake()
        {
            base.OnAwake();
            Initialize();
        }

        private void Initialize()
        {
            if (HasInitialized) return;

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
            Debug.Log("[AudioManager] Initialized");
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
}