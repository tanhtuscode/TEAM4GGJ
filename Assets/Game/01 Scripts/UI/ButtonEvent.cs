using UnityEngine;

public class ButtonEvent : MonoBehaviour
{
    [SerializeField] private GameObject cvSettings;

    
    
    public void Play(int indexScene)
    {
        SoundEffect();
        UIManager.Instance.PlayButtonEvent(indexScene);
    }

    public void Settings()
    {
        cvSettings.SetActive(true);
        SoundEffect();
    }
    
    public void Exit()
    {
        UIManager.Instance.ExitButtonEvent();
        SoundEffect();
    }

    private void SoundEffect()
    {
        SoundManager.Instance.PlaySound(ETypeSound.MOUSE_CLICK_BUTTON);
    }
}
