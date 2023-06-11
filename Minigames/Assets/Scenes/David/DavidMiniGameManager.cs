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

    public override void BlueAction()
    {
        Blue.Thrust();
    }

    public override void GreenAction()
    {
        Green.Thrust();
    }

    public override void RedAction()
    {
        Red.Thrust();
    }

    public override void YellowAction()
    {
        Yellow.Thrust();
    }
    #endregion

}
