using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class CountdownTimer : MiniGameManager
{
<<<<<<< Updated upstream
<<<<<<< Updated upstream
    public List<TagGameManager> players; // List of player scripts
=======
    public List<TagPlayerManager> players; // List of player scripts
>>>>>>> Stashed changes
    public GameObject crown; // Reference to the crown GameObject
=======
    [SerializeField] List<TagPlayerManager> players; // List of player scripts
    [SerializeField] GameObject crown; // Reference to the crown GameObject

    [SerializeField] GameObject WinScreen;
    [SerializeField] TMP_Text MiniGameWinnerText;
>>>>>>> Stashed changes

    float currentTime = 0f;
    float startingTime = 10f;

    [SerializeField] TMP_Text countdownText;

    void Start()
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
<<<<<<< Updated upstream
<<<<<<< Updated upstream
        TagGameManager winningPlayer = null;
        foreach (TagGameManager player in players)
=======
        TagPlayerManager winningPlayer = null;
        foreach (TagPlayerManager player in players)
>>>>>>> Stashed changes
=======
        TagPlayerManager winningPlayer = null;
        foreach (TagPlayerManager player in players)
>>>>>>> Stashed changes
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
            Debug.Log("Player " + winningPlayer.name + " with the Crown wins!");
            // Add your win condition code here
        }
        else
        {
            Debug.Log("No player has the Crown. It's a draw!");
            // Add your win condition code here
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
}