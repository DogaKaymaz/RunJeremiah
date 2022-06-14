using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagement : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(sceneBuildIndex: 1);
    }

    public void PlaySameLevel(int scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(sceneBuildIndex: 0);
    }

    public void SettingsPage()
    {
        Debug.Log("Setting Page Opened");
    }

    public void LoadGamePage()
    {
        Debug.Log("Load Page Opened");
    }
    
    
}
