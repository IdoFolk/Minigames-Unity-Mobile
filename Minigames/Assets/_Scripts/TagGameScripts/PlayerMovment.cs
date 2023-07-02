using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MiniGameManager
{

    public static TankBattleGameManager Instance;

    [SerializeField] TagPlayerManager Blue;
    [SerializeField] TagPlayerManager Green;
    [SerializeField] TagPlayerManager Red;
    [SerializeField] TagPlayerManager Yellow;

    
    float m_Speed;
    #region PlayerActions



    public override void BlueButtonPressed()
    {
        Blue.Forward();

    }
               

    public override void GreenButtonPressed()
    {
        Green.Forward();
    }

    public override void RedButtonPressed()
    {
        Red.Forward();
    }

    public override void YellowButtonPressed()
    {
        Yellow.Forward();
    }

}
 #endregion 