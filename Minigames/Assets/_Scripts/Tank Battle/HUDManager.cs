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
        yellowScore.text = TankBattleGameManager.instance.yellowTankScore.ToString();
        redScore.text = TankBattleGameManager.instance.redTankScore.ToString();
        blueScore.text = TankBattleGameManager.instance.blueTankScore.ToString();
        greenScore.text = TankBattleGameManager.instance.greenTankScore.ToString();
    }
}
