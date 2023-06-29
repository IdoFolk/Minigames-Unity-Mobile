using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayMenuManager : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;
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
    public void BackButton()
    {
        gameObject.SetActive(false);
        mainMenu.gameObject.SetActive(true);
    }
}
