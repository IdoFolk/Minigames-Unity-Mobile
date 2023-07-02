using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Services.Core;
using Unity.Services.Analytics;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;
using System.Linq.Expressions;
using System;
using Unity.Services.Core.Environments;

public class AnalyticsManager : MonoBehaviour
{

    // Start is called before the first frame update
    async void Awake()
    {
        await UnityServices.InitializeAsync();
        try
        {
            List<string> ConsentIdentifires = await AnalyticsService.Instance.CheckForRequiredConsents();
            if (ConsentIdentifires.Count > 0)
            {
                foreach (var consent in ConsentIdentifires)
                {
                    Debug.Log(consent);
                }
            }
            else
            {
                Debug.Log("No Need for Consent Identifires");
            }

        }
        catch (ConsentCheckException exception)
        {
            Debug.LogError("Consent Check Exception" + Environment.NewLine + exception.Message);
        }
        SceneManager.LoadScene(1);
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
