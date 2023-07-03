using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MiniGameManager
{

    [SerializeField] TagPlayerManager Blue;
    [SerializeField] TagPlayerManager Green;
    [SerializeField] TagPlayerManager Red;
    [SerializeField] TagPlayerManager Yellow;

    
    
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