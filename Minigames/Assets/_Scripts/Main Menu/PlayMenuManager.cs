using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayMenuManager : MonoBehaviour
{
    public void PlayTankBattle()
    {
        SceneManager.LoadSceneAsync(1);
    }
    public void PlayFlappyBirdGame()
    {
        SceneManager.LoadSceneAsync(2);
    }
    public void PlayCaptureThePackagesGame()
    {
        SceneManager.LoadSceneAsync(3);
    }
    public void PlayTagGame()
    {
        SceneManager.LoadSceneAsync(4);
    }
    public void PlayTournament()
    {
        int rand = Random.Range(1, 5);
        SceneManager.LoadSceneAsync(rand);
    }
}
