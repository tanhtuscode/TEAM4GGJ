using UnityEngine;

public class ButtonEvent : MonoBehaviour
{
    [SerializeField] private GameObject cvSettings;

    public void Play()
    {
        UIManager.Instance.PlayButtonEvent();
    }

    public void Settings()
    {
        cvSettings.SetActive(true);
    }
    
    public void Exit()
    {
        UIManager.Instance.ExitButtonEvent();
    }
}
