using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;

    [Range(0f, 1f)] //sliders for simplicity
    public float volume;
    [Range(0f, 1f)] //sliders for simplicity
    public float pitch;
    [Range(0f, 1f)] //sliders for simplicity
    public float spatialBlend;
    [Range(0f, 1.1f)] //sliders for simplicity
    public float reverbZoneMix;
    [Range(0, 256)] //sliders for simplicity
    public int priority;

    public bool loop;

    [HideInInspector] //value we populate ourselves so we hide it from the editor
    public AudioSource source;
}
