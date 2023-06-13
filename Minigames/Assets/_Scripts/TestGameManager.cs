using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGameManager : MiniGameManager
{
    public override void BlueButtonPressed()
    {
        Debug.Log("Blue");
    }

    public override void GreenButtonPressed()
    {
        Debug.Log("Green");
    }

    public override void RedButtonPressed()
    {
        Debug.Log("Red");
    }

    public override void YellowButtonPressed()
    {
        Debug.Log("Yellow");
    }
}
