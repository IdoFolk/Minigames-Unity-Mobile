using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayMenuManager : MonoBehaviour
{
    [SerializeField] GameObject MainMenu;
    public void PlayTankBattle()
    {
        AnalyticsEvents.instance.CreateCustomEvent(AnalyticsEventTypes.whichGameWasPicked, null, 0, "Tank Game");
        SceneManager.LoadSceneAsync(2);
    }
    public void PlayFlappyBirdGame()
    {
        AnalyticsEvents.instance.CreateCustomEvent(AnalyticsEventTypes.whichGameWasPicked, null, 0, "Flappy Bird");
        SceneManager.LoadSceneAsync(3);
    }
    public void PlayCaptureThePackagesGame()
    {
        AnalyticsEvents.instance.CreateCustomEvent(AnalyticsEventTypes.whichGameWasPicked, null, 0, "Capture the Pacakges");
        SceneManager.LoadSceneAsync(4);
    }
    public void PlayTagGame()
    {
        AnalyticsEvents.instance.CreateCustomEvent(AnalyticsEventTypes.whichGameWasPicked, null, 0, "Tag Game");
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
