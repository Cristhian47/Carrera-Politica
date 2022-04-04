using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Animals
{
    public GameObject animalPrefab;
    public string name;
}

public class AnimalsSpawn : MonoBehaviour
{
    private float currentValue = 0.0f;
    private int indexAnimalToSpawn = 0;
    private int indexPositionToSpawn = 0;
    private Vector3 positionToSpawn;

    public Transform[] pointsToSpawn;
    public Animals[] animalsSprites;
    public float probabilityToSpawn;
    public int secondsBetweenProbability;

    //public GameObject animalPrefab;

    private IEnumerator Start()
    {
        while (true)
        {
            currentValue = UnityEngine.Random.Range(0, 100);
            if(currentValue <= probabilityToSpawn)
            {
                indexAnimalToSpawn = UnityEngine.Random.Range(0, animalsSprites.Length - 1);
                indexPositionToSpawn = UnityEngine.Random.Range(0, pointsToSpawn.Length - 1);

                positionToSpawn = new Vector3(pointsToSpawn[indexPositionToSpawn].position.x,
                    pointsToSpawn[indexPositionToSpawn].position.y,
                    pointsToSpawn[indexPositionToSpawn].position.z);

                GameObject go = Instantiate(animalsSprites[indexAnimalToSpawn].animalPrefab, positionToSpawn, Quaternion.identity);
                //.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = animalsSprites[indexAnimalToSpawn].animalSprite;
                go.name = animalsSprites[indexAnimalToSpawn].name;

                if (indexPositionToSpawn >= 0 && indexPositionToSpawn <= 3)
                    go.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sortingLayerName = "Linea1";
                else if (indexPositionToSpawn > 3 && indexPositionToSpawn <= 7)
                    go.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sortingLayerName = "Linea2";
                else if (indexPositionToSpawn > 7 && indexPositionToSpawn <= 11)
                    go.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sortingLayerName = "Linea3";
                else if (indexPositionToSpawn > 11 && indexPositionToSpawn <= 15)
                    go.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sortingLayerName = "Linea4";
                else if (indexPositionToSpawn > 15 && indexPositionToSpawn <= 19)
                    go.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sortingLayerName = "Linea5";

            }
            //Debug.Log("funciona");
            yield return new WaitForSeconds(secondsBetweenProbability);
        }
    }
}
