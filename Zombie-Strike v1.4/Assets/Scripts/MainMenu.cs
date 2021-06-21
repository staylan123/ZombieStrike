using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("PlayGame");
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("QUITTING");
    }
    public void Settings()
    {
        SceneManager.LoadScene("Settings");
    }
    public void Credits()
    {
        SceneManager.LoadScene("About");
    }
    public void Back()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
