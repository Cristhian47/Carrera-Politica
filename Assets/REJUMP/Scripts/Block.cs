using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Block : MonoBehaviour 
{
    private GetJumperChallengeValues challengeValues;

    public bool chillBlock;             //Is block type is chill, this means player can stand on it unlimited time amount;
    public GameObject chillIcon;        //Chill icon sprite for visualazing this chill block is enabled or not;

    public Sprite worldTwoPlatformSprite;

    private void Awake()
    {
        challengeValues = GameObject.Find("GetChallengesValues").GetComponent<GetJumperChallengeValues>();
    }


    IEnumerator Start()
    {
        if (challengeValues.currentWorld == 2)
            GetComponent<SpriteRenderer>().sprite = worldTwoPlatformSprite;

        //Wait untill game is started;
        while (!Game.isGameStarted)
            yield return null;

        //Set chill state to assigned value;
        SetChillBlock(chillBlock);
    }

    //Chill block toggle accesor;
    public void SetChillBlock(bool isChill)
    {
        //Set chill block to passed value;
        chillBlock = isChill;

        //Enable block's chill icon;
        if (chillIcon)
            chillIcon.SetActive(isChill);
    }
}