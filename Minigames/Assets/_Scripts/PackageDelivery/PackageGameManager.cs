using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PackageGameManager : MiniGameManager
{
    [SerializeField] GameObject PauseMenu;
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
    public bool isGamePaused = true;

    private int TopScore;


    // Start is called before the first frame update
    void Start()
    {
        Instance = new();
        BackgroundStars.Pause();
    }

    // Update is called once per frame
    void Update()
    {
        PickWinner();
    }
    public override void StartScene()
    {
        PackageGameManager.Instance.isGamePaused = false;
        BackgroundStars.Play();
    }
    public void ActivatePauseButton()
    {
        PackageGameManager.Instance.isGamePaused = true;
        PauseMenu.SetActive(true);
        BackgroundStars.Pause();
    }
    public void DeactivatePauseButton()
    {
        PackageGameManager.Instance.isGamePaused = false;
        PauseMenu.SetActive(false);
        BackgroundStars.Play();
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
        PackageGameManager.Instance.isGamePaused = true;
        WinScreen.SetActive(true);
        BackgroundStars.Pause();
    }
    public void Restart()
    {
        SceneManager.LoadScene(3);
    }
    public void Leave()
    {
        SceneManager.LoadScene(0);
    }
}

