using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayMenuManager : MonoBehaviour
{
    [SerializeField] GameObject MainMenu;
    public void PlayTankBattle()
    {
        AnalyticsEvents.instance.WhichGameWasPicked("whichGameWasPicked", "Tank Battles");
        SceneManager.LoadSceneAsync(2);
    }
    public void PlayFlappyBirdGame()
    {
        AnalyticsEvents.instance.WhichGameWasPicked("whichGameWasPicked", "Flappy Bird");
        SceneManager.LoadSceneAsync(3);
    }
    public void PlayCaptureThePackagesGame()
    {
        AnalyticsEvents.instance.WhichGameWasPicked("whichGameWasPicked", "Package Game");
        SceneManager.LoadSceneAsync(4);
    }
    public void PlayTagGame()
    {
        AnalyticsEvents.instance.WhichGameWasPicked("whichGameWasPicked", "Tag Game");
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
