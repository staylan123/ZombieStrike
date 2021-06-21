using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public GameObject gameOverCanvas;

    private void Start()
    {
        gameOverCanvas.SetActive(false);  //set end screen to false.
        Time.timeScale = 1; // run time keeps going.
    }

    // Update is called once per frame
    public void GameOver()
    {
        gameOverCanvas.SetActive(true);  //set end screen to true.
        Time.timeScale = 0; // time freezes.
    }
    
     public void Replay()
    {
        SceneManager.LoadScene("PlayGame"); // allow replay on the main screen.
        Score.scoreValue = 0;
    }
     
     public void Back()
    {
        SceneManager.LoadScene("MainMenu");
    }

        public void Quit()
    {
        Application.Quit();
        Debug.Log("QUITTING");
    }
}
