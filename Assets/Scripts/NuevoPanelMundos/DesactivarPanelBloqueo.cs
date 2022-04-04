using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DesactivarPanelBloqueo : MonoBehaviour
{
    public int numeroMinijuego;
    public GameObject botonJugar;
    private void OnEnable()
    {
        if (numeroMinijuego == 1 && GameManager.instance.data.haveWorldTwoGameOne)
        {
            botonJugar.SetActive(true);
            gameObject.SetActive(false);
        }
        else if(numeroMinijuego == 2 && GameManager.instance.data.haveWorldTwoGameTwo)
        {
            botonJugar.SetActive(true);
            gameObject.SetActive(false);

        }
        else
        {
            botonJugar.SetActive(false);
        }


    }

    private void OnDisable()
    {
        botonJugar.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
