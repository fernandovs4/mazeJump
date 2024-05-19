using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour, IUnityAdsInitializationListener, IUnityAdsLoadListener, IUnityAdsShowListener
{
    [SerializeField] private string androidGameId = "5621301";
    [SerializeField] private string iosGameId = "5621300";
    [SerializeField] private string adUnitIdAndroid = "Rewarded_Android";
    [SerializeField] private string adUnitIdIos = "Rewarded_iOS";
    [SerializeField] private bool testMode = true;

    private static AdsManager instance;
    private string gameId;
    private string adUnitId;
    private bool isAdLoaded = false;

    void Awake()
    {
        // Implement Singleton pattern to ensure only one instance exists
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            InitializeAds();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void InitializeAds()
    {
        if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            gameId = iosGameId;
            adUnitId = adUnitIdIos;
        }
        else
        {
            gameId = androidGameId;
            adUnitId = adUnitIdAndroid;
        }
        Advertisement.Initialize(gameId, testMode, this);
        Debug.Log("Initializing Ads with gameId: " + gameId);
    }

    public void LoadAd()
    {
        Debug.Log("Loading Ad...");
        Advertisement.Load(adUnitId, this);
    }

    public void ShowAd()
    {
        if (isAdLoaded)
        {
            Debug.Log("Showing Ad...");
            Advertisement.Show(adUnitId, this);
        }
        else
        {
            Debug.LogWarning("Ad not ready yet.");
            LoadAd();
        }
    }

    public void OnInitializationComplete()
    {
        Debug.Log("Unity Ads initialization complete.");
        LoadAd();
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log($"Unity Ads Initialization Failed: {error.ToString()} - {message}");
    }

    public void OnUnityAdsAdLoaded(string adUnitId)
    {
        Debug.Log("Ad loaded: " + adUnitId);
        isAdLoaded = true;
    }

    public void OnUnityAdsFailedToLoad(string adUnitId, UnityAdsLoadError error, string message)
    {
        Debug.Log($"Error loading Ad Unit {adUnitId}: {error.ToString()} - {message}");
        isAdLoaded = false;
    }

    public void OnUnityAdsShowFailure(string adUnitId, UnityAdsShowError error, string message)
    {
        Debug.Log($"Error showing Ad Unit {adUnitId}: {error.ToString()} - {message}");
    }

    public void OnUnityAdsShowStart(string adUnitId) { }
    public void OnUnityAdsShowClick(string adUnitId) { }

    public void OnUnityAdsShowComplete(string adUnitId, UnityAdsShowCompletionState showCompletionState)
    {
        if (adUnitId.Equals(this.adUnitId) && showCompletionState.Equals(UnityAdsShowCompletionState.COMPLETED))
        {
            Debug.Log("Unity Ads Rewarded Ad Completed");
            FindObjectOfType<FinalCanva>().DubleCoinsReward();
            LoadAd(); // Load the next ad
        }
    }
}
