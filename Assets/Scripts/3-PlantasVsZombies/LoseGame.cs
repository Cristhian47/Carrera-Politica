using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseGame : MonoBehaviour
{
    public GameObject loseCanvas;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            Time.timeScale = 0;
            PlantsVsZombiesManager.instance.cardsIsAsigned = false;
            loseCanvas.SetActive(true);

            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Zombie");
            PlantsVsZombiesManager.instance.soundManager.SetActive(false);

            for (int i = 0; i < enemies.Length; i++)
            {
                enemies[i].GetComponent<BoxCollider2D>().enabled = false;
                enemies[i].GetComponent<Zombie>().enabled = false;
                enemies[i].GetComponent<Animator>().SetBool("zombiesWin", true);
            }
            
        }
    }
}
