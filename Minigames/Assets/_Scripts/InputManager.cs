using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{

    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject pauseButton;
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
            if (value) MiniGameManager.instace.RedButtonDown();
            else MiniGameManager.instace.RedButtonUp();
            red_Touch = value;
        }
    }
     static bool green_Touch;
    public static bool GreenTouch
    {
        get { return green_Touch; }
        set
        {
            if (value) MiniGameManager.instace.GreenButtonDown();
            else MiniGameManager.instace.GreenButtonUp();
            green_Touch = value;
        }
    }
     static bool yellow_Touch;
    public static bool YellowTouch
    {
        get { return yellow_Touch; }
        set
        {
            if (value) MiniGameManager.instace.YellowButtonDown();
            else MiniGameManager.instace.YellowButtonUp();
            yellow_Touch = value;
        }
    }
     static bool blue_Touch;
    public static bool BlueTouch 
    {
        get { return blue_Touch; }
        set 
        {
            if (value) MiniGameManager.instace.BlueButtonDown();
            else MiniGameManager.instace.BlueButtonUp();
            blue_Touch = value;
        }
    }
    private void Update()
    {
        if (red_Touch) { MiniGameManager.instace.RedButtonPressed(); }
        if (green_Touch) { MiniGameManager.instace.GreenButtonPressed(); }
        if (yellow_Touch) { MiniGameManager.instace.YellowButtonPressed(); }
        if (blue_Touch) { MiniGameManager.instace.BlueButtonPressed(); }
    }

    public void OnApplicationPause(bool pause)
    {
        if (pause) { MiniGameManager.instace.Pause(); }
        else MiniGameManager.instace.Continue();
        pauseMenu.SetActive(pause);
        Debug.Log(pause);
        pauseButton.SetActive(!pause);
    }
    private void Start()
    {
        if (MiniGameManager.IsPaused) pauseButton.SetActive(false);
    }
    public void ExitGame()
    {
        SceneManager.LoadScene(0);
    }
    public void Restart()
    {
        SceneManager.LoadScene(gameObject.scene.buildIndex);
    }
}
