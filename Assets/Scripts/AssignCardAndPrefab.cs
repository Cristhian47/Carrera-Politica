using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

[Serializable]
public class Character
{
    public Sprite card;
    public GameObject characterPrefab;
}

public class AssignCardAndPrefab : MonoBehaviour
{
    public Character[] characters;

    // Start is called before the first frame update
    void Start()
    {
        PlantsVsZombiesManager.instance.characterToUse = characters[GameManager.instance.playerSelectedIndex].characterPrefab;

        PlantsVsZombiesManager.instance.prefabCard.transform.GetChild(0).GetComponent<Image>().sprite = characters[GameManager.instance.playerSelectedIndex].card;
        GetComponent<Image>().sprite = characters[GameManager.instance.playerSelectedIndex].card;
        
        GetComponent<PlantSelected>().plant = characters[GameManager.instance.playerSelectedIndex].characterPrefab.GetComponent<Plants>();
        transform.GetChild(0).GetChild(0).GetComponent<Text>().text = characters[GameManager.instance.playerSelectedIndex].characterPrefab.name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
