using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject OptionsMenu;
    public GameObject GameOverMenu;
    public GameObject HowToMenu;
    public AudioMixer MasterVolume;
    public void QuitButtonPress()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
    public void PlayButtonPress()
    {
        SceneManager.LoadScene(1); //loads game when pressed
        Debug.Log("Play");
    }

    public void BackButtonPress()
    {
        MainMenu.SetActive(true);
        OptionsMenu.SetActive(false);
        GameOverMenu.SetActive(false);
        HowToMenu.SetActive(false);
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
        Debug.Log("How To");
    }
    public void SetVolume(float volume)
    {
        MasterVolume.SetFloat("MasterVolume", volume);
        //Debug.Log(volume);
    }
}
