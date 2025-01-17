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
        _sliderVolume.value = UIDataManager.Instance.Volume;
    }

    public void OnCloseUISetting()
    {
        _UISetting.SetActive(false);
    }

    public void OnVolumeChangeValue()
    {
        UIDataManager.Instance.Volume = _sliderVolume.value;
        _txtVolume.text = (int)(_sliderVolume.value * 100) + " %";
    }
    
}
