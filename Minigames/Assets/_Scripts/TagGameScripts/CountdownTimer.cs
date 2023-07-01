using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class CountdownTimer : MonoBehaviour
{
    public List<TagGameManager> players; // List of player scripts
    public GameObject crown; // Reference to the crown GameObject

    float currentTime = 0f;
    float startingTime = 10f;

    [SerializeField] TMP_Text countdownText;

    void Start()
    {
        currentTime = startingTime;
    }

    private void Update()
    {
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
        TagGameManager winningPlayer = null;
        foreach (TagGameManager player in players)
        {
            if (crown.transform.parent == player.transform)
            {
                winningPlayer = player;
                break;
            }
        }

        if (winningPlayer != null)
        {
            Debug.Log("Player " + winningPlayer.name + " with the Crown wins!");
            // Add your win condition code here
        }
        else
        {
            Debug.Log("No player has the Crown. It's a draw!");
            // Add your win condition code here
        }
    }
}