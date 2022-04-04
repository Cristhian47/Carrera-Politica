using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProfileData : MonoBehaviour
{
    private void OnEnable()
    {
        GameObject datas = transform.GetChild(3).gameObject;

        datas.transform.GetChild(0).GetComponent<Text>().text = "Veces que ha entrado al juego: "
            + GameManager.instance.data.timesEntered;

        datas.transform.GetChild(1).GetComponent<Text>().text = "Estrellas obtenidas: "
            + GameManager.instance.data.starsObtained;

        datas.transform.GetChild(2).GetComponent<Text>().text = "Corazones Usados: "
            + GameManager.instance.data.heartsUsed;

        /*datas.transform.GetChild(3).GetComponent<Text>().text = "Ayudantes 1 usados: "
            + GameManager.instance.data.firstPowerUpUsed;

        datas.transform.GetChild(4).GetComponent<Text>().text = "Ayudantes 2 usados: "
            + GameManager.instance.data.secondPowerUpUsed;

        datas.transform.GetChild(5).GetComponent<Text>().text = "Ayudantes 3 usados: "
            + GameManager.instance.data.thirdPowerUpUsed;*/
    }
}
