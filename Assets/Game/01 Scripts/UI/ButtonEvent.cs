using UnityEngine;

public class ButtonEvent : MonoBehaviour
{
    [SerializeField] private GameObject cvSettings;

    public void Play(int indexScene)
    {
        UIManager.Instance.PlayButtonEvent(indexScene);
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
