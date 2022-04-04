using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActualizeProfileData : MonoBehaviour
{
    public Text starsObtainedText;
    public Text animalsCapturedText;
    public Text powerUpsUsedText;
    public Text gameOneScoreText;
    public Text gameTwoScoreText;

    private void OnEnable(){

        starsObtainedText.text = (GameManager.instance.data.starsObtained).ToString();
        animalsCapturedText.text = (GameManager.instance.data.animalsCaptured).ToString();
        powerUpsUsedText.text = (GameManager.instance.data.powerUpsUsed).ToString();

        gameOneScoreText.text = (GameManager.instance.data.firstGameScore).ToString();
        gameTwoScoreText.text = (GameManager.instance.data.secondGameScore).ToString();
    }
}
