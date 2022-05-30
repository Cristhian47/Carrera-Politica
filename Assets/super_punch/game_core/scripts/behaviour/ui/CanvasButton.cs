﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
namespace game_core{
/// <summary>
/// Canvas button class.
/// </summary>
public class CanvasButton : ButtonBehaviour {
	public bool				saveId		=	false;
	public string			sceneName	= "1-MainMenu";
	public int				buttonID	=	0;
	public AudioClip 		soundEffect;

	/// <summary>
	/// Raises the mouse down event.
	/// </summary>
	protected override void action()
	{
		if(saveId)				{	SettingsManager.selectedID	=	buttonID;}
		if(soundEffect!=null)	{ 	SoundManager.play(soundEffect);}
		if(sceneName == "1-MainMenu")
			GameManager.instance.CanvasMainMenu.SetActive(true);
		LevelManager.Load (sceneName);
	}
}
}