using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PausePanelController : MonoBehaviour
{
    [SerializeField] GameObject pausePanel;
    bool isPaused => Time.timeScale == 0;
    
    public void TogglePauseMenu()
    {
        pausePanel.SetActive(!isPaused);
        Time.timeScale = isPaused ? 1 : 0;
    }
    public void ReloadCurrentScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        Time.timeScale = 1;
        SceneManager.LoadScene(currentScene.name);

    }
    public void LoadNextLevel()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        Debug.Log(SceneManager.sceneCountInBuildSettings);
        if ((currentScene.buildIndex + 1) <= SceneManager.sceneCountInBuildSettings - 1)
        {
            SceneManager.LoadScene(currentScene.buildIndex + 1);
        }
        else
        {
            GoToMainMenu();
        }
    }
    public void GoToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenuScene");
    }
}
