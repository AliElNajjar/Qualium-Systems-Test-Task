using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseControl : MonoBehaviour
{
    public static bool gameIsPaused;

    public void TogglePause()
    {
        if (gameIsPaused)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }

    void PauseGame()
    {
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    void ResumeGame()
    {
        Time.timeScale = 1;
        gameIsPaused = false;
    }
}
