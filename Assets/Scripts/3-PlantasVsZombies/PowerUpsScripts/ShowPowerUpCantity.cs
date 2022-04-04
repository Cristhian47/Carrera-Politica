using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowPowerUpCantity : MonoBehaviour
{
    public Text textoCantidad;

    void Update()
    {
        textoCantidad.text = GameManager.instance.data.cantityOfPowerUpsThree.ToString();
    }
}
