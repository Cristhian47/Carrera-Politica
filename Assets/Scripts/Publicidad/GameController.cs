using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    //VARIABLES GAMECONTROLLER
    public static GameController instance;        //Accede a si mismo de forma estatica
    //public Text quatzQuantityText;
    private int quartz;

    private void Awake(){
        // rutina para evitar multiples instancias del singleton
		if (GameController.instance == null) {
			GameController.instance = this;
		} else if(GameController.instance != this){
			Destroy (gameObject);
		}
    }

    /*public void GiveReward(){
        quartz += 10;
        quatzQuantityText.text = quartz.ToString();
    }*/

    public void GiveReward()
    {
        GameManager.instance.data.stars += 1000;
    }
}
