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
        PackageSoundManager.Instance.MainMusic.Pause();
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
        PackageSoundManager.Instance.MainMusic.Play();
    }
    private void OnApplicationFocus(bool focus)
    {
        if (!focus)
        {
            MiniGameManager.instace.Pause();
            BackgroundStars.Pause();
            PackageSoundManager.Instance.MainMusic.Pause();
        }
        else
        {
            MiniGameManager.instace.Continue();
            BackgroundStars.Play();
            PackageSoundManager.Instance.MainMusic.UnPause();
        }
        PauseButton.SetActive(focus);
        PauseMenu.SetActive(!focus);
    }
    public void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            MiniGameManager.instace.Pause();
            BackgroundStars.Pause();
            PackageSoundManager.Instance.MainMusic.Pause();
        }
        else
        {
            MiniGameManager.instace.Continue();
            BackgroundStars.Play();
            PackageSoundManager.Instance.MainMusic.UnPause();
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
            return;
        }
        else if(RedPlayer.Score == NumberToWin)
        {
            WinnerText("Red Player");
            ActivateWinScreen();

            return;
        }
        else if(BluePlayer.Score == NumberToWin)
        {
            WinnerText("Blue Player");
            ActivateWinScreen();

            return;
        }
        else if(GreenPlayer.Score == NumberToWin)
        {
            WinnerText("Green Player");
            ActivateWinScreen();

            return;
        }
        
          

    }
    public void ActivateWinScreen()
    {
        MiniGameManager.IsPaused = true;
        WinScreen.SetActive(true);
        BackgroundStars.Pause();
        PackageSoundManager.Instance.MainMusic.PlayOneShot(PackageSoundManager.Instance.WinningMusic, 0.15f);

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

