using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hypno : MonoBehaviour
{
    public LayerMask zombieLayer;

     //Suavizar el movimiento del personaje para que pelee con el otro zombie al ser hipnotisado con otro zombie a su lado
    private IEnumerator MoveObject(GameObject objectToMove)
    {
        int i = 0;
        while (i < 30)
        {

            objectToMove.transform.localPosition = new Vector3(objectToMove.transform.position.x - (1 / 30), objectToMove.transform.position.y,
            objectToMove.transform.position.z);
            i++;
            yield return new WaitForSeconds(1f);
        }
    }

    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.right, 1.5f, zombieLayer);
        Debug.DrawRay(transform.position, Vector3.right * 1.5f, Color.red, 2);

        if(hit.collider != null && hit.collider.tag == "Animal")
        {
            Destroy(hit.collider.gameObject);
        }

        if(hit.collider != null && hit.collider.tag != "Animal")
        {
            //Suavizar el movimiento del personaje para que pelee con el otro zombie al ser hipnotisado con otro zombie a su lado
            StartCoroutine(MoveObject(hit.collider.gameObject));

            GetComponent<AudioSource>().Play();

            hit.collider.transform.localPosition = new Vector3(hit.collider.transform.position.x - 1, hit.collider.transform.position.y,
                hit.collider.transform.position.z);
            GetComponent<Animator>().SetInteger("AttackOption", 1);
            hit.collider.transform.localScale = new Vector3(-hit.collider.transform.localScale.x,
                hit.collider.transform.localScale.y, hit.collider.transform.localScale.z);

            //hit.collider.GetComponent<Zombie>().life = hit.collider.GetComponent<Zombie>().life / 2;

            hit.collider.GetComponent<Zombie>().speedMovement *= -1;
            //PlantsVsZombiesManager.instance.zombiesDetectionDirection = Vector3.right;
            hit.collider.GetComponent<Zombie>().auxiliaryVelocity *= -1;
            hit.collider.gameObject.layer = 12;
            hit.collider.GetComponent<Zombie>().layerPlant = zombieLayer;
            Destroy(gameObject,0.3f);
        }
    }
}
