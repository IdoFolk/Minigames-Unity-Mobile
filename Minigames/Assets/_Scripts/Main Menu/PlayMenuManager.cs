using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayMenuManager : MonoBehaviour
{
    public void PlayTankBattle()
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
    public void PlayTagGame()
    {
        SceneManager.LoadScene(4);
    }
    public void PlayTournament()
    {
        int rand = Random.Range(1, 5);
        SceneManager.LoadScene(rand);
    }
}
