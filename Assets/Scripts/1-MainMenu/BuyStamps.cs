using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[Serializable]
public class Stamp
{
    public Button buyStampButton;
    public GameObject stampPreVisualization;
    public GameObject stampPanel;
};

public class BuyStamps : MonoBehaviour
{
    public Stamp[] buyStampsButtons;
    public GameObject panelBuyConfirmation;

    public int[] prices;

    [Space(20)]
    public ActualizeStampsTexts textsActualizer;

    private void Start()
    {
        EnablePreVisualization();

    }

    private void OnEnable()
    {

        if (!GameManager.instance.data.haveStampTwo)
        {
            buyStampsButtons[1].buyStampButton.GetComponentInChildren<Text>().text = prices[1].ToString();
            buyStampsButtons[1].stampPreVisualization.SetActive(false);
        }
        if (!GameManager.instance.data.haveStampThree)
        {
            buyStampsButtons[2].buyStampButton.GetComponentInChildren<Text>().text = prices[2].ToString();
            buyStampsButtons[2].stampPreVisualization.SetActive(false);
        }
        if (!GameManager.instance.data.haveStampFour)
        {
            buyStampsButtons[3].buyStampButton.GetComponentInChildren<Text>().text = prices[3].ToString();
            buyStampsButtons[3].stampPreVisualization.SetActive(false);
        }
        if (!GameManager.instance.data.haveStampFive)
        {
            buyStampsButtons[4].buyStampButton.GetComponentInChildren<Text>().text = prices[4].ToString();
            buyStampsButtons[4].stampPreVisualization.SetActive(false);
        }
        if (!GameManager.instance.data.haveStampSix)
        {
            buyStampsButtons[5].buyStampButton.GetComponentInChildren<Text>().text = prices[5].ToString();
            buyStampsButtons[5].stampPreVisualization.SetActive(false);
        }
        if (!GameManager.instance.data.haveStampSeven)
        {
            buyStampsButtons[6].buyStampButton.GetComponentInChildren<Text>().text = prices[6].ToString();
            buyStampsButtons[6].stampPreVisualization.SetActive(false);
        }
        if (!GameManager.instance.data.haveStampEight)
        {
            buyStampsButtons[7].buyStampButton.GetComponentInChildren<Text>().text = prices[7].ToString();
            buyStampsButtons[7].stampPreVisualization.SetActive(false);
        }
    }

    private void EnablePreVisualization()
    {
        if (GameManager.instance.data.haveStampTwo)
        {
            buyStampsButtons[1].stampPreVisualization.SetActive(true);
            buyStampsButtons[1].buyStampButton.GetComponentInChildren<Text>().text = "Ver";
        }
        if (GameManager.instance.data.haveStampThree)
        {
            buyStampsButtons[2].stampPreVisualization.SetActive(true);
            buyStampsButtons[2].buyStampButton.GetComponentInChildren<Text>().text = "Ver";
        }
        if (GameManager.instance.data.haveStampFour)
        {
            buyStampsButtons[3].stampPreVisualization.SetActive(true);
            buyStampsButtons[3].buyStampButton.GetComponentInChildren<Text>().text = "Ver";
        }
        if (GameManager.instance.data.haveStampFive)
        {
            buyStampsButtons[4].stampPreVisualization.SetActive(true);
            buyStampsButtons[4].buyStampButton.GetComponentInChildren<Text>().text = "Ver";
        }
        if (GameManager.instance.data.haveStampSix)
        {
            buyStampsButtons[5].stampPreVisualization.SetActive(true);
            buyStampsButtons[5].buyStampButton.GetComponentInChildren<Text>().text = "Ver";
        }
        if (GameManager.instance.data.haveStampSeven)
        {
            buyStampsButtons[6].stampPreVisualization.SetActive(true);
            buyStampsButtons[6].buyStampButton.GetComponentInChildren<Text>().text = "Ver";
        }
        if (GameManager.instance.data.haveStampEight)
        {
            buyStampsButtons[7].stampPreVisualization.SetActive(true);
            buyStampsButtons[7].buyStampButton.GetComponentInChildren<Text>().text = "Ver";
        }
    }

    public void ShowOrBuy(int currentIndex)
    {
        //Validation(GameManager.instance.data.haveStampOne, buttonIndex);

        if (currentIndex == 0)
        {
            Debug.Log("Eso es!");
            buyStampsButtons[0].stampPanel.SetActive(true);
            panelBuyConfirmation.SetActive(false);
            //Validation(GameManager.instance.data.haveStampOne, 0);
        }
            
        else if(currentIndex == 1)
            Validation(GameManager.instance.data.haveStampTwo, 1);
        else if (currentIndex == 2)
            Validation(GameManager.instance.data.haveStampThree, 2);
        else if (currentIndex == 3)
            Validation(GameManager.instance.data.haveStampFour, 3);
        else if (currentIndex == 4)
            Validation(GameManager.instance.data.haveStampFive, 4);
        else if (currentIndex == 5)
            Validation(GameManager.instance.data.haveStampSix, 5);
        else if (currentIndex == 6)
            Validation(GameManager.instance.data.haveStampSeven, 6);
        else if (currentIndex == 7)
            Validation(GameManager.instance.data.haveStampEight, 7);
    }

