using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetChallengeValues : MonoBehaviour
{
    private string challengeTitle;
    private string challengeDescription;
    private bool isInfinite;
    private int cantityOfMissions = 0;

    public Text challengeTitleText;
    public Text challengeDescriptionText;

    public GameObject winCanvas;
    public Image winImage;

    [Space(20)]
    private int currentLevel;
    private int currentWorld;

    [Space(20)]
    public bool isMissionOfZombies;
    public bool isMissionOfStars;
    public bool isMissionOfTime;
    public bool isMissionOfAnimals;
    public bool isMissionOfObjects;

    [Space(20)]

    public int zombiesToEliminate;
    public int starsToGet;
    public int timeToSurvive;
    public int animalsToCapture;
    public int objectsToCapture;

    [Space(20)]
    public int starsReward;
    public int clothID;
    public Sprite characterImage;

    [Space(20)]
    public SpriteRenderer worldSprite;

    [Space(20)]
    public bool unlockCard;
    public int cardToUnlock;
    public Image unlockedPlantImage;
    public Text unlockedDescriptionText;

    public Text starsWinText;

    [Space(20)]
    public bool willShowAdd;

    /*
    private void Awake()
    {
        challengeTitle = GameManager.instance.levelObject.GetComponent<Challenges>().challengeName;
        challengeDescription = GameManager.instance.levelObject.GetComponent<Challenges>().challengeDescription;
    }*/

    public void Awake()
    {
        //worldSprite = 

        if (GameManager.instance.levelObject != null)
        {
            Challenges challenges;

            if (GameManager.instance.levelObject == GameObject.Find(GameManager.instance.levelName))
            {
                challenges = GameManager.instance.levelObject.GetComponent<Challenges>();
            }
            else
            {
                challenges = GameObject.Find(GameManager.instance.levelName).GetComponent<Challenges>();
            }

            worldSprite.sprite = challenges.spriteOfWorld;

            challengeTitle = challenges.challengeName;
            challengeDescription = challenges.challengeDescription;
            challengeTitleText.text = challengeTitle;
            challengeDescriptionText.text = challengeDescription;

            currentLevel = challenges.level;
            currentWorld = challenges.world;

            isMissionOfZombies = challenges.isMissionOfZombies;
            isMissionOfStars = challenges.isMissionOfStars;
            isMissionOfTime = challenges.isMissionOfTime;
            isMissionOfAnimals = challenges.isMissionOfAnimals;
            isMissionOfObjects = challenges.isMissionOfObjects;

            zombiesToEliminate = challenges.zombiesToEliminate;
            starsToGet = challenges.starsToGet;
            timeToSurvive = challenges.timeToSurvive;
            animalsToCapture = challenges.animalsToCapture;
            objectsToCapture = challenges.objectsToCapture;

            starsReward = challenges.starsReward;
            clothID = challenges.clothID;
            characterImage = challenges.characterImage;

            unlockCard = challenges.unlockCharacters;
            cardToUnlock = challenges.characterToUnlock;

            willShowAdd = challenges.willShowAdd;

            starsWinText.text = "x"+ challenges.starsReward.ToString();

            if(challenges.unlockedPlantImage != null) unlockedPlantImage.sprite = challenges.unlockedPlantImage;
            if (challenges.description != string.Empty) unlockedDescriptionText.text = challenges.description;

            GameManager.instance.levelObject = challenges.gameObject.GetComponentInParent<Canvas>().gameObject;
            GameManager.instance.levelObject.SetActive(false);

            if (willShowAdd)
            {
                //CARGAR PUBLICIDAD
                //AdManager.instance.IsReadyAd();
            }
        }
    }

    
    private void Start()
    {

        if (isMissionOfZombies) cantityOfMissions++;
        if (isMissionOfTime) cantityOfMissions++;
        if (isMissionOfStars) cantityOfMissions++;
        if (isMissionOfObjects) cantityOfMissions++;
        if (isMissionOfAnimals) cantityOfMissions++;
        if (cantityOfMissions == 0) isInfinite = true;

        PlantsVsZombiesManager.instance.starsReward = starsReward;
        PlantsVsZombiesManager.instance.currentLevel = currentLevel;
        PlantsVsZombiesManager.instance.currentWorld = currentWorld;
    }

    public void Update()
    {
        if(cantityOfMissions > 0)
        {
            if (isMissionOfZombies)
            {
                if (PlantsVsZombiesManager.instance.zombiesKilled >= zombiesToEliminate)
                {
                    cantityOfMissions--;
                    //Debug.Log("TU GANAS!");
                    isMissionOfZombies = false;
                }
            }

            if (isMissionOfTime)
            {
                if (PlantsVsZombiesManager.instance.currentTime >= timeToSurvive)
                {
                    cantityOfMissions--;
                    //Debug.Log("TU GANAS!");
                    isMissionOfTime = false;
                }
            }

            if (isMissionOfStars)
            {
                if (PlantsVsZombiesManager.instance.starsObtained >= starsToGet)
                {
                    cantityOfMissions--;
                    //Debug.Log("TU GANAS!");
                    isMissionOfStars = false;
                }
            }

            if (isMissionOfObjects)
            {
                if (PlantsVsZombiesManager.instance.objectsObtained >= objectsToCapture)
                {
                    cantityOfMissions--;
                    //Debug.Log("TU GANAS!");
                    isMissionOfObjects = false;
                }
            }

            if (isMissionOfAnimals)
            {
                if (PlantsVsZombiesManager.instance.animalsObtained >= animalsToCapture)
                {
                    cantityOfMissions--;
                    //Debug.Log("TU GANAS!");
                    isMissionOfAnimals = false;
                }
            }
        }
        else
        {

            if(cantityOfMissions <= 0 && !isInfinite)
            {
                Time.timeScale = 0;
                PlantsVsZombiesManager.instance.soundManager.SetActive(false);

                if (unlockCard && PlantsVsZombiesManager.instance.unlockedCardPanel != null)
                    UnlockCard();
                else winCanvas.SetActive(true);

                winImage.sprite = characterImage;
                UnlockCharacters();
                this.enabled = false;
            }
        }
    }

    public void ShowAdd()
    {
        //Muestra publicidad
        //AdManager.instance.ShowRewardedAd();
    }

    private void UnlockCard() {

        if (cardToUnlock == 3 && !GameManager.instance.data.haveCardThree) {

            PlantsVsZombiesManager.instance.unlockedCardPanel.SetActive(true);

        }else if(cardToUnlock == 4 && !GameManager.instance.data.haveCardFour) {

            PlantsVsZombiesManager.instance.unlockedCardPanel.SetActive(true);

        }
        else if(cardToUnlock == 5 && !GameManager.instance.data.haveCardFive) {

            PlantsVsZombiesManager.instance.unlockedCardPanel.SetActive(true);

        }
        else if(cardToUnlock == 6 && !GameManager.instance.data.haveCardSix) {

            PlantsVsZombiesManager.instance.unlockedCardPanel.SetActive(true);

        }
        else if(cardToUnlock == 7 && !GameManager.instance.data.haveCardSeven) {

            PlantsVsZombiesManager.instance.unlockedCardPanel.SetActive(true);

        }
        else if(cardToUnlock == 8 && !GameManager.instance.data.haveCardEight) {

            PlantsVsZombiesManager.instance.unlockedCardPanel.SetActive(true);

        }
        else if(cardToUnlock == 9 && !GameManager.instance.data.haveCardNine) {

            PlantsVsZombiesManager.instance.unlockedCardPanel.SetActive(true);

        }
        else if(cardToUnlock == 10 && !GameManager.instance.data.haveCardTen) {

            PlantsVsZombiesManager.instance.unlockedCardPanel.SetActive(true);

        }
        else
        {
            winCanvas.SetActive(true);
        }
    }

    private void UnlockCharacters() {
        if (unlockCard) {

            switch (cardToUnlock) {

                case 3:
                    GameManager.instance.data.haveCardThree = true;
                    break;

                case 4:
                    GameManager.instance.data.haveCardFour = true;
                    break;

                case 5:
                    GameManager.instance.data.haveCardFive = true;
                    break;

                case 6:
                    GameManager.instance.data.haveCardSix = true;
                break;

                case 7:
                    GameManager.instance.data.haveCardSeven = true;
                break;

                case 8:
                    GameManager.instance.data.haveCardEight = true;
                break;

                case 9:
                    GameManager.instance.data.haveCardNine = true;
                break;

                case 10:
                    GameManager.instance.data.haveCardTen = true;
                break;
            }
                
        }
    }
}
