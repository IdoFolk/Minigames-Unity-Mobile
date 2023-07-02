using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TagGameManager : MiniGameManager
{

        [SerializeField] GameObject PauseMenu;
        [SerializeField] GameObject PauseButton;
        [SerializeField] GameObject WinScreen;
        [SerializeField] TMP_Text MiniGameWinnerText;


    [Header("Players")]
    [SerializeField] PlayerMovment YellowPlayer;
    [SerializeField] PlayerMovment RedPlayer;
    [SerializeField] PlayerMovment BluePlayer;
    [SerializeField] PlayerMovment GreenPlayer;

    public static TagPlayerManager Instance;

    void Start()
    {
        IsPaused = true;
        Instance = new();

        PauseButton.SetActive(false);
    }

    public override void StartScene()
    {
        MiniGameManager.IsPaused = false;

        PauseButton.SetActive(true);
    }

    private void OnApplicationPause(bool pause)
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
}


   
