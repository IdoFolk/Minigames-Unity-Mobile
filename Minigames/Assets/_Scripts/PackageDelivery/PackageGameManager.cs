using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PackageGameManager : MiniGameManager
{

    [SerializeField] GameObject PauseMenu;
    [SerializeField] GameObject PauseButton;
    [SerializeField] GameObject WinScreen;
    [SerializeField] TMP_Text MiniGameWinnerText;
    [SerializeField] ParticleSystem BackgroundStars;
    [SerializeField] int NumberToWin;


    [Header("Players")]
    [SerializeField] PlayerShipHandeler YellowPlayer;
    [SerializeField] PlayerShipHandeler RedPlayer;
    [SerializeField] PlayerShipHandeler BluePlayer;
    [SerializeField] PlayerShipHandeler GreenPlayer;
    
    public static PackageGameManager Instance;
    private int TopScore;
    void Start()
    {
        IsPaused = true;
        Instance = new();
        BackgroundStars.Pause();
        PauseButton.SetActive(false);
    }

    void Update()
    {
        PickWinner();
    }
    public override void StartScene()
    {
        MiniGameManager.IsPaused = false;
        BackgroundStars.Play();
        PauseButton.SetActive(true);
    }
    private void OnApplicationFocus(bool focus)
    {
        if (!focus)
        {
            MiniGameManager.instace.Pause();
            BackgroundStars.Pause();
        }
        else
        {
            MiniGameManager.instace.Continue();
            BackgroundStars.Play();
        }
        PauseButton.SetActive(focus);
        PauseMenu.SetActive(!focus);
    }
    private void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            MiniGameManager.instace.Pause();
            BackgroundStars.Pause();
        }
        else
        {
            MiniGameManager.instace.Continue();
            BackgroundStars.Play();
        }
        PauseButton.SetActive(!pause);
        PauseMenu.SetActive(pause);
    }
    public TMP_Text WinnerText(string player)
    {
         MiniGameWinnerText.text = $"{player} Won";
        return MiniGameWinnerText;
    }
    public void PickWinner()
    {
        if (YellowPlayer.Score == NumberToWin)
        {
            WinnerText("Yellow Player");
            ActivateWinScreen();
            AnalyticsEvents.instance.WhichPlayerWonTheMost("whichPlayerWonMost", "Yellow Player", YellowPlayer.Score);
            return;
        }
        else if(RedPlayer.Score == NumberToWin)
        {
            WinnerText("Red Player");
            ActivateWinScreen();
            AnalyticsEvents.instance.WhichPlayerWonTheMost("whichPlayerWonMost", "Red Player", YellowPlayer.Score);

            return;
        }
        else if(BluePlayer.Score == NumberToWin)
        {
            WinnerText("Blue Player");
            ActivateWinScreen();
            AnalyticsEvents.instance.WhichPlayerWonTheMost("whichPlayerWonMost", "Blue Player", YellowPlayer.Score);

            return;
        }
        else if(GreenPlayer.Score == NumberToWin)
        {
            WinnerText("Green Player");
            ActivateWinScreen();
            AnalyticsEvents.instance.WhichPlayerWonTheMost("whichPlayerWonMost", "Green Player", YellowPlayer.Score);

            return;
        }
        
          

    }
    public void ActivateWinScreen()
    {
        MiniGameManager.IsPaused = true;
        WinScreen.SetActive(true);
        BackgroundStars.Pause();

    }
    public void Restart()
    {
        SceneManager.LoadScene(gameObject.scene.buildIndex);
    }
    public void Leave()
    {
        SceneManager.LoadScene(0);
    }
}

