using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class StoreItem : MonoBehaviour
{
    //private GameObject confirmationCanvasAuxiliary;
    //private Button confirmationButtonAuxiliary;
    //private Text confirmationTextAuxiliary;

    public int cost;
    public string TituloDescripcion;
    public string NombreDescripcion;
    public string Descripcion;

    public GameObject buyConfirmationCanvas;
    public Button confirmationButton;
    public Text confirmationText;

    public GameObject noStarsCanvas;
    //public Button claimStarsButton;
    public UnityEvent functionToExecute;

    public Text costText;
    [Space(20)]

    public bool isCharacter;
    public int characterIndex;

    [Space(20)]

    public bool isWorld;
    public int worldIndexInStore;

    [Space(20)]

    public bool isCloth;
    public int clothIndex;

    private void Start()
    {
        if(costText != null)
        {
            costText.text = cost.ToString();
        }
        
    }

    private void OnEnable()
    {
        if (!GameManager.instance.data.haveCharacterOne)
        {
            //activeBuyCanvas.Invoke();
            GameManager.instance.data.haveCharacterOne = true;
            GameManager.instance.ActualizeData();
            //Desbloquea personaje
        }

        StartCharactersState();
        StartClothsState();
        StartWorldState();


        //Habilita prendas de ropa

        StartUsedClothes();
    }


    public void BuyOrUse()
    {
        if (cost <= GameManager.instance.data.stars)
        {
            buyConfirmationCanvas.SetActive(true);
            confirmationText.text = "¿Deseas comprar este objeto por " + cost + " estrellas?";

            GameObject cancelButton = GameObject.Find("CancelButton");
            cancelButton.GetComponent<Button>().onClick.RemoveAllListeners();
            cancelButton.GetComponent<Button>().onClick.AddListener(() => { buyConfirmationCanvas.SetActive(false); });

            confirmationButton.onClick.RemoveAllListeners();
            confirmationButton.onClick.AddListener(() => { functionToExecute.Invoke(); });
            confirmationButton.onClick.AddListener(() => { GameManager.instance.gameObject.GetComponent<AudioSource>().Play(); });
            confirmationButton.onClick.AddListener(() => { GameManager.instance.data.stars -= cost; });
            confirmationButton.onClick.AddListener(() => { GameManager.instance.SaveChanges(); });
            confirmationButton.onClick.AddListener(() => { GameManager.instance.ActualizeData(); });
            confirmationButton.onClick.AddListener(() => { buyConfirmationCanvas.SetActive(false); });
            confirmationButton.onClick.AddListener(() => { GameManager.instance.storeActualizeItems.ActualizeDatas(); });
            if (isCloth)
            {
                confirmationButton.onClick.AddListener(() => { transform.GetChild(1).gameObject.SetActive(false); });
                confirmationButton.onClick.AddListener(() => { transform.GetChild(2).gameObject.SetActive(true); });
            }
            if (isWorld)
            {
                confirmationButton.onClick.AddListener(() => { transform.GetChild(1).gameObject.SetActive(false); });
                confirmationButton.onClick.AddListener(() => { transform.GetChild(2).gameObject.SetActive(true); });
            }
            if (isCharacter)
            {
                confirmationButton.onClick.AddListener(() => { transform.GetChild(1).gameObject.SetActive(false); });
                confirmationButton.onClick.AddListener(() => { transform.GetChild(2).gameObject.SetActive(true); });
            }

        }
        else
        {
            Debug.Log("Estrellas insuficientes");
            noStarsCanvas.SetActive(true);

            Button noClaimStarsButton = GameObject.Find("CancelButton").GetComponent<Button>();
            noClaimStarsButton.onClick.RemoveAllListeners();
            noClaimStarsButton.onClick.AddListener(() => { noStarsCanvas.SetActive(false); });

            Button claimStarsButton = GameObject.Find("ConfirmButton").GetComponent<Button>();
            claimStarsButton.onClick.RemoveAllListeners();
            claimStarsButton.onClick.AddListener(() => { noStarsCanvas.SetActive(false); });

        }
    }

    public void RestartUsedClothes(int index)
    {
        transform.GetChild(3).gameObject.SetActive(false);
        GameManager.instance.clothesUsed[index] = false;
    }

    public void StartUsedClothes()
    {

        if (GameManager.instance.data.useClothOne && clothIndex == 1)
        {
            transform.GetChild(1).gameObject.SetActive(false);

            GameManager.instance.clothesUsed[clothIndex - 1] = true;

            transform.GetChild(2).gameObject.SetActive(false);
            transform.GetChild(3).gameObject.SetActive(true);
        }
        if (GameManager.instance.data.useClothTwo && clothIndex == 2)
        {
            transform.GetChild(1).gameObject.SetActive(false);

            GameManager.instance.clothesUsed[clothIndex - 1] = true;

            transform.GetChild(2).gameObject.SetActive(false);
            transform.GetChild(3).gameObject.SetActive(true);
        }
        if (GameManager.instance.data.useClothThree && clothIndex == 3)
        {
            transform.GetChild(1).gameObject.SetActive(false);

            GameManager.instance.clothesUsed[clothIndex - 1] = true;

            transform.GetChild(2).gameObject.SetActive(false);
            transform.GetChild(3).gameObject.SetActive(true);
        }
        if (GameManager.instance.data.useClothFour && clothIndex == 4)
        {
            transform.GetChild(1).gameObject.SetActive(false);

            GameManager.instance.clothesUsed[clothIndex - 1] = true;

            transform.GetChild(2).gameObject.SetActive(false);
            transform.GetChild(3).gameObject.SetActive(true);
        }
        if (GameManager.instance.data.useClothFive && clothIndex == 5)
        {
            transform.GetChild(1).gameObject.SetActive(false);

            GameManager.instance.clothesUsed[clothIndex - 1] = true;

            transform.GetChild(2).gameObject.SetActive(false);
            transform.GetChild(3).gameObject.SetActive(true);
        }
        if (GameManager.instance.data.useClothSix && clothIndex == 6)
        {
            transform.GetChild(1).gameObject.SetActive(false);

            GameManager.instance.clothesUsed[clothIndex - 1] = true;

            transform.GetChild(2).gameObject.SetActive(false);
            transform.GetChild(3).gameObject.SetActive(true);
        }

        
    }

    private void StartClothsState()
    {
        if (isCloth)
        {

            transform.GetChild(1).gameObject.SetActive(true);
            transform.GetChild(2).gameObject.SetActive(false);
            //transform.GetChild(3).gameObject.SetActive(false);

            if (GameManager.instance.data.haveClothOne && clothIndex == 1)
            {
                transform.GetChild(1).gameObject.SetActive(false);

                if (!transform.GetChild(3).gameObject.activeInHierarchy)
                    transform.GetChild(2).gameObject.SetActive(true);
                

            }
            if(GameManager.instance.data.haveClothTwo && clothIndex == 2)
            {
                transform.GetChild(1).gameObject.SetActive(false);

                if (!transform.GetChild(3).gameObject.activeInHierarchy)
                    transform.GetChild(2).gameObject.SetActive(true);
            }
            if (GameManager.instance.data.haveClothThree && clothIndex == 3)
            {
                transform.GetChild(1).gameObject.SetActive(false);

                if (!transform.GetChild(3).gameObject.activeInHierarchy)
                    transform.GetChild(2).gameObject.SetActive(true);
            }
            if (GameManager.instance.data.haveClothFour && clothIndex == 4)
            {
                transform.GetChild(1).gameObject.SetActive(false);

                if (!transform.GetChild(3).gameObject.activeInHierarchy)
                    transform.GetChild(2).gameObject.SetActive(true);
            }
            if (GameManager.instance.data.haveClothFive && clothIndex == 5)
            {
                transform.GetChild(1).gameObject.SetActive(false);

                if (!transform.GetChild(3).gameObject.activeInHierarchy)
                    transform.GetChild(2).gameObject.SetActive(true);
            }
            if (GameManager.instance.data.haveClothSix && clothIndex == 6)
            {
                transform.GetChild(1).gameObject.SetActive(false);

                if (!transform.GetChild(3).gameObject.activeInHierarchy)
                    transform.GetChild(2).gameObject.SetActive(true);
            }
        }
    }

    private void UnequipCharacter()
    {
        GameObject parent = GameManager.instance.characterStoreButtonsParent;

        for (int i = 0; i < parent.transform.childCount - 1; i++)
        {

            if (!parent.transform.GetChild(i).GetChild(1).gameObject.activeInHierarchy)
            {
                parent.transform.GetChild(i).GetChild(3).gameObject.SetActive(false);
                parent.transform.GetChild(i).GetChild(2).gameObject.SetActive(true);
            }
        }
    }

    private void UnequipClothes(int first, int second)
    {
        GameObject parent = GameManager.instance.clothesStoreButtonsParent;

        for (int i = first; i <= second; i++)
        {
            if (!parent.transform.GetChild(i).GetChild(1).gameObject.activeInHierarchy)
            {
                parent.transform.GetChild(i).GetChild(3).gameObject.SetActive(false);
                parent.transform.GetChild(i).GetChild(2).gameObject.SetActive(true);
            }
        }
    }


    private void StartCharactersState()
    {
        if (isCharacter)
        {
            //transform.GetChild(1).gameObject.SetActive(true);
            //transform.GetChild(2).gameObject.SetActive(false);
            //transform.GetChild(3).gameObject.SetActive(false);

            if (GameManager.instance.data.haveCharacterOne && characterIndex == 1)
            {
                if (transform.GetChild(3).gameObject.activeInHierarchy)
                {
                    transform.GetChild(1).gameObject.SetActive(false);
                    transform.GetChild(2).gameObject.SetActive(false);
                }
                else
                {
                    transform.GetChild(2).gameObject.SetActive(true);
                    transform.GetChild(1).gameObject.SetActive(false);
                }
                //transform.GetChild(1).gameObject.SetActive(false);
                costText.text = string.Empty;
                //transform.GetChild(2).gameObject.SetActive(true);
            }
            else
            {
                if (!GameManager.instance.data.haveCharacterOne && characterIndex == 1)
                {
                    costText.text = cost.ToString();
                    transform.GetChild(1).gameObject.SetActive(true);
                    transform.GetChild(2).gameObject.SetActive(false);
                    transform.GetChild(3).gameObject.SetActive(false);
                }
            }
            if (GameManager.instance.data.haveCharacterTwo && characterIndex == 2)
            {
                if (transform.GetChild(3).gameObject.activeInHierarchy)
                {
                    transform.GetChild(1).gameObject.SetActive(false);
                    transform.GetChild(2).gameObject.SetActive(false);
                }
                else
                {
                    transform.GetChild(2).gameObject.SetActive(true);
                    transform.GetChild(1).gameObject.SetActive(false);
                }

                GetComponent<Button>().interactable = true;
                //transform.GetChild(1).gameObject.SetActive(false);
                if(costText != null)
                    costText.text = string.Empty;
                //transform.GetChild(2).gameObject.SetActive(true);
            }
            else
            {
                if (!GameManager.instance.data.haveCharacterTwo && characterIndex == 2)
                {
                    if(costText != null)
                        costText.text = cost.ToString();

                    
                    transform.GetChild(1).gameObject.SetActive(true);
                    transform.GetChild(2).gameObject.SetActive(false);
                    transform.GetChild(3).gameObject.SetActive(false);
                }
            }
            if (GameManager.instance.data.haveCharacterThree && characterIndex == 3)
            {
                if (transform.GetChild(3).gameObject.activeInHierarchy)
                {
                    transform.GetChild(1).gameObject.SetActive(false);
                    transform.GetChild(2).gameObject.SetActive(false);
                }
                else
                {
                    transform.GetChild(2).gameObject.SetActive(true);
                    transform.GetChild(1).gameObject.SetActive(false);
                }

                //transform.GetChild(1).gameObject.SetActive(false);
                costText.text = string.Empty;
                //transform.GetChild(2).gameObject.SetActive(true);
            }
            else
            {
                if (!GameManager.instance.data.haveCharacterThree && characterIndex == 3)
                {
                    costText.text = cost.ToString();
                    transform.GetChild(1).gameObject.SetActive(true);
                    transform.GetChild(2).gameObject.SetActive(false);
                    transform.GetChild(3).gameObject.SetActive(false);
                }
            }
            if (GameManager.instance.data.haveCharacterFour && characterIndex == 4)
            {
                if (transform.GetChild(3).gameObject.activeInHierarchy)
                {
                    transform.GetChild(1).gameObject.SetActive(false);
                    transform.GetChild(2).gameObject.SetActive(false);
                }
                else
                {
                    transform.GetChild(2).gameObject.SetActive(true);
                    transform.GetChild(1).gameObject.SetActive(false);
                }

                //transform.GetChild(1).gameObject.SetActive(false);
                costText.text = string.Empty;
                //transform.GetChild(2).gameObject.SetActive(true);
            }
            else
            {
                if (!GameManager.instance.data.haveCharacterFour && characterIndex == 4)
                {
                    costText.text = cost.ToString();
                    transform.GetChild(1).gameObject.SetActive(true);
                    transform.GetChild(2).gameObject.SetActive(false);
                    transform.GetChild(3).gameObject.SetActive(false);
                }
            }
            if (GameManager.instance.data.haveCharacterFive && characterIndex == 5)
            {
                if (transform.GetChild(3).gameObject.activeInHierarchy)
                {
                    transform.GetChild(1).gameObject.SetActive(false);
                    transform.GetChild(2).gameObject.SetActive(false);
                }
                else
                {
                    transform.GetChild(2).gameObject.SetActive(true);
                    transform.GetChild(1).gameObject.SetActive(false);
                }

                //transform.GetChild(1).gameObject.SetActive(false);
                costText.text = string.Empty;
                //transform.GetChild(2).gameObject.SetActive(true);
            }
            else
            {
                if (!GameManager.instance.data.haveCharacterFive && characterIndex == 5)
                {
                    costText.text = cost.ToString();
                    transform.GetChild(1).gameObject.SetActive(true);
                    transform.GetChild(2).gameObject.SetActive(false);
                    transform.GetChild(3).gameObject.SetActive(false);
                }
            }
            if (GameManager.instance.data.haveCharacterSix && characterIndex == 6)
            {
                if (transform.GetChild(3).gameObject.activeInHierarchy)
                {
                    transform.GetChild(1).gameObject.SetActive(false);
                    transform.GetChild(2).gameObject.SetActive(false);
                }
                else
                {
                    transform.GetChild(2).gameObject.SetActive(true);
                    transform.GetChild(1).gameObject.SetActive(false);
                }

                //transform.GetChild(1).gameObject.SetActive(false);
                costText.text = string.Empty;
                //transform.GetChild(2).gameObject.SetActive(true);
            }
            else
            {
                if (!GameManager.instance.data.haveCharacterSix && characterIndex == 6)
                {
                    costText.text = cost.ToString();
                    transform.GetChild(1).gameObject.SetActive(true);
                    transform.GetChild(2).gameObject.SetActive(false);
                    transform.GetChild(3).gameObject.SetActive(false);
                }
            }
            if (GameManager.instance.data.haveCharacterSeven && characterIndex == 7)
            {
                if (transform.GetChild(3).gameObject.activeInHierarchy)
                {
                    transform.GetChild(1).gameObject.SetActive(false);
                    transform.GetChild(2).gameObject.SetActive(false);
                }
                else
                {
                    transform.GetChild(2).gameObject.SetActive(true);
                    transform.GetChild(1).gameObject.SetActive(false);
                }

                //transform.GetChild(1).gameObject.SetActive(false);
                costText.text = string.Empty;
                //transform.GetChild(2).gameObject.SetActive(true);
            }
            else
            {
                if (!GameManager.instance.data.haveCharacterSeven && characterIndex == 7)
                {
                    costText.text = cost.ToString();
                    transform.GetChild(1).gameObject.SetActive(true);
                    transform.GetChild(2).gameObject.SetActive(false);
                    transform.GetChild(3).gameObject.SetActive(false);
                }
            }
            if (GameManager.instance.data.haveCharacterEight && characterIndex == 8)
            {
                if (transform.GetChild(3).gameObject.activeInHierarchy)
                {
                    transform.GetChild(1).gameObject.SetActive(false);
                    transform.GetChild(2).gameObject.SetActive(false);
                }
                else
                {
                    transform.GetChild(2).gameObject.SetActive(true);
                    transform.GetChild(1).gameObject.SetActive(false);
                }

                //transform.GetChild(1).gameObject.SetActive(false);
                costText.text = string.Empty;
                //transform.GetChild(2).gameObject.SetActive(true);
            }
            else
            {
                if (!GameManager.instance.data.haveCharacterEight && characterIndex == 8)
                {
                    costText.text = cost.ToString();
                    transform.GetChild(1).gameObject.SetActive(true);
                    transform.GetChild(2).gameObject.SetActive(false);
                    transform.GetChild(3).gameObject.SetActive(false);
                }
            }
            if (GameManager.instance.data.haveCharacterNine && characterIndex == 9)
            {
                if (transform.GetChild(3).gameObject.activeInHierarchy)
                {
                    transform.GetChild(1).gameObject.SetActive(false);
                    transform.GetChild(2).gameObject.SetActive(false);
                }
                else
                {
                    transform.GetChild(2).gameObject.SetActive(true);
                    transform.GetChild(1).gameObject.SetActive(false);
                }

                //transform.GetChild(1).gameObject.SetActive(false);
                costText.text = string.Empty;
                //transform.GetChild(2).gameObject.SetActive(true);
            }
            else
            {
                if (!GameManager.instance.data.haveCharacterNine && characterIndex == 9)
                {
                    costText.text = cost.ToString();
                    transform.GetChild(1).gameObject.SetActive(true);
                    transform.GetChild(2).gameObject.SetActive(false);
                    transform.GetChild(3).gameObject.SetActive(false);
                }
            }
            if (GameManager.instance.data.haveCharacterTen && characterIndex == 10)
            {
                if (transform.GetChild(3).gameObject.activeInHierarchy)
                {
                    transform.GetChild(1).gameObject.SetActive(false);
                    transform.GetChild(2).gameObject.SetActive(false);
                }
                else
                {
                    transform.GetChild(2).gameObject.SetActive(true);
                    transform.GetChild(1).gameObject.SetActive(false);
                }

                //transform.GetChild(1).gameObject.SetActive(false);
                costText.text = string.Empty;
                //transform.GetChild(2).gameObject.SetActive(true);
            }
            else
            {
                if (!GameManager.instance.data.haveCharacterTen && characterIndex == 10)
                {
                    costText.text = cost.ToString();
                    transform.GetChild(1).gameObject.SetActive(true);
                    transform.GetChild(2).gameObject.SetActive(false);
                    transform.GetChild(3).gameObject.SetActive(false);
                }
            }
            if (GameManager.instance.data.haveCharacterEleven && characterIndex == 11)
            {
                if (transform.GetChild(3).gameObject.activeInHierarchy)
                {
                    transform.GetChild(1).gameObject.SetActive(false);
                    transform.GetChild(2).gameObject.SetActive(false);
                }
                else
                {
                    transform.GetChild(2).gameObject.SetActive(true);
                    transform.GetChild(1).gameObject.SetActive(false);
                }

                GetComponent<Button>().interactable = true;
                //transform.GetChild(1).gameObject.SetActive(false);

                if(costText != null)
                    costText.text = string.Empty;

                //transform.GetChild(2).gameObject.SetActive(true);
            }
            else
            {
                if (!GameManager.instance.data.haveCharacterEleven && characterIndex == 11)
                {
                    GetComponent<Button>().interactable = false;
                    if(costText != null)
                    {
                        costText.text = cost.ToString();
                    }
                    
                    transform.GetChild(1).gameObject.SetActive(true);
                    transform.GetChild(2).gameObject.SetActive(false);
                    transform.GetChild(3).gameObject.SetActive(false);
                }
            }
            if (GameManager.instance.data.haveCharacterTwelve && characterIndex == 12)
            {
                if (transform.GetChild(3).gameObject.activeInHierarchy)
                {
                    transform.GetChild(1).gameObject.SetActive(false);
                    transform.GetChild(2).gameObject.SetActive(false);
                }
                else
                {
                    transform.GetChild(2).gameObject.SetActive(true);
                    transform.GetChild(1).gameObject.SetActive(false);
                }

                //transform.GetChild(1).gameObject.SetActive(false);
                costText.text = string.Empty;
                //transform.GetChild(2).gameObject.SetActive(true);
            }
            else
            {
                if (!GameManager.instance.data.haveCharacterTwelve && characterIndex == 12)
                {
                    costText.text = cost.ToString();
                    transform.GetChild(1).gameObject.SetActive(true);
                    transform.GetChild(2).gameObject.SetActive(false);
                    transform.GetChild(3).gameObject.SetActive(false);
                }
            }
            if (GameManager.instance.data.haveCharacterThirteen && characterIndex == 13)
            {
                if (transform.GetChild(3).gameObject.activeInHierarchy)
                {
                    transform.GetChild(1).gameObject.SetActive(false);
                    transform.GetChild(2).gameObject.SetActive(false);
                }
                else
                {
                    transform.GetChild(2).gameObject.SetActive(true);
                    transform.GetChild(1).gameObject.SetActive(false);
                }

                //transform.GetChild(1).gameObject.SetActive(false);
                costText.text = string.Empty;
                //transform.GetChild(2).gameObject.SetActive(true);
            }
            else
            {
                if (!GameManager.instance.data.haveCharacterThirteen && characterIndex == 13)
                {
                    costText.text = cost.ToString();
                    transform.GetChild(1).gameObject.SetActive(true);
                    transform.GetChild(2).gameObject.SetActive(false);
                    transform.GetChild(3).gameObject.SetActive(false);
                }
            }
            if (GameManager.instance.data.haveCharacterFourteen && characterIndex == 14)
            {
                if (transform.GetChild(3).gameObject.activeInHierarchy)
                {
                    transform.GetChild(1).gameObject.SetActive(false);
                    transform.GetChild(2).gameObject.SetActive(false);
                }
                else
                {
                    transform.GetChild(2).gameObject.SetActive(true);
                    transform.GetChild(1).gameObject.SetActive(false);
                }
                //transform.GetChild(1).gameObject.SetActive(false);
                costText.text = string.Empty;
                //transform.GetChild(2).gameObject.SetActive(true);
            }
            else
            {
                if (!GameManager.instance.data.haveCharacterFourteen && characterIndex == 14)
                {
                    costText.text = cost.ToString();
                    transform.GetChild(1).gameObject.SetActive(true);
                    transform.GetChild(2).gameObject.SetActive(false);
                    transform.GetChild(3).gameObject.SetActive(false);
                }
            }
            if (GameManager.instance.data.haveCharacterFifteen && characterIndex == 15)
            {
                if (transform.GetChild(3).gameObject.activeInHierarchy)
                {
                    transform.GetChild(1).gameObject.SetActive(false);
                    transform.GetChild(2).gameObject.SetActive(false);
                }
                else
                {
                    transform.GetChild(2).gameObject.SetActive(true);
                    transform.GetChild(1).gameObject.SetActive(false);
                }

                //transform.GetChild(1).gameObject.SetActive(false);
                costText.text = string.Empty;
                //transform.GetChild(2).gameObject.SetActive(true);
            }
            else
            {
                if (!GameManager.instance.data.haveCharacterFifteen && characterIndex == 15)
                {
                    costText.text = cost.ToString();
                    transform.GetChild(1).gameObject.SetActive(true);
                    transform.GetChild(2).gameObject.SetActive(false);
                    transform.GetChild(3).gameObject.SetActive(false);
                }
            }
            if (GameManager.instance.data.haveCharacterSixteen && characterIndex == 16)
            {
                if (transform.GetChild(3).gameObject.activeInHierarchy)
                {
                    transform.GetChild(1).gameObject.SetActive(false);
                    transform.GetChild(2).gameObject.SetActive(false);
                }
                else
                {
                    transform.GetChild(2).gameObject.SetActive(true);
                    transform.GetChild(1).gameObject.SetActive(false);
                }
                //transform.GetChild(1).gameObject.SetActive(false);
                costText.text = string.Empty;
                //transform.GetChild(2).gameObject.SetActive(true);
            }
            else
            {
                if (!GameManager.instance.data.haveCharacterSixteen && characterIndex == 16)
                {
                    costText.text = cost.ToString();
                    transform.GetChild(1).gameObject.SetActive(true);
                    transform.GetChild(2).gameObject.SetActive(false);
                    transform.GetChild(3).gameObject.SetActive(false);
                }
            }

            /*
            if (transform.GetChild(3).gameObject.activeInHierarchy)
            {
                transform.GetChild(1).gameObject.SetActive(false);
            }
            else
            {
                if (!transform.GetChild(3).gameObject.activeInHierarchy && !transform.GetChild(2).gameObject.activeInHierarchy)
                {
                    transform.GetChild(1).gameObject.SetActive(true);
                    transform.GetChild(2).gameObject.SetActive(false);
                    transform.GetChild(3).gameObject.SetActive(false);
                }
            }*/
        }
    }

    private void StartWorldState()
    {
        if (isWorld)
        {
            transform.GetChild(1).gameObject.SetActive(true);
            transform.GetChild(2).gameObject.SetActive(false);

            if (GameManager.instance.data.haveWorldTwoGameOne && worldIndexInStore == 1 && !transform.GetChild(2).gameObject.activeInHierarchy)
            {
                transform.GetChild(1).gameObject.SetActive(false);
                transform.GetChild(2).gameObject.SetActive(true);
            }
            if (GameManager.instance.data.haveWorldThreeGameOne && worldIndexInStore == 2 && !transform.GetChild(2).gameObject.activeInHierarchy)
            {
                transform.GetChild(1).gameObject.SetActive(false);
                transform.GetChild(2).gameObject.SetActive(true);
            }
            if (GameManager.instance.data.haveWorldTwoGameTwo && worldIndexInStore == 3 && !transform.GetChild(2).gameObject.activeInHierarchy)
            {
                transform.GetChild(1).gameObject.SetActive(false);
                transform.GetChild(2).gameObject.SetActive(true);
            }
            if (GameManager.instance.data.haveWorldThreeGameTwo && worldIndexInStore == 4 && !transform.GetChild(2).gameObject.activeInHierarchy)
            {
                transform.GetChild(1).gameObject.SetActive(false);
                transform.GetChild(2).gameObject.SetActive(true);
            }
        }
    }

    public void BuyItem()
    {
        if (isCharacter)
        {
            CharacterCase();
        }
        else
        {
            if (isWorld)
            {
                WorldCase();
            }else if (isCloth)
            {
                ClothCase();
            }
            else
            {
                BuyOrUse();
            }
        }
        
    }

    private void ClothCase()
    {
        if (clothIndex == 1)
        {
            InterfaceManagerMenu.instance.nameText.text = "Casco de olla";
            InterfaceManagerMenu.instance.nameText.text = NombreDescripcion;
            InterfaceManagerMenu.instance.descriptionText.text = "Casco de olla, sombrero que te defenderá de los mas duros golpes";
            InterfaceManagerMenu.instance.descriptionText.text = Descripcion;

            if (!GameManager.instance.data.haveClothOne)
            {
                BuyOrUse();
            }
            else
            {
                if (!GameManager.instance.clothesUsed[0])
                {
                    UnequipClothes(GameManager.instance.GorrosIndex.first, GameManager.instance.GorrosIndex.second);
                    transform.GetChild(2).gameObject.SetActive(false);
                    transform.GetChild(3).gameObject.SetActive(true);
                    GameManager.instance.clothesUsed[0] = true;
                    GameManager.instance.clothesUsed[1] = false;
                    GameManager.instance.clothesUsed[2] = false;

                    GameManager.instance.data.useClothOne = true;
                    GameManager.instance.data.useClothTwo = false;
                    GameManager.instance.data.useClothThree = false;
                    GameManager.instance.SaveChanges();

                    Debug.Log("Selecciona ropa 1");
                }
                else
                {
                    //Desequipa la ropa
                    transform.GetChild(2).gameObject.SetActive(true);
                    transform.GetChild(3).gameObject.SetActive(false);
                    GameManager.instance.clothesUsed[0] = false;
                    GameManager.instance.data.useClothOne = false;
                }
                
            }
        }
        else if (clothIndex == 2)
        {
            InterfaceManagerMenu.instance.nameText.text = "Gorra Danny";
            InterfaceManagerMenu.instance.descriptionText.text = "Gorra de danny, gorra con el logo de hola soy danny, el preferido de los fans";
            InterfaceManagerMenu.instance.nameText.text = NombreDescripcion;
            InterfaceManagerMenu.instance.descriptionText.text = Descripcion;

            if (!GameManager.instance.data.haveClothTwo)
            {
                BuyOrUse();
            }
            else
            {
                if (!GameManager.instance.clothesUsed[1])
                {
                    UnequipClothes(GameManager.instance.GorrosIndex.first, GameManager.instance.GorrosIndex.second);
                    transform.GetChild(2).gameObject.SetActive(false);
                    transform.GetChild(3).gameObject.SetActive(true);
                    GameManager.instance.clothesUsed[0] = false;
                    GameManager.instance.clothesUsed[1] = true;
                    GameManager.instance.clothesUsed[2] = false;

                    GameManager.instance.data.useClothOne = false;
                    GameManager.instance.data.useClothTwo = true;
                    GameManager.instance.data.useClothThree = false;
                    GameManager.instance.SaveChanges();

                    Debug.Log("Selecciona ropa 2");
                }
                else
                {
                    //Desequipa la ropa
                    transform.GetChild(2).gameObject.SetActive(true);
                    transform.GetChild(3).gameObject.SetActive(false);
                    GameManager.instance.clothesUsed[1] = false;
                    GameManager.instance.data.useClothTwo = false;
                }
            }
        }
        else if (clothIndex == 3)
        {
            InterfaceManagerMenu.instance.nameText.text = "Gorro de bruja";
            InterfaceManagerMenu.instance.descriptionText.text = "Gorra de bruja, dicen que si te lo pones obtienes un poder superior al de los senadores";
            InterfaceManagerMenu.instance.nameText.text = NombreDescripcion;
            InterfaceManagerMenu.instance.descriptionText.text = Descripcion;

            if (!GameManager.instance.data.haveClothThree)
            {
                BuyOrUse();
            }
            else
            {
                if (!GameManager.instance.clothesUsed[2])
                {
                    UnequipClothes(GameManager.instance.GorrosIndex.first, GameManager.instance.GorrosIndex.second);
                    transform.GetChild(2).gameObject.SetActive(false);
                    transform.GetChild(3).gameObject.SetActive(true);
                    GameManager.instance.clothesUsed[0] = false;
                    GameManager.instance.clothesUsed[1] = false;
                    GameManager.instance.clothesUsed[2] = true;

                    GameManager.instance.data.useClothOne = false;
                    GameManager.instance.data.useClothTwo = false;
                    GameManager.instance.data.useClothThree = true;
                    GameManager.instance.SaveChanges();

                    Debug.Log("Selecciona ropa 3");
                }
                else
                {
                    //Desequipa la ropa
                    transform.GetChild(2).gameObject.SetActive(true);
                    transform.GetChild(3).gameObject.SetActive(false);
                    GameManager.instance.clothesUsed[2] = false;
                    GameManager.instance.data.useClothThree = false;
                }
            }
        }
        else if (clothIndex == 4)
        {
            InterfaceManagerMenu.instance.nameText.text = "Collar de arepas";
            InterfaceManagerMenu.instance.descriptionText.text = "Collar de arepas, con este collar te conviertes en uno de los cantores del chipuco";
            InterfaceManagerMenu.instance.nameText.text = NombreDescripcion;
            InterfaceManagerMenu.instance.descriptionText.text = Descripcion;

            if (!GameManager.instance.data.haveClothFour)
            {
                BuyOrUse();
            }
            else
            {
                if (!GameManager.instance.clothesUsed[3])
                {
                    UnequipClothes(GameManager.instance.CollarIndex.first, GameManager.instance.CollarIndex.second);
                    transform.GetChild(2).gameObject.SetActive(false);
                    transform.GetChild(3).gameObject.SetActive(true);
                    GameManager.instance.clothesUsed[3] = true;

                    GameManager.instance.data.useClothFour = true;
                    GameManager.instance.SaveChanges();

                    Debug.Log("Selecciona ropa 4");
                }
                else
                {
                    //Desequipa la ropa
                    transform.GetChild(2).gameObject.SetActive(true);
                    transform.GetChild(3).gameObject.SetActive(false);
                    GameManager.instance.clothesUsed[3] = false;
                    GameManager.instance.data.useClothFour = false;
                }
                
            }
        }
        else if (clothIndex == 5)
        {
            InterfaceManagerMenu.instance.nameText.text = "Gafas reguetón";
            InterfaceManagerMenu.instance.descriptionText.text = "Gafas reguetón, con esta prenda te conviertes originalmente en un regetoneros";
            InterfaceManagerMenu.instance.nameText.text = NombreDescripcion;
            InterfaceManagerMenu.instance.descriptionText.text = Descripcion;

            if (!GameManager.instance.data.haveClothFive)
            {
                BuyOrUse();
            }
            else
            {
                if (!GameManager.instance.clothesUsed[4])
                {
                    UnequipClothes(GameManager.instance.GafasIndex.first, GameManager.instance.GafasIndex.second);
                    transform.GetChild(2).gameObject.SetActive(false);
                    transform.GetChild(3).gameObject.SetActive(true);
                    GameManager.instance.clothesUsed[4] = true;

                    GameManager.instance.data.useClothFive = true;
                    GameManager.instance.SaveChanges();

                    Debug.Log("Selecciona ropa 5");
                }
                else
                {
                    //Desequipa la prenda
                    transform.GetChild(2).gameObject.SetActive(true);
                    transform.GetChild(3).gameObject.SetActive(false);
                    GameManager.instance.clothesUsed[4] = false;
                    GameManager.instance.data.useClothFive = false;
                }
                
            }
        }
        else if (clothIndex == 6)
        {
            InterfaceManagerMenu.instance.nameText.text = "Nariz marrano";
            InterfaceManagerMenu.instance.descriptionText.text = "Nariz de marrano, un día en el congreso hicieron lechona y pusieron a la venta la nariz";
            InterfaceManagerMenu.instance.nameText.text = NombreDescripcion;
            InterfaceManagerMenu.instance.descriptionText.text = Descripcion;

            if (!GameManager.instance.data.haveClothSix)
            {
                
                BuyOrUse();
            }
            else
            {
                if (!GameManager.instance.clothesUsed[5])
                {
                    UnequipClothes(GameManager.instance.NarizIndex.first, GameManager.instance.NarizIndex.second);
                    transform.GetChild(2).gameObject.SetActive(false);
                    transform.GetChild(3).gameObject.SetActive(true);
                    GameManager.instance.clothesUsed[5] = true;

                    GameManager.instance.data.useClothSix = true;
                    GameManager.instance.SaveChanges();

                    Debug.Log("Selecciona ropa 6");
                }
                else
                {
                    //Desequipa la ropa
                    transform.GetChild(2).gameObject.SetActive(true);
                    transform.GetChild(3).gameObject.SetActive(false);
                    GameManager.instance.clothesUsed[5] = false;
                    GameManager.instance.data.useClothSix = false;
                }
            }
        }
    }

    private void WorldCase()
    {
        if (worldIndexInStore == 1)
        {
            InterfaceManagerMenu.instance.nameText.text = "Congreso";
            InterfaceManagerMenu.instance.descriptionText.text = "Ayuda a defender el congreso de los congresistas que nos atacan";
            InterfaceManagerMenu.instance.nameText.text = NombreDescripcion;
            InterfaceManagerMenu.instance.descriptionText.text = Descripcion;

            if (!GameManager.instance.data.haveWorldTwoGameOne)
            {
                BuyOrUse();
            }
        }
        else if (worldIndexInStore == 2)
        {
            InterfaceManagerMenu.instance.nameText.text = "Mundo bloqueado";
            InterfaceManagerMenu.instance.descriptionText.text = "Este mundo no esta disponible por ahora";
            InterfaceManagerMenu.instance.nameText.text = NombreDescripcion;
            InterfaceManagerMenu.instance.descriptionText.text = Descripcion;

            if (!GameManager.instance.data.haveWorldThreeGameOne)
            {
                BuyOrUse();
            }
        }
        else if (worldIndexInStore == 3)
        {
            InterfaceManagerMenu.instance.nameText.text = "Mundo mermelada";
            InterfaceManagerMenu.instance.descriptionText.text = "Un mundo hecho de dulce, salta sobre los caramelos lo mas alto que puedas";
            InterfaceManagerMenu.instance.nameText.text = NombreDescripcion;
            InterfaceManagerMenu.instance.descriptionText.text = Descripcion;

            if (!GameManager.instance.data.haveWorldTwoGameTwo)
            {
                BuyOrUse();
            }
        }
        else if (worldIndexInStore == 4)
        {
            InterfaceManagerMenu.instance.nameText.text = "Mundo bloqueado";
            InterfaceManagerMenu.instance.descriptionText.text = "Este mundo no esta disponible por ahora";
            InterfaceManagerMenu.instance.nameText.text = NombreDescripcion;
            InterfaceManagerMenu.instance.descriptionText.text = Descripcion;

            if (!GameManager.instance.data.haveWorldThreeGameTwo)
            {
                BuyOrUse();
            }
        }
    }

    private void CharacterCase()
    {
        if (characterIndex == 1)
        {
            InterfaceManagerMenu.instance.nameText.text = NombreDescripcion;
            InterfaceManagerMenu.instance.descriptionText.text = Descripcion;

            if (!GameManager.instance.data.haveCharacterOne)
            {
                BuyOrUse();
            }
            else
            {
                UnequipCharacter();
                transform.GetChild(1).gameObject.SetActive(false);
                transform.GetChild(2).gameObject.SetActive(false);
                transform.GetChild(3).gameObject.SetActive(true);
                GameManager.instance.playerSelectedIndex = 0;
                GameManager.instance.spritePlayerSelected = GameManager.instance.charactersSprites[0];
                Debug.Log("Selecciona personaje 1");
            }
        }
        else if (characterIndex == 2)
        {
            InterfaceManagerMenu.instance.nameText.text = NombreDescripcion;
            InterfaceManagerMenu.instance.descriptionText.text = Descripcion;

            if (!GameManager.instance.data.haveCharacterTwo)
            {
                BuyOrUse();
            }
            else
            {
                UnequipCharacter();
                transform.GetChild(1).gameObject.SetActive(false);
                transform.GetChild(2).gameObject.SetActive(false);
                transform.GetChild(3).gameObject.SetActive(true);
                GameManager.instance.playerSelectedIndex = 1;
                GameManager.instance.spritePlayerSelected = GameManager.instance.charactersSprites[1];
                Debug.Log("Selecciona personaje 2");
            }
        }
        else if (characterIndex == 3)
        {
            InterfaceManagerMenu.instance.nameText.text = NombreDescripcion;
            InterfaceManagerMenu.instance.descriptionText.text = Descripcion;

            if (!GameManager.instance.data.haveCharacterThree)
            {
                BuyOrUse();
            }
            else
            {
                UnequipCharacter();
                transform.GetChild(1).gameObject.SetActive(false);
                transform.GetChild(2).gameObject.SetActive(false);
                transform.GetChild(3).gameObject.SetActive(true);
                GameManager.instance.playerSelectedIndex = 2;
                GameManager.instance.spritePlayerSelected = GameManager.instance.charactersSprites[2];
                Debug.Log("Selecciona personaje 3");
            }
        }
        else if (characterIndex == 4)
        {
            InterfaceManagerMenu.instance.nameText.text = NombreDescripcion;
            InterfaceManagerMenu.instance.descriptionText.text = Descripcion;

            if (!GameManager.instance.data.haveCharacterFour)
            {
                
                BuyOrUse();
            }
            else
            {
                UnequipCharacter();
                transform.GetChild(1).gameObject.SetActive(false);
                transform.GetChild(2).gameObject.SetActive(false);
                transform.GetChild(3).gameObject.SetActive(true);
                GameManager.instance.playerSelectedIndex = 3;
                GameManager.instance.spritePlayerSelected = GameManager.instance.charactersSprites[3];
                Debug.Log("Selecciona personaje 4");
            }
        }
        else if (characterIndex == 5)
        {
            InterfaceManagerMenu.instance.nameText.text = NombreDescripcion;
            InterfaceManagerMenu.instance.descriptionText.text = Descripcion;

            if (!GameManager.instance.data.haveCharacterFive)
            {
                BuyOrUse();
            }
            else
            {
                UnequipCharacter();
                transform.GetChild(1).gameObject.SetActive(false);
                transform.GetChild(2).gameObject.SetActive(false);
                transform.GetChild(3).gameObject.SetActive(true);
                GameManager.instance.playerSelectedIndex = 4;
                GameManager.instance.spritePlayerSelected = GameManager.instance.charactersSprites[4];
                Debug.Log("Selecciona personaje 5");
            }
        }
        else if (characterIndex == 6)
        {
            InterfaceManagerMenu.instance.nameText.text = NombreDescripcion;
            InterfaceManagerMenu.instance.descriptionText.text = Descripcion;

            if (!GameManager.instance.data.haveCharacterSix)
            {
                BuyOrUse();
            }
            else
            {
                UnequipCharacter();
                transform.GetChild(1).gameObject.SetActive(false);
                transform.GetChild(2).gameObject.SetActive(false);
                transform.GetChild(3).gameObject.SetActive(true);
                GameManager.instance.playerSelectedIndex = 5;
                GameManager.instance.spritePlayerSelected = GameManager.instance.charactersSprites[5];
                Debug.Log("Selecciona personaje 6");
            }
        }
        else if (characterIndex == 7)
        {
            InterfaceManagerMenu.instance.nameText.text = NombreDescripcion;
            InterfaceManagerMenu.instance.descriptionText.text = Descripcion;

            if (!GameManager.instance.data.haveCharacterSeven)
            {
                BuyOrUse();
            }
            else
            {
                UnequipCharacter();
                transform.GetChild(1).gameObject.SetActive(false);
                transform.GetChild(2).gameObject.SetActive(false);
                transform.GetChild(3).gameObject.SetActive(true);
                GameManager.instance.playerSelectedIndex = 6;
                GameManager.instance.spritePlayerSelected = GameManager.instance.charactersSprites[6];
                Debug.Log("Selecciona personaje 7");
            }
        }
        else if (characterIndex == 8)
        {
            InterfaceManagerMenu.instance.nameText.text = NombreDescripcion;
            InterfaceManagerMenu.instance.descriptionText.text = Descripcion;

            if (!GameManager.instance.data.haveCharacterEight)
            {
                BuyOrUse();
            }
            else
            {
                UnequipCharacter();
                transform.GetChild(1).gameObject.SetActive(false);
                transform.GetChild(2).gameObject.SetActive(false);
                transform.GetChild(3).gameObject.SetActive(true);
                GameManager.instance.playerSelectedIndex = 7;
                GameManager.instance.spritePlayerSelected = GameManager.instance.charactersSprites[7];
                Debug.Log("Selecciona personaje 8");
            }
        }
        else if (characterIndex == 9)
        {
            InterfaceManagerMenu.instance.nameText.text = NombreDescripcion;
            InterfaceManagerMenu.instance.descriptionText.text = Descripcion;

            if (!GameManager.instance.data.haveCharacterNine)
            {
                BuyOrUse();
            }
            else
            {
                UnequipCharacter();
                transform.GetChild(1).gameObject.SetActive(false);
                transform.GetChild(2).gameObject.SetActive(false);
                transform.GetChild(3).gameObject.SetActive(true);
                GameManager.instance.playerSelectedIndex = 8;
                GameManager.instance.spritePlayerSelected = GameManager.instance.charactersSprites[8];
                Debug.Log("Selecciona personaje 9");
            }
        }
        else if (characterIndex == 10)
        {
            InterfaceManagerMenu.instance.nameText.text = NombreDescripcion;
            InterfaceManagerMenu.instance.descriptionText.text = Descripcion;

            if (!GameManager.instance.data.haveCharacterTen)
            {
                BuyOrUse();
            }
            else
            {
                UnequipCharacter();
                transform.GetChild(1).gameObject.SetActive(false);
                transform.GetChild(2).gameObject.SetActive(false);
                transform.GetChild(3).gameObject.SetActive(true);
                GameManager.instance.playerSelectedIndex = 9;
                GameManager.instance.spritePlayerSelected = GameManager.instance.charactersSprites[9];
                Debug.Log("Selecciona personaje 10");
            }
        }
        else if (characterIndex == 11)
        {
            InterfaceManagerMenu.instance.nameText.text = NombreDescripcion;
            InterfaceManagerMenu.instance.descriptionText.text = Descripcion;

            if (!GameManager.instance.data.haveCharacterEleven)
            {
                BuyOrUse();
            }
            else
            {
                UnequipCharacter();
                transform.GetChild(1).gameObject.SetActive(false);
                transform.GetChild(2).gameObject.SetActive(false);
                transform.GetChild(3).gameObject.SetActive(true);
                GameManager.instance.playerSelectedIndex = 10;
                GameManager.instance.spritePlayerSelected = GameManager.instance.charactersSprites[10];
                Debug.Log("Selecciona personaje 11");
            }
        }
        else if (characterIndex == 12)
        {
            InterfaceManagerMenu.instance.nameText.text = NombreDescripcion;
            InterfaceManagerMenu.instance.descriptionText.text = Descripcion;

            if (!GameManager.instance.data.haveCharacterTwelve)
            {
                BuyOrUse();
            }
            else
            {
                UnequipCharacter();
                transform.GetChild(1).gameObject.SetActive(false);
                transform.GetChild(2).gameObject.SetActive(false);
                transform.GetChild(3).gameObject.SetActive(true);
                GameManager.instance.playerSelectedIndex = 11;
                GameManager.instance.spritePlayerSelected = GameManager.instance.charactersSprites[11];
                Debug.Log("Selecciona personaje 12");
            }
        }
        else if (characterIndex == 13)
        {
            InterfaceManagerMenu.instance.nameText.text = NombreDescripcion;
            InterfaceManagerMenu.instance.descriptionText.text = Descripcion;

            if (!GameManager.instance.data.haveCharacterThirteen)
            {
                BuyOrUse();
            }
            else
            {
                UnequipCharacter();
                transform.GetChild(1).gameObject.SetActive(false);
                transform.GetChild(2).gameObject.SetActive(false);
                transform.GetChild(3).gameObject.SetActive(true);
                GameManager.instance.playerSelectedIndex = 12;
                GameManager.instance.spritePlayerSelected = GameManager.instance.charactersSprites[12];
                Debug.Log("Selecciona personaje 13");
            }
        }
        else if (characterIndex == 14)
        {
            InterfaceManagerMenu.instance.nameText.text = NombreDescripcion;
            InterfaceManagerMenu.instance.descriptionText.text = Descripcion;

            if (!GameManager.instance.data.haveCharacterFourteen)
            {
                BuyOrUse();
            }
            else
            {
                UnequipCharacter();
                transform.GetChild(1).gameObject.SetActive(false);
                transform.GetChild(2).gameObject.SetActive(false);
                transform.GetChild(3).gameObject.SetActive(true);
                GameManager.instance.playerSelectedIndex = 13;
                GameManager.instance.spritePlayerSelected = GameManager.instance.charactersSprites[13];
                Debug.Log("Selecciona personaje 14");
            }
        }
        else if (characterIndex == 15)
        {
            InterfaceManagerMenu.instance.nameText.text = NombreDescripcion;
            InterfaceManagerMenu.instance.descriptionText.text = Descripcion;

            if (!GameManager.instance.data.haveCharacterFifteen)
            {
                BuyOrUse();
            }
            else
            {
                UnequipCharacter();
                transform.GetChild(1).gameObject.SetActive(false);
                transform.GetChild(2).gameObject.SetActive(false);
                transform.GetChild(3).gameObject.SetActive(true);
                GameManager.instance.playerSelectedIndex = 14;
                GameManager.instance.spritePlayerSelected = GameManager.instance.charactersSprites[14];
                Debug.Log("Selecciona personaje 15");
            }
        }
        else if (characterIndex == 16)
        {
            InterfaceManagerMenu.instance.nameText.text = NombreDescripcion;
            InterfaceManagerMenu.instance.descriptionText.text = Descripcion;

            if (!GameManager.instance.data.haveCharacterSixteen)
            {
                BuyOrUse();
            }
            else
            {
                UnequipCharacter();
                transform.GetChild(1).gameObject.SetActive(false);
                transform.GetChild(2).gameObject.SetActive(false);
                transform.GetChild(3).gameObject.SetActive(true);
                GameManager.instance.playerSelectedIndex = 15;
                GameManager.instance.spritePlayerSelected = GameManager.instance.charactersSprites[15];
                Debug.Log("Selecciona personaje 16");
            }
        }
    }
}
