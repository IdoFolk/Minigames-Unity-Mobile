using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MiniGameManager
{
    [SerializeField] IdoPlayer Blue;
    [SerializeField] IdoPlayer Green;
    [SerializeField] IdoPlayer Red;
    [SerializeField] IdoPlayer Yellow;

    
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