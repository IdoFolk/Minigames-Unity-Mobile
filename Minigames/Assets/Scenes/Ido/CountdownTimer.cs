using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class CountdownTimer : MonoBehaviour
{

    float currentTime = 0f;
    float startingTime = 60f;

    [SerializeField] TMP_Text countdownText;
    void Start()
    {
        currentTime = startingTime;
    }

    private void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        countdownText.text = currentTime.ToString("0");
        
        if(currentTime <= 0)
        {
            currentTime = 0;
        }

    }

}
