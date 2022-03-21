using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsCore : MonoBehaviour
{
    [SerializeField]
    private bool testMode = true;

    private string video = "Interstitial_Android";
    private string revardedVideo = "Rewarded Android";
    private string banner = "Banner_Android";
    private string gameId = "4667413";
    // Start is called before the first frame update


    void Start()
    {
        Advertisement.Initialize(gameId, testMode);

        #region Banner
        StartCoroutine(ShowBannerWhenInitialized());
        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
        #endregion
    }

    IEnumerator ShowBannerWhenInitialized()
    {
        while (!Advertisement.isInitialized)
        {

            yield return new WaitForSeconds(0.5f);
        }
        Advertisement.Banner.Show(banner);
    }

    public static void ShowAdsVideo(string placementId)
    {
        if (Advertisement.IsReady())
        {
            Advertisement.Show(placementId);
        }
        else
        {
            Debug.Log("Advertisement not ready");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
