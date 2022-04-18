using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public Animation anim;

    // Update is called once per frame
    void Update()
    {
        // We want to use ESC key to enable the pause menu. So we check to see if ESC key is pressed, before we continue.
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // if the game is already paused and we press escape again, then we'll want to "quit" pause menu and resume our game
            if (GameIsPaused)
            {
                Resume();
            }
            // otherwise we'll just pause
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        // We set the time back to normal, while also disabling the pause menu overlay
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    void Pause()
    {
        // We change the ingame speed to 0, while also enabling the pause menu overlay
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        // we change to time back to normal, while also loading the scene before us. i.e. Main Menu
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void QuitGame()
    {
        // We just quit the game.
        Application.Quit();
        Debug.Log("Quitting Game...");
    }
}
