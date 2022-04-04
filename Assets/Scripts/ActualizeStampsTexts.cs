using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActualizeStampsTexts : MonoBehaviour
{
    public Text starsText;


    private void OnEnable()
    {
        ActualizeData();
    }

    public void ActualizeData()
    {
        starsText.text = GameManager.instance.data.stars.ToString();
    }
}
