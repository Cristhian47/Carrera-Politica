using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnableCharactersPurchased : MonoBehaviour
{

    public PauseMenu pauseMenuReference;

    public void Start() {

        if (GameManager.instance.data.haveCharacterTwo) {
            BuyCharacter(1);
        }
        if (GameManager.instance.data.haveCharacterThree) {
            BuyCharacter(2);
        }
        if (GameManager.instance.data.haveCharacterFour) {
            BuyCharacter(3);
        }
        if (GameManager.instance.data.haveCharacterFive) {
            BuyCharacter(4);
        }
        if (GameManager.instance.data.haveCharacterSix) {
            BuyCharacter(5);
        }
        if (GameManager.instance.data.haveCharacterSeven) {
            BuyCharacter(9);
        }
        if (GameManager.instance.data.haveCharacterEight) {
            BuyCharacter(7);
        }
        if (GameManager.instance.data.haveCharacterNine) {
            BuyCharacter(8);
        }
        if (GameManager.instance.data.haveCharacterTen) {
            BuyCharacter(9);
        }
        if (GameManager.instance.data.haveCharacterEleven) {
            BuyCharacter(10);
        }
        if (GameManager.instance.data.haveCharacterTwelve) {
            BuyCharacter(11);
        }
        if (GameManager.instance.data.haveCharacterThirteen) {
            BuyCharacter(12);
        }
        if (GameManager.instance.data.haveCharacterFourteen) {
            BuyCharacter(13);
        }
        if (GameManager.instance.data.haveCharacterFifteen) {
            BuyCharacter(14);
        }
        if (GameManager.instance.data.haveCharacterSixteen) {
            BuyCharacter(15);
        }

    }

    //Buy charater function;
    void BuyCharacter(int index)
    {
        pauseMenuReference.shop.characters[index].unlockButton.interactable = true;
        pauseMenuReference.shop.characters[index].unlocked = true;                                         //Set character as unlocked;
        pauseMenuReference.shop.characters[index].buttonIcon.sprite = pauseMenuReference.shop.unlockButtonIcons.unlocked;     //Change button sprite to unlocked;
    }
}
