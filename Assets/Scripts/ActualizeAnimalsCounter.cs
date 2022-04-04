using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActualizeAnimalsCounter : MonoBehaviour
{
    public Text elephantText;
    public Text presidentText;
    public Text lizardText;
    public Text monkeyText;
    public Text ratText;
    public Text serafinText;

    //Actualiza los textos por los contadores de animales obtenidos
    private void OnEnable() {
        elephantText.text = GameManager.instance.data.elephantsCaptured.ToString();
        presidentText.text = GameManager.instance.data.presidentsCaptured.ToString();
        lizardText.text = GameManager.instance.data.lizardsCaptured.ToString();
        monkeyText.text = GameManager.instance.data.monkeysCaptured.ToString();
        ratText.text = GameManager.instance.data.ratsCaptured.ToString();
        serafinText.text = GameManager.instance.data.serafinsCaptured.ToString();

    }
}