    private void Validation(bool haveStamp, int currentIndex)
    {
        /*if(buyStampsButtons[buttonIndex].buyStampButton.gameObject.GetComponent<EventTrigger>() == null)
            buyStampsButtons[buttonIndex].buyStampButton.gameObject.AddComponent<EventTrigger>();
        EventTrigger trigger = buyStampsButtons[buttonIndex].buyStampButton.gameObject.GetComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerDown;*/
        Debug.Log("Vamos bien!");
        Button but = buyStampsButtons[currentIndex].buyStampButton;
        but.onClick.RemoveAllListeners();

        if (haveStamp)
        {
            Debug.Log("SIIIUUUUUUUUUUUUUUUUU");
            
            //but.onClick.AddListener(() => { buyStampsButtons[buttonIndex].stampPanel.SetActive(true); });
            buyStampsButtons[currentIndex].stampPanel.SetActive(true);
            panelBuyConfirmation.SetActive(false);
            //entry.callback.AddListener((eventData) => { buyStampsButtons[buttonIndex].stampPanel.SetActive(true); });
            //Puede ver la estampa
        }
        else
        {
            if (GameManager.instance.data.stars >= prices[currentIndex])
            {
                bool alreadyPayed = false;

                panelBuyConfirmation.transform.GetChild(0).GetChild(1).GetComponent<Button>().onClick.RemoveAllListeners();

                panelBuyConfirmation.SetActive(true);
                panelBuyConfirmation.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = "¿Desea comprar este objeto por " + prices[currentIndex] + " estrellas?";
                Debug.Log(panelBuyConfirmation.transform.GetChild(0).GetChild(1).name);
                panelBuyConfirmation.transform.GetChild(0).GetChild(1).GetComponent<Button>().onClick.AddListener(() => { if (!alreadyPayed)
                    {
                        Debug.Log("a vver si entra xd");
                        GameManager.instance.data.stars -= prices[currentIndex];
                        alreadyPayed = true;
                    }
                     });

                panelBuyConfirmation.transform.GetChild(0).GetChild(1).GetComponent<Button>().onClick.AddListener(() => { GameManager.instance.ActualizeData(); });
                panelBuyConfirmation.transform.GetChild(0).GetChild(1).GetComponent<Button>().onClick.AddListener(() => { GameManager.instance.gameObject.GetComponent<AudioSource>().Play(); });
                panelBuyConfirmation.transform.GetChild(0).GetChild(1).GetComponent<Button>().onClick.AddListener(() => { UnlockStamp(currentIndex); });
                panelBuyConfirmation.transform.GetChild(0).GetChild(1).GetComponent<Button>().onClick.AddListener(() => { EnablePreVisualization(); });
                panelBuyConfirmation.transform.GetChild(0).GetChild(1).GetComponent<Button>().onClick.AddListener(() => { panelBuyConfirmation.SetActive(false); });
                panelBuyConfirmation.transform.GetChild(0).GetChild(1).GetComponent<Button>().onClick.AddListener(() => { textsActualizer.ActualizeData(); });
                panelBuyConfirmation.transform.GetChild(0).GetChild(1).GetComponent<Button>().onClick.AddListener(() => { /*Desbloquear la imagen de la estampa*/ });
                //panelBuyConfirmation.transform.GetChild(0).GetChild(1).GetComponent<Button>().onClick.AddListener(() => { transform.GetChild(0).GetChild(0).GetChild(5).GetChild(0).GetComponent<Text>().text = "Ver"; });
                //panelBuyConfirmation.transform.GetChild(0).GetChild(1).GetComponent<Button>().onClick.AddListener(() => { buyStampsButtons[currentIndex].buyStampButton.GetComponentInChildren<Text>().text = "Ver"; });
                
            }
            else
            {
                Debug.Log("No puedes comprar este objeto... pobre!");
            }
           

            //Puede comprar la estampa
        }
    }

    private void UnlockStamp(int currentIndex)
    {
        if (currentIndex == 0)
            GameManager.instance.data.haveStampOne = true;
        else if (currentIndex == 1)
            GameManager.instance.data.haveStampTwo = true;
        else if (currentIndex == 2)
            GameManager.instance.data.haveStampThree = true;
        else if (currentIndex == 3)
            GameManager.instance.data.haveStampFour = true;
        else if (currentIndex == 4)
            GameManager.instance.data.haveStampFive = true;
        else if (currentIndex == 5)
            GameManager.instance.data.haveStampSix = true;
        else if (currentIndex == 6)
            GameManager.instance.data.haveStampSeven = true;
        else if (currentIndex == 7)
            GameManager.instance.data.haveStampEight = true;
    }
}
