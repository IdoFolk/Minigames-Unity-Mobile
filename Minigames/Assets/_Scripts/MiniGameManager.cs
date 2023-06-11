using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MiniGameManager : MonoBehaviour
{
    public static MiniGameManager instace;
    
    public abstract void RedAction();
    public abstract void GreenAction();
    public abstract void YellowAction();
    public abstract void BlueAction();
    private void Awake()
    {
        instace = this;
    }
}
