using System.Collections;
using System.Collections.Generic;
using Unity.Services.Analytics;
using UnityEngine;
using UnityEngine.UIElements;

public class AnalyticsEvents : MonoBehaviour
{
    public static AnalyticsEvents instance;

    private void Start()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    private Dictionary<string, object> WhichGameWasPicked(string MiniGameName)
    {
        Dictionary<string, object> parameters = new Dictionary<string, object>()
        {
            {"MiniGameName",MiniGameName},
        };
        return parameters;
    }
    private Dictionary<string, object> HowManyPackages(int PackageAmount, string PlayerColour)
    {
        Dictionary<string, object> parameters = new Dictionary<string, object>()
        {
            {"PlayerScore",PackageAmount },
            {"PlayerColor", PlayerColour},
        };
        return parameters;
    }
    private Dictionary<string, object> HowManyKills(string PlayerColor, int NumOfKills)
    {
        Dictionary<string, object> parameters = new Dictionary<string, object>()
        {
            {"PlayerScore",NumOfKills },
            {"PlayerColor", PlayerColor},
        };
        return parameters;
    }
    public void CreateCustomEvent(AnalyticsEventTypes EventName, string PlayerColor = null, int NumberToCheck = 0, string MiniGameName = null)
    {
        switch (EventName)
        {
            case AnalyticsEventTypes.whichGameWasPicked:
                AnalyticsService.Instance.CustomData(EventName.ToString(),WhichGameWasPicked(MiniGameName));
                break;
            case AnalyticsEventTypes.HowManyKills:
                AnalyticsService.Instance.CustomData(EventName.ToString(), HowManyKills(PlayerColor,NumberToCheck));
                break;
            case AnalyticsEventTypes.HowManyPackages:
                AnalyticsService.Instance.CustomData(EventName.ToString(), HowManyPackages(NumberToCheck,PlayerColor));
                break;
            default:
                Debug.LogWarning("You Wrote an event wrong at AnalyticsEvents!");
                break;
        }
    }
}
public enum AnalyticsEventTypes
{
    whichGameWasPicked,
    HowManyKills,
    HowManyPackages
}