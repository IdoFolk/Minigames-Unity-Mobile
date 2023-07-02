using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayMenuManager : MonoBehaviour
{
    [SerializeField] GameObject MainMenu;
    public void PlayTankBattle()
    {
        AnalyticsEvents.CreateEvent(AnalyticsEventTypes.whichGameWasPicked, MiniGameName: "Tank Game");
        SceneManager.LoadSceneAsync(2);
    }
    public void PlayFlappyBirdGame()
    {
        AnalyticsEvents.CreateEvent(AnalyticsEventTypes.whichGameWasPicked, MiniGameName: "Flappy Bird");
        SceneManager.LoadSceneAsync(3);
    }
    public void PlayCaptureThePackagesGame()
    {
        AnalyticsEvents.CreateEvent(AnalyticsEventTypes.whichGameWasPicked, MiniGameName: "Capture the Pacakges");
        SceneManager.LoadSceneAsync(4);
    }
    public void PlayTagGame()
    {
        AnalyticsEvents.CreateEvent(AnalyticsEventTypes.whichGameWasPicked, MiniGameName: "Tag Game");
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
