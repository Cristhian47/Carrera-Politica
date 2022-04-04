using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieTutorial : MonoBehaviour
{
    Vector3 initalPoint;
    RaycastHit2D hit;

    private float tiempoMordidaAuxiliar = 0;
    private bool isSlowed;
    private bool isOnFire;
    public float auxiliaryVelocity;
    private Vector3 detectionState;

    public int life = 4;
    public float speedMovement;
    public LayerMask layerPlant;
    public float tiempoMordida = 1;
    public float dropStarProbability;
    public GameObject starPrefab;

    public int zombieVelocityAnimation = 2;

    private void Start()
    {
        detectionState = Vector3.left;
        auxiliaryVelocity = speedMovement;

        if (zombieVelocityAnimation >= 1 || zombieVelocityAnimation <= 3)
            GetComponent<Animator>().SetInteger("zombieVelocity", zombieVelocityAnimation);

        //life += ((PlantsVsZombiesManager.instance.currentTime) / 2);
        if (PVZManagerTutorial.instance.currentTime >= 60)
            life += ((PVZManagerTutorial.instance.currentTime + (PVZManagerTutorial.instance.currentTime / 1)) / 2);
        //life += Mathf.RoundToInt(PlantsVsZombiesManager.instance.currentTime * Mathf.Log(PlantsVsZombiesManager.instance.currentTime, 2));
    }

    private void Update()
    {

        if (speedMovement < 0)
        {
            initalPoint = new Vector3(transform.position.x + 1, transform.position.y - 0.8f, transform.position.z);
            hit = Physics2D.Raycast(initalPoint, Vector3.right, 0.5f, layerPlant);
            Debug.DrawRay(initalPoint, Vector3.right * 0.5f, Color.red, 2);
        }
        else if (speedMovement > 0)
        {
            initalPoint = new Vector3(transform.position.x - 1, transform.position.y - 0.8f, transform.position.z);
            hit = Physics2D.Raycast(initalPoint, Vector3.left, 0.5f, layerPlant);
            Debug.DrawRay(initalPoint, Vector3.left * 0.5f, Color.red, 2);
        }

        if (hit.collider == null && speedMovement == 0)
        {

            speedMovement = auxiliaryVelocity;
            GetComponent<Animator>().SetInteger("AttackOption", 0);
        }

        if (hit.collider != null && hit.collider.tag != "Animal")
        {
            Debug.Log(hit.collider);
            tiempoMordidaAuxiliar += Time.deltaTime;
            speedMovement = 0;

            if (tiempoMordidaAuxiliar >= tiempoMordida)
            {
                tiempoMordidaAuxiliar = 0;
                GetComponent<Animator>().SetInteger("AttackOption", Random.Range(1, 3));
                hit.collider.SendMessage("Eat");

            }
        }
        else
        {
            speedMovement = auxiliaryVelocity;
            GetComponent<Animator>().SetInteger("AttackOption", 0);
            tiempoMordidaAuxiliar = 0;
            transform.position += Vector3.left * speedMovement * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Guisante") && this.gameObject.layer == 8)
        {
            PVZManagerTutorial.instance.DanielWasPressed = true;
            auxiliaryVelocity = 0.45f;
            speedMovement = 0.45f;

            life -= collision.gameObject.GetComponent<Guisante>().daño;
            Destroy(collision.gameObject);

            if (life <= 0)
            {
                PVZManagerTutorial.instance.ZombieWasKilled = true;
                GetComponent<BoxCollider2D>().enabled = false;
                tiempoMordida = 20;
                PVZManagerTutorial.instance.zombiesKilled++;
                speedMovement = 0;
                auxiliaryVelocity = 0;
                GetComponent<AudioSource>().Play();
                GetComponent<Animator>().SetBool("isDie", true);
                DropStar();
                Destroy(gameObject, 3);
            }

            if (collision.GetComponent<Guisante>().isOnFire)
            {
                if (!isOnFire)
                {
                    StartCoroutine(PVZManagerTutorial.instance.ZombieOnFire(gameObject));
                    isOnFire = true;
                }
            }
            if (collision.GetComponent<Guisante>().isOnIce)
            {
                if (!isSlowed)
                {
                    PVZManagerTutorial.instance.SlowZombie(gameObject);
                    isSlowed = true;
                }
            }
        }

        /*if (collision.CompareTag("FailState"))
        {
            Debug.Log("Has perdido!");
        }*/
    }

    /*private void OnDestroy()
    {
        if (dropStarProbability < 0) dropStarProbability = 0;
        if (dropStarProbability > 100) dropStarProbability = 100;
        float value = Random.Range(0, 100);

        if(value <= dropStarProbability)
        {
            Instantiate(starPrefab, transform.position, Quaternion.identity);
        }
    }*/

    private void DropStar()
    {
        if (dropStarProbability < 0) dropStarProbability = 0;
        if (dropStarProbability > 100) dropStarProbability = 100;
        float value = Random.Range(0, 100);

        if (value <= dropStarProbability)
        {
            Vector3 positionToIntantiate = new Vector3(transform.position.x, transform.position.y, -8f);
            Instantiate(starPrefab, positionToIntantiate, Quaternion.identity);
        }
    }

    private void Eat()
    {
        life--;
        if (life <= 0)
        {
            
            Destroy(gameObject);
        }
    }
}
