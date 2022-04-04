using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class StoreManager : MonoBehaviour
{
    [Space(20)]
    //SECCION DE PERSONAJES
    public bool haveCharacterOne;
    public bool haveCharacterTwo;
    public bool haveCharacterThree;
    public bool haveCharacterFour;
    public bool haveCharacterFive;
    public bool haveCharacterSix;
    public bool haveCharacterSeven;
    public bool haveCharacterEight;
    public bool haveCharacterNine;
    public bool haveCharacterTen;

    [Space(20)]
    //SECCION DE MUNDOS
    public bool haveDanielHouse; //Plantas vs zombies
    public bool haveUberrismo;  //Runner
    public bool haveSnowy; //Jumper
    public bool haveNationalUniversity; //AngryBirds
    public bool havePalace;    //Plantas vs zombies

    [Space(20)]
    //SECCION DE ROPA
    public bool haveCapOne;
    public bool haveCapTwo;
    public bool haveCapThree;
    public bool haveNecklaceOne;
    public bool haveNecklaceTwo;

    [Space(20)]
    //SECCION DE POWERUPS
    public bool havePowerUpOne;
    public bool havePowerUpTwo;
    public bool havePowerUpThree;

    [Space(20)]
    public Text titleText;
    public Text nameText;
    public Text descriptionText;

    //----------------------------------------------------------

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        
        //GameManager.instance.dontDestroyObjects.Add(gameObject);
    }

    //----------------------------------------------------------

    //-----------FUNCIONES-DE-PERSONAJES------------
    public void BuyCharacterOne()
    {
        //BuyOrSelectCharacter(haveCharacterOne);

        if (!GameManager.instance.data.haveCharacterOne)
        {
            //activeBuyCanvas.Invoke();
            GameManager.instance.data.haveCharacterOne = true;
            //Desbloquea personaje
        }
        else
        {
            //Selecciona personaje
        }
    }

    public void BuyCharacterTwo()
    {
        //BuyOrSelectCharacter(haveCharacterTwo);

        if (!GameManager.instance.data.haveCharacterTwo)
        {
            GameManager.instance.data.haveCharacterTwo = true;
            //Desbloquea personaje
        }
        else
        {
            //Selecciona personaje
        }
    }

    public void BuyCharacterThree()
    {
        //BuyOrSelectCharacter(haveCharacterThree);

        if (!GameManager.instance.data.haveCharacterThree)
        {
            GameManager.instance.data.haveCharacterThree = true;
            //Desbloquea personaje
        }
        else
        {
            //Selecciona personaje
        }
    }

    public void BuyCharacterFour()
    {
        //BuyOrSelectCharacter(haveCharacterFour);

        if (!GameManager.instance.data.haveCharacterFour)
        {
            GameManager.instance.data.haveCharacterFour = true;
            //Desbloquea personaje
        }
        else
        {
            //Selecciona personaje
        }
    }

    public void BuyCharacterFive()
    {
        //BuyOrSelectCharacter(haveCharacterFive);

        if (!GameManager.instance.data.haveCharacterFive)
        {
            GameManager.instance.data.haveCharacterFive = true;
            //Desbloquea personaje
        }
        else
        {
            //Selecciona personaje
        }
    }

    public void BuyCharacterSix()
    {
        //BuyOrSelectCharacter(haveCharacterSix);

        if (!GameManager.instance.data.haveCharacterSix)
        {
            GameManager.instance.data.haveCharacterSix = true;
            //Desbloquea personaje
        }
        else
        {
            //Selecciona personaje
        }
    }

    public void BuyCharacterSeven()
    {
        //BuyOrSelectCharacter(haveCharacterSeven);

        if (!GameManager.instance.data.haveCharacterSeven)
        {
            GameManager.instance.data.haveCharacterSeven = true;
            //Desbloquea personaje
        }
        else
        {
            //Selecciona personaje
        }
    }

    public void BuyCharacterEight()
    {
        //BuyOrSelectCharacter(haveCharacterEight);

        if (!GameManager.instance.data.haveCharacterEight)
        {
            GameManager.instance.data.haveCharacterEight = true;
            //Desbloquea personaje
        }
        else
        {
            //Selecciona personaje
        }
    }

    public void BuyCharacterNine()
    {
        //BuyOrSelectCharacter(haveCharacterNine);

        if (!GameManager.instance.data.haveCharacterNine)
        {
            GameManager.instance.data.haveCharacterNine = true;
            //Desbloquea personaje
        }
        else
        {
            //Selecciona personaje
        }
    }

    public void BuyCharacterTen()
    {
        //BuyOrSelectCharacter(haveCharacterTen);

        if (!GameManager.instance.data.haveCharacterTen)
        {
            GameManager.instance.data.haveCharacterTen = true;
            //Desbloquea personaje
        }
        else
        {
            //Selecciona personaje
        }
    }

    public void BuyCharacterEleven()
    {
        //BuyOrSelectCharacter(haveCharacterTen);

        if (!GameManager.instance.data.haveCharacterEleven)
        {
            GameManager.instance.data.haveCharacterEleven = true;
            //Desbloquea personaje
        }
        else
        {
            //Selecciona personaje
        }
    }

    public void BuyCharacterTwelve()
    {
        //BuyOrSelectCharacter(haveCharacterTen);

        if (!GameManager.instance.data.haveCharacterTwelve)
        {
            GameManager.instance.data.haveCharacterTwelve = true;
            //Desbloquea personaje
        }
        else
        {
            //Selecciona personaje
        }
    }

    public void BuyCharacterThirteen()
    {
        //BuyOrSelectCharacter(haveCharacterTen);

        if (!GameManager.instance.data.haveCharacterThirteen)
        {
            GameManager.instance.data.haveCharacterThirteen = true;
            //Desbloquea personaje
        }
        else
        {
            //Selecciona personaje
        }
    }

    public void BuyCharacterFourteen()
    {
        //BuyOrSelectCharacter(haveCharacterTen);

        if (!GameManager.instance.data.haveCharacterFourteen)
        {
            GameManager.instance.data.haveCharacterFourteen = true;
            //Desbloquea personaje
        }
        else
        {
            //Selecciona personaje
        }
    }

    public void BuyCharacterFifteen()
    {
        //BuyOrSelectCharacter(haveCharacterTen);

        if (!GameManager.instance.data.haveCharacterFifteen)
        {
            GameManager.instance.data.haveCharacterFifteen = true;
            //Desbloquea personaje
        }
        else
        {
            //Selecciona personaje
        }
    }

    public void BuyCharacterSixteen()
    {
        //BuyOrSelectCharacter(haveCharacterTen);

        if (!GameManager.instance.data.haveCharacterSixteen)
        {
            GameManager.instance.data.haveCharacterSixteen = true;
            //Desbloquea personaje
        }
        else
        {
            //Selecciona personaje
        }
    }

    private void BuyOrSelectCharacter(bool haveCharacter)
    {
        if (!haveCharacter)
        {
            //Desbloquea personaje
        }
        else
        {
            //Selecciona personaje
        }
    }

    //-----------FUNCIONES-DE-MUNDOS------------

    public void BuyWorldOneGameOne()
    {
        //Habilita el mundo de la casa de daniel en el plantas vs zombies
    }

    public void BuyWorldTwoGameOne()
    {
        //Habilita el mundo del uberrismo en el runner
        GameManager.instance.data.haveWorldTwoGameOne = true;
    }

    public void BuyWorldThreeGameOne()
    {
        //Habilita el mundo del nevado en el jumper
        GameManager.instance.data.haveWorldThreeGameOne = true;
    }

    public void BuyWorldOneGameTwo()
    {
        //Habilita el mundo de la universidad nacional en el angry birds
    }

    public void BuyWorldTwoGameTwo()
    {
        //Habilita el mundo de el palacio en el plantas vs zombies
        GameManager.instance.data.haveWorldTwoGameTwo = true;
    }

    public void BuyWorldThreeGameTwo()
    {
        //Habilita el mundo de el palacio en el plantas vs zombies
        GameManager.instance.data.haveWorldThreeGameTwo = true;
    }

    //-----------FUNCIONES-DE-ROPA------------

    public void BuyClothOne()
    {
        nameText.text = "Casco de olla";
        descriptionText.text = "Casco de olla, sombrero...";

        //BuyOrSelectCloth(haveCapOne);
        GameManager.instance.data.haveClothOne = true;
    }

    public void BuyClothTwo()
    {
        nameText.text = "Gorra Danny";
        descriptionText.text = "Gorra de danny, gorra con el logo de hola soy danny, el preferido de los fans";
        GameManager.instance.data.haveClothTwo = true;
    }

    public void BuyClothThree()
    {
        nameText.text = "Gorro de bruja";
        descriptionText.text = "Gorra de bruja, dicen que si te lo pones obtienes un poder superior al de los senadores";
        GameManager.instance.data.haveClothThree = true;
    }

    public void BuyClothFour()
    {
        nameText.text = "Collar de arepas";
        descriptionText.text = "Collar de arepas, con este collar te conviertes en uno de los cantores del chipuco";
        GameManager.instance.data.haveClothFour = true;
    }

    public void BuyClothFive()
    {
        nameText.text = "Gafas reguetón";
        descriptionText.text = "Gafas reguetón, con esta prenda te conviertes originalmente en un regetoneros";
        GameManager.instance.data.haveClothFive = true;
    }

    public void BuyClothSix()
    {
        nameText.text = "Nariz marrano";
        descriptionText.text = "Nariz de marrano, un día en el congreso hicieron lechona y pusieron a la venta la nariz";
        GameManager.instance.data.haveClothSix = true;
    }

    //-----------FUNCIONES-DE-POWERUPS------------

    public void BuyPowerUpOne()
    {
        nameText.text = "Ayudante 1";
        descriptionText.text = "el ayudante 1 en la batalla politica te permitira congelar a todos, en el jumper, duplica las estrellas obtenidas por ti";

        //Suma 1 al contador del powerUp uno
        GameManager.instance.data.cantityOfPowerUpsOne++;
        GameManager.instance.SaveChanges();
    }

    public void BuyPowerUpTwo()
    {
        nameText.text = "Ayudante 2";
        descriptionText.text = "el ayudante 2 en la batalla politica te permitira asustar a todos, en el jumper, utilizara un iman para recolectar mas estrellas para ti";
        //Suma 1 al contador del powerUp dos
        GameManager.instance.data.cantityOfPowerUpsTwo++;
        GameManager.instance.SaveChanges();
    }

    public void BuyPowerUpThree()
    {
        nameText.text = "Ayudante 3";
        descriptionText.text = "el ayudante 3 en la batalla politica te permitira aplastar a todos los enemigos de una linea, en el jumper, te impulsara hacia el cielo a toda velocidad";
        //Suma 1 al contador del powerUp tres
        GameManager.instance.data.cantityOfPowerUpsThree++;
        GameManager.instance.SaveChanges();
    }

    //-----------FUNCIONES-DE-CORAZONES------------

    public void Buy1Heart(){

        nameText.text = "Corazones x1";
        descriptionText.text = "Los corazones te permiten continuar una partida si ya perdiste";
        GameManager.instance.data.hearts++;
    }

    public void Buy10Hearts(){
        nameText.text = "Corazones x10";
        descriptionText.text = "Los corazones te permiten continuar una partida si ya perdiste";
        GameManager.instance.data.hearts += 10;
    }

    public void Buy20Hearts(){
        nameText.text = "Corazones x20";
        descriptionText.text = "Los corazones te permiten continuar una partida si ya perdiste";
        GameManager.instance.data.hearts += 20;
    }
}
