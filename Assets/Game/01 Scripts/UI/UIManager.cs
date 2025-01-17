using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : Singleton<UIManager>
{
    public void PlayButtonEvent(int indexScene)
    {
        SceneManager.LoadScene(indexScene);
    }
    
    public void ExitButtonEvent()
    {
        Application.Quit();
    }
}
