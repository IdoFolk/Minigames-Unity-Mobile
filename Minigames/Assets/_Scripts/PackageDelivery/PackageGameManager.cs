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

    void Start()
    {
        IsPaused = true;
        Instance = this;
        BackgroundStars.Pause();
        PauseButton.SetActive(false);
        PackageSoundManager.Instance.MainMusic.Pause();
    }

    public override void StartScene()
    {
        IsPaused = false;
        BackgroundStars.Play();
        PauseButton.SetActive(true);
        PackageSoundManager.Instance.MainMusic.Play();
        AdManager.Instance.LoadAd();
    }
    private void OnApplicationFocus(bool focus)
    {
        OnApplicationPause(!focus);
    }
    public void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            Pause();
            BackgroundStars.Pause();
            PackageSoundManager.Instance.MainMusic.Pause();
        }
        else
        {
            Continue();
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
        else if (RedPlayer.Score == NumberToWin)
        {
            WinnerText("Red Player");
            ActivateWinScreen();

            return;
        }
        else if (BluePlayer.Score == NumberToWin)
        {
            WinnerText("Blue Player");
            ActivateWinScreen();

            return;
        }
        else if (GreenPlayer.Score == NumberToWin)
        {
            WinnerText("Green Player");
            ActivateWinScreen();

            return;
        }



    }
    public void ActivateWinScreen()
    {
        IsPaused = true;
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
        AdManager.Instance.ShowAd();
    }
}

