using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TankBattleGameManager : MiniGameManager
{
    public static TankBattleGameManager Instance;

    public int blueTankScore;
    public int greenTankScore;
    public int redTankScore;
    public int yellowTankScore;

    public List<GameObject> TanksAlive = new List<GameObject>();

    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject pauseButton;
    [SerializeField] HUDManager hudManager;
    [SerializeField] GameObject winnerScreen;
    [SerializeField] TextMeshProUGUI winnerTitle;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    private void Start()
    {
        IsPaused = true;
        pauseButton.SetActive(false);
    }
    public override void StartScene()
    {
        MiniGameManager.IsPaused = false;
        pauseButton.SetActive(true);
    }
    private void Update()
    {
        CheckTanksAlive();
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
        pauseButton.SetActive(!pause);
        pauseMenu.SetActive(pause);
    }
    public void AddToScore(PlayerColor bulletColor)
    {
        switch (bulletColor)
        {
            case PlayerColor.Blue:
                blueTankScore += 1;
                AnalyticsEvents.CreateEvent(AnalyticsEventTypes.HowManyKills, PlayerColor.Blue.ToString(), blueTankScore);
                break;
            case PlayerColor.Green:
                greenTankScore += 1;
                AnalyticsEvents.CreateEvent(AnalyticsEventTypes.HowManyKills, PlayerColor.Green.ToString(), greenTankScore);
                break;
            case PlayerColor.Yellow:
                yellowTankScore += 1;
                AnalyticsEvents.CreateEvent(AnalyticsEventTypes.HowManyKills, PlayerColor.Yellow.ToString(), yellowTankScore);
                break;
            case PlayerColor.Red:
                redTankScore += 1;
                AnalyticsEvents.CreateEvent(AnalyticsEventTypes.HowManyKills, PlayerColor.Red.ToString(), redTankScore);
                break;
        }
        hudManager.ChangeScore();
    }
    public void RemoveTank(PlayerColor tankColor)
    {
        foreach (var tank in TanksAlive)
        {
            if (tank.GetComponent<TankHandeler>().tankColor == tankColor)
            {
                TanksAlive.Remove(tank);
                return;
            }
        }
    }
    public void CheckTanksAlive()
    {
        if (TanksAlive.Count == 1)
        {
            EndGame(TanksAlive[0]);
        }
    }
    public void EndGame(GameObject winnerTank)
    {
        MiniGameManager.IsPaused = true;
        winnerTitle.SetText(winnerTank.GetComponent<TankHandeler>().tankColor.ToString() + " Wins!");
        RemoveTank(winnerTank.GetComponent<TankHandeler>().tankColor);
        Destroy(winnerTank);
        winnerScreen.SetActive(true);
    }
   
}
