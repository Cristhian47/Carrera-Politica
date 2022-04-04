using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActualizeItems : MonoBehaviour
{
    public Text heartsText;
    public Text starsText;
    public Text powerUpOneText;
    public Text powerUpTwoText;
    public Text powerUpThreeText;

    public static ActualizeItems instance;

    private void Awake()
    {
        //if (ActualizeItems.instance == null)
            //ActualizeItems.instance = this;
        //else if(ActualizeItems.instance != null)
          //  Destroy(gameObject);
    }

    private void OnEnable()
    {
        ActualizeDatas();
    }

    public void ActualizeDatas()
    {
        heartsText.text = GameManager.instance.data.hearts.ToString();
        starsText.text = GameManager.instance.data.stars.ToString();
        powerUpOneText.text = GameManager.instance.data.cantityOfPowerUpsOne.ToString();
        powerUpTwoText.text = GameManager.instance.data.cantityOfPowerUpsTwo.ToString();
        powerUpThreeText.text = GameManager.instance.data.cantityOfPowerUpsThree.ToString();
    }
}
