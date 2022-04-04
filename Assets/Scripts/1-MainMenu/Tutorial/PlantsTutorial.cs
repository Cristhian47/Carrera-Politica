using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlantsTutorial : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite dragSprite;
    public Sprite asignedCard;       //Contiene la referencia al sprite de la carta asignada de la planta
    public int sunsPrice;       //Contiene la cantidad de soles
    public int life;
    public float cooldownTime;

    public GameObject cooldownObject;

    private void Eat()
    {
        life--;
        if (life <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void NoAttack()
    {
        GetComponent<Animator>().SetBool("skillActive", false);
    }

    public void StartCooldown()
    {
        //PVZManagerTutorial.instance.StartCooldown(cooldownObject.transform.parent.gameObject, cooldownTime);
        //float timeLapse = 0;
        //StartCoroutine(StartCooldown(timeLapse));
    }

    private IEnumerator StartCooldown(float currentTime)
    {
        cooldownObject.transform.parent.GetComponent<EventTrigger>().enabled = false;
        cooldownObject.transform.parent.GetComponent<Button>().enabled = false;

        while (currentTime <= cooldownTime)
        {
            cooldownObject.GetComponent<Image>().fillAmount = (1 / cooldownTime) * currentTime;
            currentTime += Time.deltaTime;
            yield return null;
        }

        cooldownObject.GetComponent<Image>().fillAmount = 0;
        cooldownObject.transform.parent.GetComponent<EventTrigger>().enabled = true;
        cooldownObject.transform.parent.GetComponent<Button>().enabled = true;
        yield return null;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Pig")
        {
            Debug.Log("EXPLOTAAAAAAAAA");
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }
}
