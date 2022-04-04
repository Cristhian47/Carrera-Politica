using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AplastaZombies : MonoBehaviour
{
    private GameObject zombie;
    private bool wasUsed;

    public LayerMask zombieLayer;

    void Update()
    {
        if (!wasUsed)
        {
            //Vector3 rayCurrentPosition = new Vector3(transform.position.x - 0.5f, transform.position.y, transform.position.z);
            RaycastHit2D rightHit = Physics2D.Raycast(transform.position, Vector3.right, 2f, zombieLayer);
            Debug.DrawRay(transform.position, Vector3.right * 2f, Color.red, 2);

            RaycastHit2D leftHit = Physics2D.Raycast(transform.position, Vector3.left, 2f, zombieLayer);
            Debug.DrawRay(transform.position, Vector3.left * 2f, Color.red, 2);

            if (rightHit.collider != null)
            {
                wasUsed = true;
                zombie = rightHit.collider.gameObject;
                //zombie.GetComponent<Zombie>().enabled = false;
                //zombie.GetComponent<BoxCollider2D>().enabled = false;
                GetComponent<Animator>().SetBool("aplastaZombieRight", true);
            }
            else if (leftHit.collider != null)
            {
                wasUsed = true;
                zombie = leftHit.collider.gameObject;
                //zombie.GetComponent<Zombie>().enabled = false;
                //zombie.GetComponent<BoxCollider2D>().enabled = false;
                GetComponent<Animator>().SetBool("aplastaZombieLeft", true);
            }
        }
    }

    public void DestroyObjects()
    {
        if (zombie != null)
        {

            if (zombie.CompareTag("Animal"))
            {
                PlantsVsZombiesManager.instance.animalsObtained++;
                GameManager.instance.data.animalsCaptured++;
                Destroy(zombie);
                Destroy(gameObject);
            }
            else
            {
                PlantsVsZombiesManager.instance.zombiesKilled++;
                zombie.GetComponent<Zombie>().enabled = false;
                zombie.GetComponent<BoxCollider2D>().enabled = false;
                zombie.GetComponent<Animator>().enabled = false;
                zombie.transform.localScale = new Vector3(zombie.transform.localScale.x, 0.03f, zombie.transform.localScale.z);
                zombie.transform.position = new Vector3(zombie.transform.position.x,
                    zombie.transform.position.y - 0.35f, zombie.transform.position.z);
                Destroy(zombie, 2);
                Destroy(gameObject);
            }
        }
        else Destroy(gameObject);
    }
}
