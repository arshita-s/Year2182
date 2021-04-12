using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    PlayerMovement player;
    scoreField scoring;

    public void playGame()
    { 
        SceneManager.LoadScene(1);
    }

    public void quitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }

    public void quitMainMenu()
    {
        PauseGame.isPaused = false;
        SceneManager.LoadScene(0);
    }

    public void pauseScene()
    {
        PauseGame.isPaused = true;

    }

    public void ResumeGame()
    {
        PauseGame.isPaused = false;
    }
}
