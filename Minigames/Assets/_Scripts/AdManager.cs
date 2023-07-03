using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AdManager : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    public static AdManager Instance;

    [SerializeField] string androidAdUnitId = "Rewarded_Android";
    [SerializeField] string iOSAdUnitId = "Rewarded_iOS";
    private string adUnitId = null;

    private void Awake()
    {
#if UNITY_IOS
        adUnitId = _iOSAdUnitId;
#elif UNITY_ANDROID
        adUnitId = androidAdUnitId;
#endif
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

    }
    // Call this public method when you want to get an ad ready to show.
    public void LoadAd()
    {
        Debug.Log("Loading Ad: " + adUnitId);
        Advertisement.Load(adUnitId, this);
    }
    public void ShowAd()
    {
        // Disable the button:
        // Then show the ad:
        Advertisement.Show(adUnitId, this);
    }
    public void OnUnityAdsAdLoaded(string placementId)
    {
        Debug.Log("Ad Loaded: " + placementId);
    }
    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        if (placementId.Equals(adUnitId) && showCompletionState.Equals(UnityAdsShowCompletionState.COMPLETED))
        {
            SceneManager.LoadScene(1); //load main menu
            Debug.Log("Unity Ads Rewarded Ad Completed");
        }
    }
    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        Debug.Log($"Failed to load Ad Unit {placementId}: {error.ToString()} - {message}");

    }
    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        Debug.Log($"Failed to show Ad Unit {placementId}: {error.ToString()} - {message}");
    }
    public void OnUnityAdsShowStart(string adUnitId) { }
    public void OnUnityAdsShowClick(string adUnitId) { }

}
