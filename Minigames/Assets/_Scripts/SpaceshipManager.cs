using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipManager : MiniGameManager
{
    public override void BlueAction()
    {
        Debug.Log("Blue");
    }

    public override void GreenAction()
    {
        Debug.Log("Green");
    }

    public override void RedAction()
    {
        Debug.Log("Red");
    }

    public override void YellowAction()
    {
        Debug.Log("Yellow");
    }
}
