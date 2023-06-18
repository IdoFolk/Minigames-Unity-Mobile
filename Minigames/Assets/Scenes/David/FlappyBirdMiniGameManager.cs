using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappyBirdMiniGameManager : MiniGameManager
{
    [SerializeField] FlappyBirdPlayer Blue;
    [SerializeField] FlappyBirdPlayer Green;
    [SerializeField] FlappyBirdPlayer Red;
    [SerializeField] FlappyBirdPlayer Yellow;
    [SerializeField] GameObject Obstacle;

    [SerializeField] GameObject EndGameUI;
    [SerializeField] TMPro.TMP_Text PlayerWon;

    public ObstaclePullManager ObstaclePullManager;

    public int SpawnRate = 1;
    float timeAtLastSpawn = 5;

    #region Start Scene
    public void StartScene()
    {
        Blue.ActivateBody();
        Green.ActivateBody();
        Red.ActivateBody();
        Yellow.ActivateBody();
        timeAtLastSpawn = Time.timeSinceLevelLoad;
    }
    #endregion

    #region Scene Gameplay

    #region PlayerActions

    public override void BlueButtonDown()
    {
        Blue.Thrust();
    }

    public override void GreenButtonDown()
    {
        Green.Thrust();
    }

    public override void RedButtonDown()
    {
        Red.Thrust();
    }

    public override void YellowButtonDown()
    {
        Yellow.Thrust();
    }
    #endregion

    #region MapGeneration
    private void Update()
    {
        if (Time.timeSinceLevelLoad - timeAtLastSpawn >= SpawnRate)
        {
            timeAtLastSpawn = Time.timeSinceLevelLoad;
            ObstaclePullManager.Spawn();
        }
    }
    public void CheckPlayers()
    {
        if (Blue.gameObject.active && !(Green.gameObject.active || Red.gameObject.active || Yellow.gameObject.active))
        {
            PlayerWon.text = "Blue Won";
            OpenEndMenu();
            Debug.Log("Blue Won");
        }
        else if (Green.gameObject.active && !(Blue.gameObject.active || Red.gameObject.active || Yellow.gameObject.active))
        {
            PlayerWon.text = "Green Won";
            OpenEndMenu();
            Debug.Log("Green Won");
        }
        else if (Yellow.gameObject.active && !(Blue.gameObject.active || Red.gameObject.active || Green.gameObject.active))
        {
            PlayerWon.text = "Yellow Won";
            OpenEndMenu();
            Debug.Log("Yellow Won");
        }
        else if (Red.gameObject.active && !(Blue.gameObject.active || Green.gameObject.active || Yellow.gameObject.active))
        {
            PlayerWon.text = "Red Won";
            OpenEndMenu();
            Debug.Log("Red Won");
        }
    }

    #endregion


    #endregion

    #region End Game

    public void OpenEndMenu()
    {
        EndGameUI.SetActive(true);
    }
    #endregion
}