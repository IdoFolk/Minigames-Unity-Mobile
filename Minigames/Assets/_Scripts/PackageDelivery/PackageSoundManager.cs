using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PackageSoundManager : MonoBehaviour
{
    [SerializeField] AudioSource MainMusic;
    [SerializeField] AudioSource PickUpSound;
    [SerializeField] AudioSource ReturnToBaseSound;
    [SerializeField] AudioSource LaunchRocketSound;
    [SerializeField] AudioSource CollisionSound;
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
