using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipManager : MiniGameManager
{ 
    [SerializeField] ShipHandeler blueShip;
    [SerializeField] ShipHandeler greenShip;
    [SerializeField] ShipHandeler redShip;
    [SerializeField] ShipHandeler yellowShip;

    private void Start()
    {
        blueShip.shipColor = PlayerColor.Blue;
        greenShip.shipColor = PlayerColor.Green;
        redShip.shipColor = PlayerColor.Red;
        yellowShip.shipColor = PlayerColor.Yellow;
    }
    public override void BlueButtonDown()
    {
        blueShip.Shoot();
        blueShip.rotateDirection = !blueShip.rotateDirection;
    }

    public override void BlueButtonPressed()
    {
        blueShip.isMoving = true;
    }

    public override void BlueButtonUp()
    {
        blueShip.isMoving = false;
    }

    public override void GreenButtonDown()
    {
        greenShip.Shoot();
        greenShip.rotateDirection = !greenShip.rotateDirection;
    }

    public override void GreenButtonPressed()
    {
        greenShip.isMoving = true;
    }

    public override void GreenButtonUp()
    {
        greenShip.isMoving = false;
    }

    public override void RedButtonDown()
    {
        redShip.Shoot();
        redShip.rotateDirection = !redShip.rotateDirection;
    }

    public override void RedButtonPressed()
    {
        redShip.isMoving = true;
    }

    public override void RedButtonUp()
    {
        redShip.isMoving = false;
    }

    public override void YellowButtonDown()
    {
        yellowShip.Shoot();
        yellowShip.rotateDirection = !yellowShip.rotateDirection;
    }

    public override void YellowButtonPressed()
    {
        yellowShip.isMoving = true;
    }

    public override void YellowButtonUp()
    {
        yellowShip.isMoving = false;
    }
}
