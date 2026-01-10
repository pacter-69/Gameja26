using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void ShowPanel(GameObject panel)
    {
        if (panel.activeInHierarchy)
        {
            panel.SetActive(false);
        }
        else
        {
            panel.SetActive(true);
        }
    }
}
