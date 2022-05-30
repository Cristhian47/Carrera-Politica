using UnityEngine;
using System.Collections;

namespace game_core
{

	/// <summary>
	/// Available Ad systems.
	/// None 			- No ads.
	/// AdmobManager 	- Admob Banner 320x50px & Interstital.
	/// </summary>
	public enum AdSystems
	{
		none = 0,
		//unityAds		= 	1,
		AdmobManager = 2,
		//MixedMode		=	3,
	}

	/// <summary>
	/// Splash behaviour.
	/// </summary>
	public class SplashBehaviour : MonoBehaviour
	{


	}
}