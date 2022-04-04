 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    Vector3 initalPoint;
    RaycastHit2D hit;

    private AudioSource audioSource;
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
    public bool isStuned;

    public AudioClip[] zombieSounds;

    public int zombieVelocityAnimation = 2;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        detectionState = Vector3.left;
        auxiliaryVelocity = speedMovement;

        if (zombieVelocityAnimation >= 1 || zombieVelocityAnimation <= 3)
            GetComponent<Animator>().SetInteger("zombieVelocity", zombieVelocityAnimation);

        //life += ((PlantsVsZombiesManager.instance.currentTime) / 2);
        if(PlantsVsZombiesManager.instance.currentTime >= 60)
            life += ((PlantsVsZombiesManager.instance.currentTime + (PlantsVsZombiesManager.instance.currentTime / 1))/2);
        //life += Mathf.RoundToInt(PlantsVsZombiesManager.instance.currentTime * Mathf.Log(PlantsVsZombiesManager.instance.currentTime, 2));
    }

    private void OnBecameVisible() {

        audioSource.clip = zombieSounds[Random.Range(2,4)];
        audioSource.volume = 0.15f;
        audioSource.Play();
        audioSource.volume = 1;
    }

    private void Update()
    {
        


       if(speedMovement < 0)
        {
            initalPoint = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
            hit = Physics2D.Raycast(initalPoint, Vector3.right, 0.4f, layerPlant);
            Debug.DrawRay(initalPoint, Vector3.right * 0.4f, Color.red, 2);
        }
        else if(speedMovement > 0)
        {
            initalPoint = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z);
            hit = Physics2D.Raycast(initalPoint, Vector3.left, 0.4f, layerPlant);
            Debug.DrawRay(initalPoint, Vector3.left * 0.4f, Color.red, 2);
        }

        if(hit.collider == null && speedMovement == 0) {

            speedMovement = auxiliaryVelocity;
            GetComponent<Animator>().SetInteger("AttackOption", 0);
        }

        if (isStuned)
        {
            speedMovement = 0;
        } else speedMovement = auxiliaryVelocity;
        
        if (hit.collider != null && hit.collider.tag != "Animal")
        {
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
            
            GetComponent<Animator>().SetInteger("AttackOption", 0);
            tiempoMordidaAuxiliar = 0;
            transform.position += Vector3.left * speedMovement * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Guisante") && this.gameObject.layer == 8)
        {
            life-= collision.gameObject.GetComponent<Guisante>().daño;
            Destroy(collision.gameObject);

            audioSource.clip = zombieSounds[Random.Range(4, 7)];
            audioSource.volume = 0.15f;
            audioSource.Play();
            audioSource.volume = 1;

            if (life <= 0)
            {
                audioSource.clip = zombieSounds[0];
                audioSource.Play();
                GetComponent<BoxCollider2D>().enabled = false;
                tiempoMordida = 20;
                PlantsVsZombiesManager.instance.zombiesKilled++;
                speedMovement = 0;
                auxiliaryVelocity = 0;
                GetComponent<Animator>().SetBool("isDie", true);
                DropStar();
                Destroy(gameObject,3);
            }

            if (collision.GetComponent<Guisante>().isOnFire)
            {
                if (!isOnFire)
                {
                    StartCoroutine(PlantsVsZombiesManager.instance.ZombieOnFire(gameObject));
                    isOnFire = true;
                }
            }
            if (collision.GetComponent<Guisante>().isOnIce)
            {
                if (!isSlowed)
                {
                    audioSource.clip = zombieSounds[1];
                    audioSource.Play();
                    transform.GetChild(5).gameObject.SetActive(true);
                    PlantsVsZombiesManager.instance.SlowZombie(gameObject);
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
