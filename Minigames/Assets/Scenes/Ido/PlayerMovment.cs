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



    public override void BlueAction()
    {
        Blue.Forward();

    }
               

    public override void GreenAction()
    {
        Green.Forward();
    }

    public override void RedAction()
    {
        Red.Forward();
    }

    public override void YellowAction()
    {
        Yellow.Forward();
    }

}
 #endregion 