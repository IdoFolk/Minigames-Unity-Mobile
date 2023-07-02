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
        Debug.Log(eventName+ PlayerColour+ Score + "Perhaps?");
        Dictionary<string, object> parameters = new Dictionary<string, object>()
        {
            {"Player Color",PlayerColour},
            {"Score", Score}
        };
        AnalyticsService.Instance.CustomData(eventName, parameters);
    }
    public void WhichGameWasPicked(string eventName, string MiniGameName)
    {
        Dictionary<string, object> parameters = new Dictionary<string, object>()
        {
            {"MiniGameName",MiniGameName}, 
        };
        AnalyticsService.Instance.CustomData(eventName , parameters);
    }
}
