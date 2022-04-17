using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusicPicker : MonoBehaviour
{
    public AudioManager audioManager;
    public GameObject insanity;
    public bool insane;

    // Start is called before the first frame update
    void Start()
    {
        MusicPicker(Random.Range(0, 2));
    }

    // Update is called once per frame
    void Update()
    {
        if (insanity.activeInHierarchy == true && insane == false)
        {
            audioManager.Pause("gameplay song 1");
            audioManager.Pause("gameplay song 2");
            audioManager.Play("freezer");
            insane = true;
        }
        else if (insanity.activeInHierarchy == false && insane == true)
        {
            audioManager.UnPause("gameplay song 1");
            audioManager.UnPause("gameplay song 2");
            audioManager.Pause("freezer");
            insane = false;
        }
    }

    public void MusicPicker(int musicID)
    {
        switch (musicID)
        {
            case 0:
                audioManager.Play("gameplay song 1");
                break;
            case 1:
                audioManager.Play("gameplay song 2");
                break;
            default:
                break;
        }
    }

}
