using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimatedText : MonoBehaviour
{

    //Tiempo que tarda en poner cada letra
    public float letterPaused = 0.01f;
    //Array de textos que se mostraran
    public string[] message;

    //componente texto en el que se mostraran los mensajes
    public Text textComp;
    //Objeto que indica que pulsar para continuar
    public GameObject enter;
    //Objeto que posee todos los elementos del tutorial
    public GameObject tutorialCanvas;

    public ButtonsOfTutorial buttonsObjects;

    //esta variable verifica si puede continuar con la siguiente posicion del vector
    private bool checkNext = false;
    //Posiciona la linea actual en la que se encuentra el vector
    private int currentLine = 0;

    private void Start()
    {
        //Inicializa el texto como una cadena vacia
        textComp.text = "";
        //Inicia la corrutina para empezar a poner los textos
        StartCoroutine(TypeText(currentLine));
    }

    private void Update()
    {
        //Si se puede continuar
        if (checkNext)
        {
            //Activa la indicacion de que tecla pulsar
            enter.SetActive(true);
        }
        else
        {
            //Si no, pone la indicacion como falsa
            enter.SetActive(false);
        }

        if(!checkNext && Input.GetMouseButtonDown(0))
        {
            textComp.text = message[currentLine];
            StopAllCoroutines();
            checkNext = true;
        }
        else
        {
            //Verifica si la linea actual es menor que la cantidad de casillas del vector
            // y se pulsa el click, continua con la siguiente posicion
            if (currentLine < message.Length - 1 && checkNext && Input.GetMouseButtonDown(0))
            {
                //Suma a la siguiente posicion del vector
                currentLine++;

                //No puede cambiar de linea
                checkNext = false;
                //Pone la cadena como vacia
                textComp.text = "";

                //Inicia la corrutina con la siguiente cadena del vector
                StartCoroutine(TypeText(currentLine));
            }
            else if (currentLine >= message.Length - 1 && checkNext && Input.GetMouseButtonDown(0))
            {
                textComp.text = "";
                currentLine = -1;
                //checkNext = false;
                checkNext = true;
                tutorialCanvas.SetActive(false);
            }
        }

        
    }

    private IEnumerator TypeText(int line)
    {
        //if (line == 1) buttonsObjects.storeButton.SetActive(true);
        //if (line == 2) buttonsObjects.networksButton.SetActive(true);

        //Saca la letra siguiente y convierte la cadena a un array de caracteres
        foreach (char letter in message[line].ToCharArray())
        {
            //Pone en el texto la letra siguiente
            textComp.text += letter;

            //Devuelve 0
            yield return 0;
            //Tarda un tiempo estimado hasta volver a imprimir la siguiente letra
            yield return new WaitForSeconds(letterPaused);
        }

        //Verifica que puede seguir con la siguiente posicion del vector de cadenas
        checkNext = true;
    }

    public void SkipTutorial(){
      textComp.text = "";
      currentLine = -1;
      //checkNext = false;
      checkNext = true;
      tutorialCanvas.SetActive(false);
    }

    public int GetCurrentLine()
    {
        return currentLine;
    }

    public int GetLastLine()
    {
        return message.Length - 1;
    }

    public bool GetCheckNext()
    {
        return checkNext;
    }

   /* private void OnEnable()
    {
        currentLine = 0;
        textComp.text = "";
        checkNext = false;
        //StartCoroutine(TypeText(currentLine));
    }*/
}

[System.Serializable]
public class ButtonsOfTutorial
{
    public GameObject storeButton;
    public GameObject networksButton;
}
