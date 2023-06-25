using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PackageGameManager : MiniGameManager
{
    [SerializeField] public GameObject PauseMenu;
    [SerializeField] public GameObject WinScreen;
    [SerializeField] public TMP_Text MiniGameWinnerText;
    [SerializeField] public ParticleSystem BackgroundStars;


    [Header("Players")]
    [SerializeField] GameObject YellowPlayer;
    [SerializeField] GameObject RedPlayer;
    [SerializeField] GameObject BluePlayer;
    [SerializeField] GameObject GreenPlayer;
    
    public static PackageGameManager Instance;
    public bool isGamePaused = true;

    private int TopScore;


    // Start is called before the first frame update
    void Start()
    {
        Instance = new();
        BackgroundStars.Pause();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void StartScene()
    {
        PackageGameManager.Instance.isGamePaused = false;
        BackgroundStars.Play();
    }
    public void ActivatePauseButton()
    {
        isGamePaused = true;
        PauseMenu.SetActive(true);
        BackgroundStars.Pause();
    }
    public void ActivateWinScreen()
    {
        isGamePaused = true;
        WinScreen.SetActive(true);
        BackgroundStars.Pause();

    }
    public void Restart()
    {
        SceneManager.LoadScene(3);
    }
    public void Leave()
    {
        SceneManager.LoadScene(0);
    }
}

