using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TankBattleGameManager : MonoBehaviour
{
    public static TankBattleGameManager Instance;

    public int blueTankScore;
    public int greenTankScore;
    public int redTankScore;
    public int yellowTankScore;
    public bool GamePaused;

    public List<GameObject> TanksAlive = new List<GameObject>();

    [SerializeField] HUDManager hudManager;
    [SerializeField] GameObject pauseMenu;
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
    private void Update()
    {
        CheckTanksAlive();
    }
    public void AddToScore(PlayerColor bulletColor)
    {
        switch (bulletColor)
        {
            case PlayerColor.Blue:
                blueTankScore += 1;
                break;
            case PlayerColor.Green:
                greenTankScore += 1;
                break;
            case PlayerColor.Yellow:
                yellowTankScore += 1;
                break;
            case PlayerColor.Red:
                redTankScore += 1;
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
        GamePaused = true;
        winnerTitle.SetText(winnerTank.GetComponent<TankHandeler>().tankColor.ToString() + " Wins!");
        winnerScreen.SetActive(true);
    }
    public void PauseGame()
    {
        if (GamePaused) return;
        pauseMenu.SetActive(true);
        GamePaused = true;
    }
    public void RestartGame()
    {
        SceneManager.LoadScene("Tank Battle");
    }
    public void ExitGame()
    {
        SceneManager.LoadScene(0);
    }
}
