using System;
using UnityEngine;
using UnityEngine.UI;

public class SettingManager : MonoBehaviour
{
    [SerializeField] private Text _txtVolume;
    [SerializeField] private Slider _sliderVolume;
    [SerializeField] private GameObject _UISetting;

    private void Start()
    {
        _sliderVolume.value = SoundManager.Instance.Volume;
    }

    public void OnCloseUISetting()
    {
        _UISetting.SetActive(false);
        SoundManager.Instance.PlaySound(ETypeSound.MOUSE_CLICK_BUTTON);
    }

    public void OnVolumeChangeValue()
    {
        SoundManager.Instance.SetVolume(_sliderVolume.value);
        _txtVolume.text = (int)(_sliderVolume.value * 100) + " %";
    }
    
}
