using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DavidMiniGameManager : MiniGameManager
{
    [SerializeField] DavidPlayer Blue;
    [SerializeField] DavidPlayer Green;
    [SerializeField] DavidPlayer Red;
    [SerializeField] DavidPlayer Yellow;
    #region PlayerActions

    public override void BlueButtonPressed()
    {
        Blue.Thrust();
    }

    public override void GreenButtonPressed()
    {
        Green.Thrust();
    }

    public override void RedButtonPressed()
    {
        Red.Thrust();
    }

    public override void YellowButtonPressed()
    {
        Yellow.Thrust();
    }
    #endregion

}
