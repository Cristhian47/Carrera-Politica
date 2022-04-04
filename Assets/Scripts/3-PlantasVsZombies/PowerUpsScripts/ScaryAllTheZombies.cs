using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaryAllTheZombies : MonoBehaviour
{
    public float speedMovement;
    public float timeStuned;

    private IEnumerator Start()
    {
        GameObject[] go = GameObject.FindGameObjectsWithTag("Zombie");
        
        for(int i = 0; i < go.Length; i++)
        {
            go[i].GetComponent<Zombie>().speedMovement = 0;
            go[i].GetComponent<Zombie>().auxiliaryVelocity = 0;
        }

        transform.localScale = Vector3.zero;
        yield return new WaitForSeconds(timeStuned);

        for (int i = 0; i < go.Length; i++)
        {
            go[i].GetComponent<Zombie>().speedMovement = 0.32f;
            go[i].GetComponent<Zombie>().auxiliaryVelocity = 0.32f;
        }

        Destroy(gameObject);
    }

    private void Update()
    {
        //transform.position += Vector3.right * speedMovement * Time.deltaTime;
    }
}
