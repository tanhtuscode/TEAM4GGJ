using UnityEngine;
using NaughtyAttributes;
using Hajime.Audios;
public class Test : MonoBehaviour
{
    public Audio _audio;

    [Button]
    public void Play()
    {
        _audio.Play();
    }
}