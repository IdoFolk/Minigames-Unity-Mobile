using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PackageSoundManager : MonoBehaviour
{
    public AudioSource MainMusic;
    public AudioSource PickUpSound;
    public AudioSource ReturnToBaseSound;
    public AudioSource CollisionSound;

    public static PackageSoundManager Instance;
    
    
    // Update is called once per frame
    void Update()
    {

    }
}
