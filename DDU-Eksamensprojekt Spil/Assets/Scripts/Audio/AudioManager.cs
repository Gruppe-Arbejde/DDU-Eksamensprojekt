using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{

    public Sound[] sounds;

    public static AudioManager instance;

    //Awake is called before Start() 
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject); //so audio doesn't get cut off

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>(); //s is the sound we are currently looking at is equal to the component we are inspecting 
            s.source.clip = s.clip; //source of clip what clip is used

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.spatialBlend = s.spatialBlend;
            s.source.reverbZoneMix = s.reverbZoneMix;
            s.source.priority = s.priority;
        }
    }
    public void Play(string name) //play function to play the specified clip depending on the name
    {
        Sound s = Array.Find(sounds, s => s.name == name); //finds where in the array an object with specified name is at and sets it to the value of sound s
        if (s == null) //if you made a typo and spelt the name wrong
        {
            Debug.Log($"Wrong name dumbo, you inputted this name: {name}");
            return;
        }
        s.source.Play();
        Debug.Log(name + " played");
    }

    public void Stop(string name) //stop function to stop the specified clip depending on the name
    {
        Sound s = Array.Find(sounds, s => s.name == name); //finds where in the array an object with specified name is at and sets it to the value of sound s
        if (s == null) //if you made a typo and spelt the name wrong
        {
            Debug.Log($"Wrong name dumbo, you inputted this name: {name}");
            return;
        }
        s.source.Stop();
    }
    public void Pause(string name) //stop function to stop the specified clip depending on the name
    {
        Sound s = Array.Find(sounds, s => s.name == name); //finds where in the array an object with specified name is at and sets it to the value of sound s
        if (s == null) //if you made a typo and spelt the name wrong
        {
            Debug.Log($"Wrong name dumbo, you inputted this name: {name}");
            return;
        }
        s.source.Pause();
    }

    public void UnPause(string name) //stop function to stop the specified clip depending on the name
    {
        Sound s = Array.Find(sounds, s => s.name == name); //finds where in the array an object with specified name is at and sets it to the value of sound s
        if (s == null) //if you made a typo and spelt the name wrong
        {
            Debug.Log($"Wrong name dumbo, you inputted this name: {name}");
            return;
        }
        s.source.UnPause();
    }
}
