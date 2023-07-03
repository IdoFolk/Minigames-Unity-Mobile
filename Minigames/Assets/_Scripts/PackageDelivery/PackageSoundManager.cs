using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PackageSoundManager : MonoBehaviour
{
    [Header("Audio Source")]
    public AudioSource MainMusic;
    public AudioSource Sfx;
    [Header("Audio Clips")]
    public AudioClip PickUpSFX;
    public AudioClip BringToBaseSFX;
    public AudioClip CollisionSFX;
    public AudioClip LaunchRocket;
    public AudioClip WinningMusic;

    public static PackageSoundManager Instance;

    private void Start()
    {
        Instance = this;
    }
    // Update is called once per frame
    void Update()
    {

    }
}
