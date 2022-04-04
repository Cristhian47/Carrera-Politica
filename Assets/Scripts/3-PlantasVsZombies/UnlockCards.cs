using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockCards : MonoBehaviour
{
    public int numberOfCard;

    public Sprite lockSprite;

    private void OnEnable() { 

        if (numberOfCard == 3)
        {
            //valida si no tiene la carta y la bloquea o no
            CardValidation(GameManager.instance.data.haveCardThree);
        }
        else if (numberOfCard == 4)
        {
            //valida si no tiene la carta y la bloquea o no
            CardValidation(GameManager.instance.data.haveCardFour);

        }
        else if (numberOfCard == 5)
        {
            //valida si no tiene la carta y la bloquea o no
            CardValidation(GameManager.instance.data.haveCardFive);
        }
        else if (numberOfCard == 6)
        {
            //valida si no tiene la carta y la bloquea o no
            CardValidation(GameManager.instance.data.haveCardSix);
        }
        else if (numberOfCard == 7)
        {
            //valida si no tiene la carta y la bloquea o no
            CardValidation(GameManager.instance.data.haveCardSeven);
        }
        else if (numberOfCard == 8)
        {
            //valida si no tiene la carta y la bloquea o no
            CardValidation(GameManager.instance.data.haveCardEight);
        }
        else if (numberOfCard == 9)
        {
            //valida si no tiene la carta y la bloquea o no
            CardValidation(GameManager.instance.data.haveCardNine);
        }
        else if (numberOfCard == 10)
        {
            //valida si no tiene la carta y la bloquea o no
            CardValidation(GameManager.instance.data.haveCardTen);
        }

    }

    private void CardValidation(bool haveCard)
    {
        if (!haveCard)
        {
            gameObject.GetComponent<Image>().sprite = lockSprite;
            gameObject.GetComponent<Button>().enabled = false;
        }
    }
}
