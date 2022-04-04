//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using GoogleMobileAds.Api;
//using System;
//using UnityEngine.Monetization;
////using ChartboostSDK;

//public class ClaimForVideo : MonoBehaviour
//{
//    private RewardBasedVideoAd rewardBasedVideo;
//    public GameObject noRewardVideo;

//    void Start()
//    {
//        //ADMOB
//#if UNITY_ANDROID
//        string appId = "ca-app-pub-8193348033218710~4605542076";
//#else
//            string appId = "unexpected_platform";
//#endif

//        MobileAds.Initialize(appId);

//        rewardBasedVideo = RewardBasedVideoAd.Instance;

//        RequestRewardBasedVideo();

//        //ChartBoost
//        //Chartboost.cacheRewardedVideo(CBLocation.Default);
//    }

//    //ADMOB
//    private void RequestRewardBasedVideo()
//    {
//#if UNITY_ANDROID
//        string adUnitId = "ca-app-pub-3940256099942544/5224354917";
//#else
//            string appId = "unexpected_platform";
//#endif

//        AdRequest request = new AdRequest.Builder().Build();

//        //rewardBasedVideo.LoadAd(request, adUnitId);
//    }

//    //ADMOB
//    public void HandleRewardBasedVideoClosed(object sender, EventArgs args)
//    {
//        MonoBehaviour.print("HandleRewardBasedVideoClosed event received");
//        RequestRewardBasedVideo();
//    }

//    //ADMOB
//    public void HandleRewardBasedVideoRewarded(object sender, Reward args)
//    {
//        string type = args.Type;
//        double amount = args.Amount;
//        MonoBehaviour.print(
//            "HandleRewardBasedVideoRewarded event received for "
//                        + amount.ToString() + " " + type);

//        GameManager.instance.data.stars += (int)amount;
//        GameManager.instance.ActualizeData();
//        RequestRewardBasedVideo();
//    }

//    //UNITY ADS
//    public string placementId = "rewardedVideo";

//    public void ShowAd()
//    {
//        StartCoroutine(WaitForAd());
//    }

//    //UNITY ADS
//    IEnumerator WaitForAd()
//    {
//        while (!Monetization.IsReady(placementId))
//        {
//            yield return null;
//        }

//        ShowAdPlacementContent ad = null;
//        ad = Monetization.GetPlacementContent(placementId) as ShowAdPlacementContent;

//        if (ad != null)
//        {
//            ad.Show(AdFinished);
//        }
//    }

//    //UNITY ADS
//    void AdFinished(ShowResult result)
//    {
//        if (result == ShowResult.Finished)
//        {
//            // Reward the player
//            noRewardVideo.SetActive(false);
//        }
//    }

//    public void ButtonWasPressed()
//    {
//        InterfaceManagerMenu.instance.nameText.text = "Estrellas x1000";
//        InterfaceManagerMenu.instance.descriptionText.text = "Puedes reclamar 1000 estrellas por ver unos cortos videos publicitarios";
//        //ShowAd();
//        //SI HAY ADMOB
//        if (rewardBasedVideo.IsLoaded())
//        {
//            rewardBasedVideo.Show();
//        }
//        /*else
//        {
//           if (Chartboost.hasRewardedVideo(CBLocation.Default))
//            {
//                Chartboost.showRewardedVideo(CBLocation.Default);
//                Chartboost.cacheRewardedVideo(CBLocation.Default);
//            }*/
//        else
//        {
//            Debug.Log("No hay publicidad");
//            noRewardVideo.SetActive(true);
//            //ShowAd();
//        }
//        //}
//    }
//}
