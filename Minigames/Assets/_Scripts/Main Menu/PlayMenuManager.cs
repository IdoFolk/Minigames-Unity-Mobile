using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayMenuManager : MonoBehaviour
{
    [SerializeField] GameObject MainMenu;
    public void PlayTankBattle()
    {
        SceneManager.LoadSceneAsync(2);
    }
    public void PlayFlappyBirdGame()
    {
        SceneManager.LoadSceneAsync(3);
    }
    public void PlayCaptureThePackagesGame()
    {
        SceneManager.LoadSceneAsync(4);
    }
    public void PlayTagGame()
    {
        SceneManager.LoadSceneAsync(5);
    }
    public void BackButton()
    {
        gameObject.SetActive(false);
        MainMenu.gameObject.SetActive(true);
    }
    public void PlayTournament()
    {
        int rand = Random.Range(2, 6);
        SceneManager.LoadSceneAsync(rand);
    }
}
