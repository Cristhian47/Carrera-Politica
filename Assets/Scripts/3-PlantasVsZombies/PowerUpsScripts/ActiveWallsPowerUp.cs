using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveWallsPowerUp : MonoBehaviour
{

    private GameObject[] walls;
    private int wallsGenerated = 0;
    public GameObject wallPrefab;

    private void Awake() {
        
    }

    public void EnableWalls() {

        if(GameManager.instance.data.cantityOfPowerUpsThree > 0) {

            for (int i = 0; i < transform.childCount; i++) {

                if(transform.GetChild(i).childCount == 0) {
                    Instantiate(wallPrefab, transform.GetChild(i));
                    wallsGenerated++;
                }
            }

            if (wallsGenerated > 0)
                GameManager.instance.data.cantityOfPowerUpsThree--;

            wallsGenerated = 0;

        }
        
    }
}
