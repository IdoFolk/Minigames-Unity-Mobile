using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

[System.Serializable]
public class Sound
{

    public AudioClip clip;
    [HideInInspector] public AudioSource source;

    public string name;
    [Range(0f,1f)]
    public float volume;
    [Range (.1f,3f)]
    public float pitch;

}
