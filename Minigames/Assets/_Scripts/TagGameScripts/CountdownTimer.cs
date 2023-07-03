using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CountdownTimer : MonoBehaviour
{
    [SerializeField] List<TagPlayerManager> players; 
    [SerializeField] GameObject crown;


    [SerializeField] GameObject WinScreen;
    [SerializeField] TMP_Text MiniGameWinnerText;

    float currentTime = 0f;
    float startingTime = 10f;

    [SerializeField] TMP_Text countdownText;


    private void Start()
    {
        currentTime = startingTime;     
    }

    private void Update()
    {
        if (MiniGameManager.IsPaused) return;
        currentTime -= 1 * Time.deltaTime;
        countdownText.text = currentTime.ToString("0");

        if (currentTime <= 0)
        {
            currentTime = 0;
            DetermineWinner();
        }
    }

    private void DetermineWinner()
    {
        TagPlayerManager winningPlayer = null;
        foreach (TagPlayerManager player in players)
        {
            if (crown.transform.parent == player.transform)
            {
                winningPlayer = player;
                break;
            }
        }

        if (winningPlayer != null)
        {
            ActivateWinScreen();

        }
        else
        {
            ActivateWinScreen();
        }


    }

    public TMP_Text WinnerText(string player)
    {
        MiniGameWinnerText.text = $"{player} Won";
        return MiniGameWinnerText;
    }

    public void ActivateWinScreen()
    {
        MiniGameManager.IsPaused = true;
        WinScreen.SetActive(true);

        // Determine the winning player and set the winner's text
        TagPlayerManager winningPlayer = null;
        foreach (TagPlayerManager player in players)
        {
            if (crown.transform.parent == player.transform)
            {
                winningPlayer = player;
                break;
            }
        }

        if (winningPlayer != null)
        {
            MiniGameWinnerText.text = $"{winningPlayer.name} Wins!";
        }
        else
        {
            MiniGameWinnerText.text = "It's a draw!";
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(gameObject.scene.buildIndex);
    }
    public void Leave()
    {
        SceneManager.LoadScene(0);
    }
}