using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject OptionsMenu;
    public GameObject GameOverMenu;
    public GameObject HowToMenu;
    public GameObject LevelMenu;
    public AudioMixer MasterVolume;
    public void QuitButtonPress()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
    public void PlayButtonPress()
    {
        MainMenu.SetActive(false);
        OptionsMenu.SetActive(false);
        GameOverMenu.SetActive(false);
        HowToMenu.SetActive(false);
        LevelMenu.SetActive(true);
        Debug.Log("Levels");
        //SceneManager.LoadScene(1); //loads game when pressed
        Debug.Log("Play");
    }

    public void BackButtonPress()
    {
        MainMenu.SetActive(true);
        OptionsMenu.SetActive(false);
        GameOverMenu.SetActive(false);
        HowToMenu.SetActive(false);
        LevelMenu.SetActive(false);
        Debug.Log("Back");
    }

    public void OptionsButtonPress()
    {
        MainMenu.SetActive(false);
        OptionsMenu.SetActive(true);
        Debug.Log("Options");
    }

    public void HowToButtonPress()
    {
        MainMenu.SetActive(false);
        OptionsMenu.SetActive(false);
        HowToMenu.SetActive(true);
        LevelMenu.SetActive(false);
        Debug.Log("How To");
    }
    public void GameOverBackButtonPress()
    {
        SceneManager.LoadScene(0);
    }

    public void SetVolume(float volume)
    {
        MasterVolume.SetFloat("MasterVolume", volume);
        //Debug.Log(volume);
    }

    public void LevelOneButtonPress()
    {
        SceneManager.LoadScene(1);
    }
    public void LevelTwoButtonPress()
    {
        SceneManager.LoadScene(2);
    }
    public void LevelThirdButtonPress()
    {
        SceneManager.LoadScene(3);
    }
}
