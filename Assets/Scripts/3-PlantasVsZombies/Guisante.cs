using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guisante : MonoBehaviour
{
    public float velocidad = 10;
    public int daño = 1;

    public bool isOnFire;
    public bool isOnIce;
    public float slowDuration;

    private void Update()
    {
        transform.position += Vector3.right * velocidad * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.gameObject.tag == "Animal")
        {
            GameManager.instance.data.animalsCaptured++;
            PlantsVsZombiesManager.instance.animalsObtained++;

            if (collision.transform.name == "Elefante")
                GameManager.instance.data.elephantsCaptured++;
            else if (collision.transform.name == "Lagarto")
                GameManager.instance.data.lizardsCaptured++;
            else if (collision.transform.name == "Mico")
                GameManager.instance.data.monkeysCaptured++;
            else if (collision.transform.name == "Presidente")
                GameManager.instance.data.presidentsCaptured++;
            else if (collision.transform.name == "Rata")
                GameManager.instance.data.ratsCaptured++;
            else if (collision.transform.name == "Serafin")
                GameManager.instance.data.serafinsCaptured++;

            Destroy(collision.transform.parent.gameObject);
        }
    }
}
