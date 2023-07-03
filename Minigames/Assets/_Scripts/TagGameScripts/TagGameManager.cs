using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TagGameManager : MiniGameManager
{

    [SerializeField] TagPlayerManager Blue;
    [SerializeField] TagPlayerManager Green;
    [SerializeField] TagPlayerManager Red;
    [SerializeField] TagPlayerManager Yellow;

    [SerializeField] GameObject PauseMenu;
    [SerializeField] GameObject PauseButton;
    [SerializeField] GameObject WinScreen;
    [SerializeField] TMP_Text MiniGameWinnerText;
    [SerializeField] CountdownTimer GameTimer;


    private void Start()
    {
        IsPaused = true;
        PauseButton.SetActive(false);
    }
    public override void StartScene()
    {
        MiniGameManager.IsPaused = false;

        PauseButton.SetActive(true);
        GameTimer.enabled = true;
    }

    public void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            MiniGameManager.instace.Pause();
        }
        else
        {
            MiniGameManager.instace.Continue();
        }
        PauseButton.SetActive(!pause);
        PauseMenu.SetActive(pause);
    }

    public void Restart()
    {
        SceneManager.LoadScene(gameObject.scene.buildIndex);
    }
    public void Leave()
    {
        SceneManager.LoadScene(0);
    }
    public override void BlueButtonPressed()
    {
        if (IsPaused) return;
        Blue.Forward();
    }

    public override void GreenButtonPressed()
    {
        if (IsPaused) return;
        Green.Forward();
    }

    public override void RedButtonPressed()
    {
        if (IsPaused) return;
        Red.Forward();
    }

    public override void YellowButtonPressed()
    {
        if (IsPaused) return;
        Yellow.Forward();
    }
}





