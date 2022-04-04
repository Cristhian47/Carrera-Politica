using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayingTime : MonoBehaviour
{
    private float currentTime = 0.0f;

    public Text timeText;

    private void Awake()
    {
        currentTime = 0.0f;
    }

    void Update()
    {
        currentTime += Time.deltaTime;
        timeText.text = ((int)currentTime).ToString();
        PlantsVsZombiesManager.instance.currentTime = (int)currentTime;
    }
}
