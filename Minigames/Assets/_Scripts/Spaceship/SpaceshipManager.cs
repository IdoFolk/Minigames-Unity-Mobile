using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipManager : MiniGameManager
{ 
    [SerializeField] ShipHandeler blueShip;
    [SerializeField] ShipHandeler greenShip;
    [SerializeField] ShipHandeler redShip;
    [SerializeField] ShipHandeler yellowShip;
    private void Update()
    {
        CheckBlue();
        CheckRed();
        CheckYellow();
        CheckGreen();
    }
    private void CheckBlue()
    {
        if (InputManager.BlueTouch)
            blueShip.isMoving = true;
        else
            blueShip.isMoving = false;
    }
    private void CheckRed()
    {
        if (InputManager.RedTouch)
            redShip.isMoving = true;
        else
            redShip.isMoving = false;
    }
    private void CheckYellow()
    {
        if (InputManager.YellowTouch)
            yellowShip.isMoving = true;
        else
            yellowShip.isMoving = false;
    }
    private void CheckGreen()
    {
        if (InputManager.GreenTouch)
            greenShip.isMoving = true;
        else
            greenShip.isMoving = false;
    }
    public override void RedButtonPressed()
    {

    }

    public override void GreenButtonPressed()
    {
       
    }

    public override void YellowButtonPressed()
    {
       
    }

    public override void BlueButtonPressed()
    {

    }
}
