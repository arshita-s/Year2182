using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
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
        SceneManager.LoadScene(0);
    }

    public void pauseScene()
    {
        SceneManager.LoadScene(2);
    }
}
