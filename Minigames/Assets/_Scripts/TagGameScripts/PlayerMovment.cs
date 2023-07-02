using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MiniGameManager
{
<<<<<<< Updated upstream
    [SerializeField] TagGameManager Blue;
    [SerializeField] TagGameManager Green;
    [SerializeField] TagGameManager Red;
    [SerializeField] TagGameManager Yellow;
=======

    public static PlayerMovment Instance;

    [SerializeField] TagPlayerManager Blue;
    [SerializeField] TagPlayerManager Green;
    [SerializeField] TagPlayerManager Red;
    [SerializeField] TagPlayerManager Yellow;
>>>>>>> Stashed changes

    
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