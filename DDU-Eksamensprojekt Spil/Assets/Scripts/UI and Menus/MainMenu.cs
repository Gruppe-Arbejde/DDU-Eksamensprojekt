using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }

    public void SetQuality()
    {
        ChangeScreenRes();
    }

    public void GameOverBackButtonPress()
    {
        SceneManager.LoadScene(0);
    }
    public void GameOverPlayButtonPress()
    {
        SceneManager.LoadScene(1);
    }

    void ChangeScreenRes()
    {
        // Getting the name of what button we've pressed
        string index = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;

        switch (index)
        {
            case "0":
                Screen.SetResolution(1152, 648, true);
                Debug.Log($"{Screen.currentResolution}");
                break;
            case "1":
                Screen.SetResolution(1280, 768, true);
                Debug.Log($"{Screen.currentResolution}");
                break;
            case "2":
                Screen.SetResolution(1360, 796, true);
                Debug.Log($"{Screen.currentResolution}");
                break;
            case "3":
                Screen.SetResolution(1920, 1080, true);
                Debug.Log($"{Screen.currentResolution}");
                break;

        }

    }



}