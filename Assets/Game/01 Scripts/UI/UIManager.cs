using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : Singleton<UIManager>
{
    public void PlayButtonEvent()
    {
        SceneManager.LoadScene(1);
    }
    
    public void ExitButtonEvent()
    {
        Application.Quit();
    }
}
