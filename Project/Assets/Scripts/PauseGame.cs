using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject pauseMenu;

    // Update is called once per frame
    void Update()
    {
        if(isPaused)
        {
            Pause();
        }
        else
        {
            Resume();
        }
    }

    void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }
}
