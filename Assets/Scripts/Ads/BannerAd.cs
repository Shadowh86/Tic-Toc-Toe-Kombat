using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class BannerAd : MonoBehaviour
{

    [SerializeField] string _androidAdUnitId = "Banner_Android";
    [SerializeField] string _iOsAdUnitId = "Banner_iOS";
    string _adUnitId;

    private void Start()
    {
        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
        ShowBannerAd();
        
    }

    void LoadBanner()
    {
        BannerLoadOptions options = new BannerLoadOptions();
        
    }

    void ShowBannerAd()
    {
        // Set up options to notify the SDK of show events:
        BannerOptions options = new BannerOptions
        {
            clickCallback = OnBannerClicked,
            hideCallback = OnBannerHidden,
            showCallback = OnBannerShown
        };

        // Show the loaded Banner Ad Unit:
        Advertisement.Banner.Show(_adUnitId, options);
    }

    // Implement a method to call when the Hide Banner button is clicked:
    void HideBannerAd()
    {
        // Hide the banner:
        Advertisement.Banner.Hide();
    }

    void OnBannerClicked() { }
    void OnBannerShown() { }
    void OnBannerHidden() { }

    //void OnDestroy()
    //{
    //    // Clean up the listeners:
    //    _loadBannerButton.onClick.RemoveAllListeners();
    //    _showBannerButton.onClick.RemoveAllListeners();
    //    _hideBannerButton.onClick.RemoveAllListeners();
    //}
}
