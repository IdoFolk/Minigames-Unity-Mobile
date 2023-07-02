using System.Collections;
using System.Collections.Generic;
using Unity.Services.Analytics;
using UnityEngine;

public class AnalyticsEvents : MonoBehaviour
{
    public static AnalyticsEvents instance;
    private void Start()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    public void WhichPlayerWonTheMost(string eventName, string PlayerColour, int Score)
    {
        Dictionary<string, object> parameters = new Dictionary<string, object>()
        {
            {"Player",PlayerColour},
            {"Score", Score}
        };
        AnalyticsService.Instance.CustomData(eventName, parameters);
    }
}
