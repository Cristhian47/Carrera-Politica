using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Challenges : MonoBehaviour
{
    [Space(20)]
    public bool plantsVsZombies;
    public bool jumper;
    public bool angryBirds;
    public bool runner;

    [Space(10)]
    public string challengeName;
    public string challengeDescription;

    [Space(10)]
    public int level;
    public int world;

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

    public int pointToDo;
    public int starsToGetJumper;

    [Space(20)]
    public int starsReward;
    public int clothID;
    public Sprite characterImage;

    [Space(20)]
    public Sprite spriteOfWorld;

    [Space(20)]
    public bool unlockCharacters;
    public int characterToUnlock;
    public Sprite unlockedPlantImage;
    public string description;
    [Space(20)]
    public bool willShowAdd;

    
    //public static Challenges instancePlantsVsZombies;

    private void Awake()
    {
        /*
        if (Challenges.instancePlantsVsZombies == null)
        {
            Challenges.instancePlantsVsZombies = this;
        }
        else if (Challenges.instancePlantsVsZombies != null)
            Destroy(gameObject);*/

        //DontDestroyOnLoad(GetComponentInParent<Canvas>().gameObject);
        //DontDestroyOnLoad(GameObject.FindGameObjectWithTag("NextChallenges"));
        
        //DontDestroyOnLoad(transform.gameObject);
        //DontDestroyOnLoad(this.gameObject);
    }

    /*
    private void Update()
    {
        if (GameManager.instance.levelName == gameObject.name)
        {
            GameManager.instance.levelObject = this.gameObject;
        }
    }*/
}
