using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUDManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI yellowScore;
    [SerializeField] TextMeshProUGUI redScore;
    [SerializeField] TextMeshProUGUI blueScore;
    [SerializeField] TextMeshProUGUI greenScore;

    public void ChangeScore()
    {
        yellowScore.text = TankBattleGameManager.Instance.yellowTankScore.ToString();
        redScore.text = TankBattleGameManager.Instance.redTankScore.ToString();
        blueScore.text = TankBattleGameManager.Instance.blueTankScore.ToString();
        greenScore.text = TankBattleGameManager.Instance.greenTankScore.ToString();
    }
}
