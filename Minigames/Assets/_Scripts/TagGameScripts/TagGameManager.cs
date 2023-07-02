using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
<<<<<<< Updated upstream
using TMPro;
using UnityEngine.SceneManagement;

public class TagGameManager : MiniGameManager
{ 
[SerializeField] GameObject PauseMenu;
[SerializeField] GameObject PauseButton;



[Header("Players")]
[SerializeField] TagPlayerManager YellowPlayer;
[SerializeField] TagPlayerManager RedPlayer;
[SerializeField] TagPlayerManager BluePlayer;
[SerializeField] TagPlayerManager GreenPlayer;

    public static TagGameManager Instance;



    // Start is called before the first frame update
    void Start()
    {
        IsPaused = true;
        Instance = new();
        PauseButton.SetActive(false);
    }

    public override void StartScene()
{
    MiniGameManager.IsPaused = false;
      PauseButton.SetActive(true);
}
private void OnApplicationFocus(bool focus)
{
    if (!focus)
    {
        MiniGameManager.instace.Pause();
        
    }
    else
    {
        MiniGameManager.instace.Continue();
   
        }
    PauseButton.SetActive(focus);
    PauseMenu.SetActive(!focus);
}
private void OnApplicationPause(bool pause)
{
    if (pause)
    {
        MiniGameManager.instace.Pause();
       
    }
    else
    {
        MiniGameManager.instace.Continue();
       
    }
    PauseButton.SetActive(!pause);
    PauseMenu.SetActive(pause);
}

public void Restart()
{
    SceneManager.LoadScene(gameObject.scene.buildIndex);
}
public void Leave()
{
    SceneManager.LoadScene(0);
}
=======
using UnityEngine.SceneManagement;


public class TagPlayerManager : MonoBehaviour
{

>>>>>>> Stashed changes
}
