using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOneLine : MonoBehaviour
{
    public float speedMovement;

    private void Start()
    {
        Destroy(gameObject, 20f);
        transform.position = new Vector3(transform.position.x, transform.position.y + 0.7f, transform.position.z);


    }

    private void Update()
    {
        transform.position += Vector3.right * speedMovement * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            collision.gameObject.GetComponent<Zombie>().enabled = false;
            collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            collision.gameObject.GetComponent<Animator>().enabled = false;
            collision.gameObject.transform.localScale = new Vector3(collision.gameObject.transform.localScale.x,
                0.05f, collision.gameObject.transform.localScale.z);
            collision.gameObject.transform.position = new Vector3(collision.gameObject.transform.position.x,
                collision.gameObject.transform.position.y - 0.8f, collision.gameObject.transform.position.z);
            Destroy(collision.gameObject,3);
        }
    }
}
