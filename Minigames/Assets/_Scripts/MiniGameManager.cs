using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MiniGameManager : MonoBehaviour
{
    public static MiniGameManager instace;
    /// <summary>
    /// Activated if button is being pressed
    /// </summary>
    #region ButtonPressed
    public virtual void RedButtonPressed()
    {
        Debug.Log("Red button is being pressed");
    }
    public virtual void GreenButtonPressed()
    {
        Debug.Log("Green button is being pressed");
    }
    public virtual void YellowButtonPressed()
    {
        Debug.Log("Yellow button is being pressed");
    }
    public virtual void BlueButtonPressed()
    {
        Debug.Log("Blue button is being pressed");
    }
    #endregion
    /// <summary>
    /// Activated if player pressed the button in this frame
    /// </summary>
    #region ButtonDown
    public virtual void RedButtonDown()
    {
        Debug.Log("Red button is pressed in this frame");
    }
    public virtual void GreenButtonDown()
    {
        Debug.Log("Green button is pressed in this frame");
    }
    public virtual void YellowButtonDown()
    {
        Debug.Log("Yellow button is pressed in this frame");
    }
    public virtual void BlueButtonDown()
    {
        Debug.Log("Blue button is pressed in this frame");
    }
    #endregion
    /// <summary>
    /// Activated if this is last frame of button being pressed
    /// </summary>
    #region ButtonUp
    public virtual void RedButtonUp()
    {
        Debug.Log("Red button is unpressed in this frame");
    }
    public virtual void GreenButtonUp()
    {
        Debug.Log("Green button is unpressed in this frame");
    }
    public virtual void YellowButtonUp()
    {
        Debug.Log("Yellow button is unpressed in this frame");
    }
    public virtual void BlueButtonUp()
    {
        Debug.Log("Blue button is unpressed in this frame");
    }
    #endregion
    private void Awake()
    {
        instace = this;
    }
}