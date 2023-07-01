using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankBattleInputManager : MiniGameManager
{
    [SerializeField] TankHandeler blueTank;
    [SerializeField] TankHandeler greenTank;
    [SerializeField] TankHandeler redTank;
    [SerializeField] TankHandeler yellowTank;

    private TankBattleGameManager gameManager = TankBattleGameManager.Instance;

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
        blueTank.SwitchRotateDirection();
    }

    public override void BlueButtonPressed()
    {
        blueTank.Move(true);
    }

    public override void BlueButtonUp()
    {
        blueTank.Move(false);
    }

    public override void GreenButtonDown()
    {
        greenTank.Shoot();
        greenTank.SwitchRotateDirection();
    }

    public override void GreenButtonPressed()
    {
        greenTank.Move(true);
    }

    public override void GreenButtonUp()
    {
        greenTank.Move(false);
    }

    public override void RedButtonDown()
    {
        redTank.Shoot();
        redTank.SwitchRotateDirection();
    }

    public override void RedButtonPressed()
    {
        redTank.Move(true);
    }

    public override void RedButtonUp()
    {
        redTank.Move(false);
    }

    public override void YellowButtonDown()
    {
        yellowTank.Shoot();
        yellowTank.SwitchRotateDirection();
    }

    public override void YellowButtonPressed()
    {
        yellowTank.Move(true);
    }

    public override void YellowButtonUp()
    {
        yellowTank.Move(false);
    }
    #endregion
    
}
