using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FlappyBirdMiniGameManager : MiniGameManager
{
    [SerializeField] FlappyBirdPlayer Blue;
    [SerializeField] FlappyBirdPlayer Green;
    [SerializeField] FlappyBirdPlayer Red;
    [SerializeField] FlappyBirdPlayer Yellow;
    [SerializeField] GameObject Obstacle;

    [SerializeField] GameObject EndGameUI;
    [SerializeField] TMPro.TMP_Text PlayerWon;
    [SerializeField] List<RawImage> Paralaxes;
    [SerializeField] List<float> ParalaxSpeed;
    [SerializeField] GameObject pauseButton;

    public ObstaclePullManager ObstaclePullManager;

    public int SpawnRate = 1;
    float timeAtLastSpawn = 5;
    public static int winValue = 1;

    #region Start Scene
    protected override void Awake()
    {
        base.Awake();
        winValue = 1;
    }
    public override void StartScene()
    {
        IsPaused = false;
        Blue.ActivateBody();
        Green.ActivateBody();
        Red.ActivateBody();
        Yellow.ActivateBody();
        timeAtLastSpawn = Time.timeSinceLevelLoad;
        pauseButton.SetActive(true);
    }
    #endregion

    #region Scene Gameplay

    #region PlayerActions

    public override void Continue()
    {
        base.Continue();
        Blue.Pause(true);
        Green.Pause(true);
        Yellow.Pause(true);
        Red.Pause(true);
    }
    public override void Pause()
    {
        base.Pause();
        Blue.Pause(false);
        Green.Pause(false);
        Yellow.Pause(false);
        Red.Pause(false);
    }
    public override void BlueButtonDown()
    {
        Blue.Thrust();
    }

    public override void GreenButtonDown()
    {
        Green.Thrust();
    }

    public override void RedButtonDown()
    {
        Red.Thrust();
    }

    public override void YellowButtonDown()
    {
        Yellow.Thrust();
    }
    #endregion

    #region MapGeneration
    private void Update()
    {
        if (Time.timeSinceLevelLoad - timeAtLastSpawn >= SpawnRate&&!IsPaused)
        {
            timeAtLastSpawn = Time.timeSinceLevelLoad;
            ObstaclePullManager.Spawn();
        }
        if (IsPaused) return;
        for (int i = 0; i < Paralaxes.Count;i++)
        {
            Paralaxes[i].uvRect = new Rect(Paralaxes[i].uvRect.x + ParalaxSpeed[i]*Time.deltaTime, Paralaxes[i].uvRect.y, Paralaxes[i].uvRect.width, Paralaxes[i].uvRect.height);
        }
    }
    public void CheckPlayers()
    {
        Debug.Log(winValue);
        switch (winValue)
        {
            case 2:
                PlayerWon.text = "Blue Won";
                OpenEndMenu();
                Debug.Log("Blue Won");
                break;
            case 3:
                PlayerWon.text = "Green Won";
                OpenEndMenu();
                Debug.Log("Green Won");
                break;
            case 5:
                PlayerWon.text = "Yellow Won";
                OpenEndMenu();
                Debug.Log("Yellow Won");
                break;
            case 7:
                PlayerWon.text = "Red Won";
                OpenEndMenu();
                Debug.Log("Red Won");
                break;
        }
    }

    #endregion


    #endregion

    #region End Game

    public void OpenEndMenu()
    {
        EndGameUI.SetActive(true);
        IsPaused = true;
        Blue.Pause(false);
        Green.Pause(false);
        Yellow.Pause(false);
        Red.Pause(false);
    }

    public void Restart()
    {
        SceneManager.LoadScene(2);
    }
    public void Leave()
    {
        SceneManager.LoadScene(0);
    }
    #endregion
}