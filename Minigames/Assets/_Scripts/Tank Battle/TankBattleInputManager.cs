using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankBattleInputManager : MiniGameManager
{
    [SerializeField] TankHandeler blueTank;
    [SerializeField] TankHandeler greenTank;
    [SerializeField] TankHandeler redTank;
    [SerializeField] TankHandeler yellowTank;
    
   
    private void Start()
    {
        blueTank.tankColor = PlayerColor.Blue;
        greenTank.tankColor = PlayerColor.Green;
        redTank.tankColor = PlayerColor.Red;
        yellowTank.tankColor = PlayerColor.Yellow;
    }
    
    #region Input
    public override void BlueButtonDown()
    {
        blueTank.Shoot();
        blueTank.rotateDirection = !blueTank.rotateDirection;
    }

    public override void BlueButtonPressed()
    {
        blueTank.isMoving = true;
    }

    public override void BlueButtonUp()
    {
        blueTank.isMoving = false;
    }

    public override void GreenButtonDown()
    {
        greenTank.Shoot();
        greenTank.rotateDirection = !greenTank.rotateDirection;
    }

    public override void GreenButtonPressed()
    {
        greenTank.isMoving = true;
    }

    public override void GreenButtonUp()
    {
        greenTank.isMoving = false;
    }

    public override void RedButtonDown()
    {
        redTank.Shoot();
        redTank.rotateDirection = !redTank.rotateDirection;
    }

    public override void RedButtonPressed()
    {
        redTank.isMoving = true;
    }

    public override void RedButtonUp()
    {
        redTank.isMoving = false;
    }

    public override void YellowButtonDown()
    {
        yellowTank.Shoot();
        yellowTank.rotateDirection = !yellowTank.rotateDirection;
    }

    public override void YellowButtonPressed()
    {
        yellowTank.isMoving = true;
    }

    public override void YellowButtonUp()
    {
        yellowTank.isMoving = false;
    }
    #endregion
    
}
