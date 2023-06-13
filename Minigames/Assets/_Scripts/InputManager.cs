using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    /*public Button button;
    static List<Touch>[] Touches = new List<Touch>[4];

    private void Update()
    {
        Touches = new List<Touch>[4];
        Touches[0] = new(); //Left Down
        Touches[1] = new(); //Left Up
        Touches[2] = new(); //Right Down
        Touches[3] = new(); //Right Up
        foreach (Touch touch in Input.touches)
        {
            if (touch.position.x < Screen.width / 2)
            {
                if (touch.position.y < Screen.height / 2)
                {
                    Touches[0].Add(touch);
                    Debug.Log("Left Down");
                }
                else
                {

                    Debug.Log("Left Up");
                    Touches[1].Add(touch);
                }
            }
            else
            {
                if (touch.position.y < Screen.height / 2)
                {

                    Debug.Log("Right Down");
                    Touches[2].Add(touch);
                }
                else
                {

                    Debug.Log("Right Up");
                    Touches[3].Add(touch);
                }
            }
        }
    */
    static bool red_Touch;
    public static bool RedTouch 
    {
        get { return red_Touch; }
        set 
        { 
            red_Touch = value;
        }
    }
     static bool green_Touch;
    public static bool GreenTouch
    {
        get { return green_Touch; }
        set
        {
            green_Touch = value;
        }
    }
     static bool yellow_Touch;
    public static bool YellowTouch
    {
        get { return yellow_Touch; }
        set
        {
            yellow_Touch = value;
        }
    }
     static bool blue_Touch;
    public static bool BlueTouch 
    {
        get { return blue_Touch; }
        set 
        { 
            blue_Touch = value;
        }
    }
    private void Update()
    {
        if (red_Touch) { MiniGameManager.instace.RedAction(); }
        if (green_Touch) { MiniGameManager.instace.GreenAction(); }
        if (yellow_Touch) { MiniGameManager.instace.YellowAction(); }
        if (blue_Touch) { MiniGameManager.instace.BlueAction(); }
    }

}
