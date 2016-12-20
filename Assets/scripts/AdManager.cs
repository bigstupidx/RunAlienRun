using UnityEngine;
using GoogleMobileAds.Api;
using System.Collections;


public class AdManager : MonoBehaviour {

    BannerView banner;
    InterstitialAd fullAdmob;

    void Start()
    {
        RequestBanner();
        RequestFull();
    }

    void Update()
    {

    }

    void RequestBanner()
    {
        string bannerId = "ca-app-pub-7277243294948218/2314565481";
        banner = new BannerView(bannerId, AdSize.SmartBanner, AdPosition.Bottom);
        AdRequest adRequest = new AdRequest.Builder().Build();
        banner.LoadAd(adRequest);
    }

    public void ShowBanner()
    {
        banner.Show();
    }
   
    void RequestFull()
    {
        string idFull = "ca-app-pub-7277243294948218/9698231482";
        fullAdmob = new InterstitialAd(idFull);
        AdRequest adRequest = new AdRequest.Builder().Build();
        fullAdmob.LoadAd(adRequest);
    }

    public void ShowFullAds()
    {
        if (fullAdmob.IsLoaded())
        {
            fullAdmob.Show();
            RequestFull();
        }

        else
        {
            RequestFull();
        }
    }
}
