using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankBattleGameManager : MonoBehaviour
{
    public static TankBattleGameManager instance;

    public int blueTankScore;
    public int greenTankScore;
    public int redTankScore;
    public int yellowTankScore;

    [SerializeField] HUDManager hudManager;
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
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
    public void EndGame()
    {

    }
}
