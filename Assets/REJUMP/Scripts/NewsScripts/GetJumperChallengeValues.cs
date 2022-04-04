using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GetJumperChallengeValues : MonoBehaviour
{
    private string challengeTitle = "Tutorial";
    private string challengeDescription;
    private bool isInfinite;
    private int cantityOfMissions = 0;

    public Text challengeTitleText;
    public Text challengeDescriptionText;

    public GameObject winCanvas;
    public Image winImage;
    public HUD gameHud;

    public GameObject botonVolverMenu;

    [Space(20)]
    public int currentLevel;
    public int currentWorld;

    [Space(20)]
    public bool isMissionOfZombies;
    public bool isMissionOfStars;
    public bool isMissionOfTime;
    public bool isMissionOfAnimals;
    public bool isMissionOfObjects;

    [Space(20)]
    public bool isMissionOfPointsJumper;
    public bool isMissionOfStarsJumper;

    [Space(20)]

    public int zombiesToEliminate;
    public int starsToGet;
    public int timeToSurvive;
    public int animalsToCapture;
    public int objectsToCapture;

    [Space(20)]

    public int pointsToDo;
    public int starsToGetJumper;

    [Space(20)]
    public int starsReward;
    public int clothID;
    public Sprite characterImage;

    [Space(20)]
    public Sprite worldSprite;
    public SpriteRenderer backgroundSprite;

    [Space(20)]
    public bool unlockCard;
    public int cardToUnlock;
    public Image unlockedPlantImage;
    public Text unlockedDescriptionText;
    [Space(20)]
    public HUD hudReference;

    [Space(20)]
    public bool willShowAdd;
    [Space(20)]
    public Text rewardText;

    

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

            worldSprite = challenges.spriteOfWorld;
            backgroundSprite.sprite = challenges.spriteOfWorld;

            challengeTitle = challenges.challengeName;
            challengeDescription = challenges.challengeDescription;
            challengeTitleText.text = challengeTitle;
            challengeDescriptionText.text = challengeDescription;

            currentLevel = challenges.level;
            currentWorld = challenges.world;

            isMissionOfPointsJumper = challenges.isMissionOfPointsJumper;
            isMissionOfStarsJumper = challenges.isMissionOfStarsJumper;

            pointsToDo = challenges.pointToDo;
            starsToGetJumper = challenges.starsToGetJumper;
            

            starsReward = challenges.starsReward;
            clothID = challenges.clothID;
            characterImage = challenges.characterImage;

            unlockCard = challenges.unlockCharacters;
            cardToUnlock = challenges.characterToUnlock;

            willShowAdd = challenges.willShowAdd;

            if (challenges.unlockedPlantImage != null) unlockedPlantImage.sprite = challenges.unlockedPlantImage;
            if (challenges.description != string.Empty) unlockedDescriptionText.text = challenges.description;

            GameManager.instance.levelObject = challenges.gameObject.GetComponentInParent<Canvas>().gameObject;
            GameManager.instance.levelObject.SetActive(false);

            rewardText.text = "x" + challenges.starsReward.ToString();

            if(currentWorld == 1)
            {
                GameObject.Find("Overlay").transform.localScale = Vector3.one;
            }

            if (willShowAdd)
            {
                //CARGAR PUBLICIDAD
                //AdManager.instance.IsReadyAd();
            }
        }

        if(challengeTitle == "Tutorial")
        {
            botonVolverMenu.SetActive(false);
        }
    }


    private void Start()
    {

        if (isMissionOfPointsJumper) cantityOfMissions++;
        if (isMissionOfStarsJumper) cantityOfMissions++;
        if (cantityOfMissions == 0) isInfinite = true;

        JumperGameManager.instance.starsReward = starsReward;
        JumperGameManager.instance.currentLevel = currentLevel;
        JumperGameManager.instance.currentWorld = currentWorld;
    }

    public void Update()
    {
        if (cantityOfMissions > 0)
        {
            if (isMissionOfPointsJumper)
            {
                if (hudReference.GetScore() >= pointsToDo)
                {
                    cantityOfMissions--;
                    //Debug.Log("TU GANAS!");
                    isMissionOfPointsJumper = false;
                }
        }

            if (isMissionOfStarsJumper)
            {
                if (hudReference.GetCoins() >= starsToGetJumper)
                {
                    cantityOfMissions--;
                    //Debug.Log("TU GANAS!");
                    isMissionOfStarsJumper = false;
                }
            }
        }
        else
        {

            if (cantityOfMissions <= 0 && !isInfinite)
            {
                gameHud.ResetScore();
                Time.timeScale = 0;
                winCanvas.SetActive(true);
                UnlockPerWorld();

                //ACTIVAMOS EL PANEL DE VICTORIA
                this.enabled = false;
            }
            
        }
    }


    public void ShowAdd()
    {
        /*if (currentWorld == 1 && GameManager.instance.data.levelsUnlockedWorldOneGameTwo < currentLevel)
        {
            //Muestra publicidad
            if (AdManager.instance.isReady[1])
            {
                AdManager.instance.ShowRewardedAd();
            }
            
        }
        else if (currentWorld == 2 && GameManager.instance.data.levelsUnlockedWorldTwoGameTwo < currentLevel)
        {
            //Muestra publicidad
            if (AdManager.instance.isReady[1])
            {
                AdManager.instance.ShowRewardedAd();
            }
        }*/
    }

    private void UnlockPerWorld() {
        if (currentWorld == 1 && GameManager.instance.data.levelsUnlockedWorldOneGameTwo < currentLevel + 1)
        {
            GameManager.instance.data.levelsUnlockedWorldOneGameTwo = currentLevel + 1;
            
        }   
        else if (currentWorld == 2 && GameManager.instance.data.levelsUnlockedWorldTwoGameTwo < currentLevel + 1)
        {
            GameManager.instance.data.levelsUnlockedWorldTwoGameTwo = currentLevel + 1;
        }
        else
        {
            willShowAdd = false;
        }
            
    }

    public void ClaimReward() {

        StartCoroutine(ClaimRewardCoroutine());
    }

    private IEnumerator ClaimRewardCoroutine() {

        AsyncOperation scene = SceneManager.LoadSceneAsync("1-MainMenu");
        Time.timeScale = 1;

        GameManager.instance.CanvasMainMenu.SetActive(true);
        GameManager.instance.data.stars += starsReward;
        GameManager.instance.ActualizeData();
        GameManager.instance.loadingCanvas.SetActive(false);

        /*if (currentWorld == 1 && GameManager.instance.data.levelsUnlockedWorldOneGameTwo == currentLevel + 1)
        {
            if (willShowAdd && AdManager.instance.isReady[1])
            {
                //Muestra publicidad
                AdManager.instance.ShowRewardedAd();
            }
        }
        else if (currentWorld == 2 && GameManager.instance.data.levelsUnlockedWorldTwoGameTwo == currentLevel + 1)
        {
            if (willShowAdd && AdManager.instance.isReady[1])
            {
                //Muestra publicidad
                AdManager.instance.ShowRewardedAd();
            }
        }*/

        Destroy(JumperGameManager.instance.gameObject);
        while (!scene.isDone)
            yield return null;

        
    }

    private void UnlockCharacters()
    {
        if (unlockCard)
        {

            switch (cardToUnlock)
            {

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

    public void RestartedGame() {

        hudReference.ResetScore();
        hudReference.ResetCoinsCount();
        
    }
}
