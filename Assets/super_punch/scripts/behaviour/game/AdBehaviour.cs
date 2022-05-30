using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

/// <summary>
/// Available Ad systems.
/// None 			- No ads.
/// UnityAds 		- UnityAds Interstitial.
/// AdmobManager 	- Admob Banner 320x50px & Interstital.
/// MixedMode 		- Admob Banner 320x50px  & UnityAds Interstital.
/// </summary>
public enum AdSystems
{
    none = 0,
    unityAds = 1,
    AdmobManager = 2,
    MixedMode = 3,
}
public class AdBehaviour : MonoBehaviour {
    
}
