using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayMenuManager : MonoBehaviour
{
    public void PlaySpaceshipGame()
    {
        SceneManager.LoadScene(1);
    }
    public void PlayFlappyBirdGame()
    {
        SceneManager.LoadScene(2);
    }
    public void PlayCaptureThePackagesGame()
    {
        SceneManager.LoadScene(3);
    }
    public void PlayRandomGame()
    {
        int rand = Random.Range(1, 4);
        SceneManager.LoadScene(rand);
    }
}
