using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PVZTutorial : MonoBehaviour
{
    public GameObject imagenGlobo1;        //Globo hacia la derecha
    public GameObject daniel1;          //Daniel hacia la derecha
    public GameObject imagenGlobo2;         //Globo hacia la izquierda
    public GameObject daniel2;          //Daniel hacia la izquierda
    public GameObject flechaEstrellas;          //Flecha que señala a las estrellas
    public GameObject estrellas;            //Seccion donde se visualizan las estrellas que se tienen
    public GameObject flechaCorazones;          //Flecha que señala a los corazones
    public GameObject corazones;            //Seccion donde se visualizan los corazones que se tienen

    public GameObject imagenGlobo3;         //Globo de los textos de las mejoras
    public GameObject daniel3;          //daniel mejoras
    public GameObject flechaMejoras;            //Flecha que señala a las mejoras
    public GameObject mejoras;          //Botones de los power ups

    public GameObject flechaSoles;          //Flecha que señala a los soles
    public GameObject soles;            //Field de los soles

    public GameObject flechaCartas;         //Flecha que señala las cartas de el pueblo

    public GameObject cartas;           //Cartas de las plantas

    public GameObject panelTutorial;            //Panel del tutorial

    public GameObject botonLider;           //Boton del generador de soles
    public GameObject botonDaniel;          //Boton del lanza guisantes

    public GameObject flechaLider;          //Flecha que señala el lider generador de soles
    public GameObject flechaPlantarLider;
    public GameObject flechaDaniel;          //Flecha que señala a daniel lanza guisantes
    public GameObject flechaPlantarDaniel;

    public GameObject celdaLider;
    public GameObject celdaDaniel;

    public IEnumerator Start() {

        imagenGlobo1.SetActive(true);
        daniel1.SetActive(true);
        imagenGlobo1.transform.GetChild(0).gameObject.SetActive(true);
        Debug.Log("Bien");
        yield return new WaitForSeconds(3);
        imagenGlobo1.transform.GetChild(0).gameObject.SetActive(false);
        imagenGlobo1.transform.GetChild(1).gameObject.SetActive(true);
        Debug.Log("Bien2");
        yield return new WaitForSeconds(5f);
        imagenGlobo1.transform.GetChild(1).gameObject.SetActive(false);
        imagenGlobo1.transform.GetChild(2).gameObject.SetActive(true);
        Debug.Log("Bien3");
        yield return new WaitForSeconds(3);
        imagenGlobo1.SetActive(false);
        daniel1.SetActive(false);
        imagenGlobo1.transform.GetChild(2).gameObject.SetActive(false);
        imagenGlobo2.SetActive(true);
        daniel2.SetActive(true);
        imagenGlobo2.transform.GetChild(0).gameObject.SetActive(true);
        flechaEstrellas.SetActive(true);
        estrellas.SetActive(true);
        Debug.Log("Bien4");
        yield return new WaitForSeconds(3);
        imagenGlobo2.transform.GetChild(0).gameObject.SetActive(false);
        flechaEstrellas.SetActive(false);
        estrellas.SetActive(false);
        flechaCorazones.SetActive(true);
        corazones.SetActive(true);
        imagenGlobo2.transform.GetChild(1).gameObject.SetActive(true);
        Debug.Log("Bien5");
        yield return new WaitForSeconds(3);
        imagenGlobo2.transform.GetChild(1).gameObject.SetActive(false);
        imagenGlobo2.transform.GetChild(2).gameObject.SetActive(true);
        Debug.Log("Bien6");
        yield return new WaitForSeconds(5f);
        imagenGlobo2.transform.GetChild(2).gameObject.SetActive(false);
        flechaCorazones.SetActive(false);
        //Flecha y botones powerups
        flechaMejoras.SetActive(true);
        mejoras.SetActive(true);
        corazones.SetActive(false);
        imagenGlobo2.SetActive(false);
        daniel2.SetActive(false);
        imagenGlobo3.SetActive(true);
        daniel3.SetActive(true);
        imagenGlobo3.transform.GetChild(0).gameObject.SetActive(true);
        Debug.Log("Bien7");
        yield return new WaitForSeconds(5);
        imagenGlobo3.transform.GetChild(0).gameObject.SetActive(false);
        imagenGlobo3.transform.GetChild(1).gameObject.SetActive(true);
        //Muestra los power ups
        yield return new WaitForSeconds(3);
        imagenGlobo2.SetActive(true);
        daniel2.SetActive(true);
        imagenGlobo3.transform.GetChild(1).gameObject.SetActive(false);
        imagenGlobo3.SetActive(false);
        imagenGlobo2.transform.GetChild(3).gameObject.SetActive(true);
        flechaSoles.SetActive(true);
        daniel3.SetActive(false);
        flechaMejoras.SetActive(false);
        soles.SetActive(true);
        yield return new WaitForSeconds(4);
        soles.SetActive(false);
        imagenGlobo2.transform.GetChild(3).gameObject.SetActive(false);
        imagenGlobo2.transform.GetChild(4).gameObject.SetActive(true);
        flechaSoles.SetActive(false);
        flechaCartas.SetActive(true);
        cartas.SetActive(true);
        yield return new WaitForSeconds(3);
        panelTutorial.SetActive(false);
        cartas.SetActive(false);
        botonDaniel.GetComponent<Button>().enabled = false;
        EventTrigger trigger = botonDaniel.GetComponent<EventTrigger>();
        trigger.enabled = false;
        //Destroy(botonDaniel.GetComponent<EventTrigger>());
        flechaCartas.SetActive(false);
        flechaLider.SetActive(true);
        flechaPlantarLider.SetActive(true);
        celdaLider.SetActive(true);
        imagenGlobo2.transform.GetChild(4).gameObject.SetActive(false);
        imagenGlobo2.transform.GetChild(5).gameObject.SetActive(true);
        daniel2.transform.position = new Vector2(daniel2.transform.position.x + 145, daniel2.transform.position.y);
        imagenGlobo2.transform.position = new Vector2(imagenGlobo2.transform.position.x + 145, imagenGlobo2.transform.position.y);

        while (!PVZManagerTutorial.instance.LiderWasPressed) {
            yield return null;
        }

        imagenGlobo2.transform.GetChild(5).gameObject.SetActive(false);
        imagenGlobo2.transform.GetChild(6).gameObject.SetActive(true);
        flechaLider.SetActive(false);
        flechaPlantarLider.SetActive(false);
        celdaDaniel.SetActive(true);
        botonLider.GetComponent<Button>().enabled = false;
        EventTrigger trigger2 = botonLider.GetComponent<EventTrigger>();
        trigger2.enabled = false;

        yield return new WaitForSeconds(3);

        PVZManagerTutorial.instance.InstantiateZombieTutorial();
        imagenGlobo2.transform.GetChild(6).gameObject.SetActive(false);
        imagenGlobo2.SetActive(false);
        daniel2.SetActive(false);
        daniel1.SetActive(true);
        imagenGlobo1.SetActive(true);
        imagenGlobo1.transform.GetChild(3).gameObject.SetActive(true);

        yield return new WaitForSeconds(3);
        imagenGlobo1.transform.GetChild(3).gameObject.SetActive(false);
        imagenGlobo2.SetActive(true);
        daniel2.SetActive(true);
        daniel1.SetActive(false);
        imagenGlobo1.SetActive(false);
        imagenGlobo2.transform.GetChild(7).gameObject.SetActive(true);
        flechaDaniel.SetActive(true);
        flechaPlantarDaniel.SetActive(true);
        trigger.enabled = true;

        while (!PVZManagerTutorial.instance.DanielWasPressed)
        {
            yield return null;
        }
        imagenGlobo2.transform.GetChild(7).gameObject.SetActive(false);
        daniel2.SetActive(false);
        imagenGlobo2.SetActive(false);
        flechaDaniel.SetActive(false);
        flechaPlantarDaniel.SetActive(false);
        trigger.enabled = false;
        while (PVZManagerTutorial.instance.zombie.life > 0)
        {
            yield return null;
        }
        daniel2.SetActive(true);
        imagenGlobo2.SetActive(true);
        imagenGlobo2.transform.GetChild(8).gameObject.SetActive(true);
        yield return new WaitForSeconds(3);
        imagenGlobo2.transform.GetChild(8).gameObject.SetActive(false);
        imagenGlobo2.transform.GetChild(9).gameObject.SetActive(true);
        yield return new WaitForSeconds(3);

        StartCoroutine(ChargeMainScene());

        //botonDaniel.AddComponent<EventTrigger>();
        //botonDaniel.GetComponent<EventTrigger>() = trigger;
        Debug.Log("Bien8");

    }

    

    private IEnumerator ChargeMainScene()
    {
        GameManager.instance.tutorialObject.transform.parent.gameObject.SetActive(true);
        AsyncOperation scene = SceneManager.LoadSceneAsync("1-MainMenu");
        //GameManager.instance.loadingCanvas.SetActive(true);
        GameManager.instance.isChargingScene = true;

        while (!scene.isDone)
            yield return null;

        GameManager.instance.isChargingScene = false;
        GameManager.instance.SetSound(true);
        GameManager.instance.loadingCanvas.SetActive(false);
        GameManager.instance.tutorialObject.GetComponentInParent<Canvas>().gameObject.SetActive(true);
    }

    public void SkipTutorial() {

        StartCoroutine(ChargeMainScene());
    }
}
