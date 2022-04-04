using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UsePowerUp : MonoBehaviour
{
    private bool isHolding;
    private bool canUsePowerUp = false;
    private bool isLoading = false;
    private GameObject nextPowerUp;

    public Sprite dragSprite;
    public GameObject powerUp;
    public int numberOfPowerUp;
    public Text textoCantidad;

    public int cooldown;
    
    void Start()
    {
        //nextPowerUp = GameObject.Find("ShowNextPlant");

        nextPowerUp = new GameObject();
        Instantiate(nextPowerUp);
        nextPowerUp.AddComponent<SpriteRenderer>();

        gameObject.AddComponent<EventTrigger>();

        if(numberOfPowerUp == 3)
        {
            EventTrigger trigger = gameObject.GetComponent<EventTrigger>();
            EventTrigger.Entry entry = new EventTrigger.Entry();
            entry.eventID = EventTriggerType.PointerDown;

            entry.callback.AddListener((eventData) => { isHolding = true; });
            entry.callback.AddListener((eventData) => { ClearButtons(transform.parent); });
            entry.callback.AddListener((eventData) => { gameObject.GetComponent<Image>().color = Color.blue; });
            entry.callback.AddListener((eventData) => { nextPowerUp.GetComponent<SpriteRenderer>().sprite = dragSprite; });
            entry.callback.AddListener((eventData) => { nextPowerUp.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f); });
            entry.callback.AddListener((eventData) => { canUsePowerUp = true; });
            trigger.triggers.Add(entry);
        }
        else
        {
            EventTrigger trigger = gameObject.GetComponent<EventTrigger>();
            EventTrigger.Entry entry = new EventTrigger.Entry();
            entry.eventID = EventTriggerType.PointerClick;

            entry.callback.AddListener((eventData) => { ValidationsPowerUps(); });
            trigger.triggers.Add(entry);
        }
        
    }

    public void ClearButtons(Transform deckTransform)
    {
        for (int i = 0; i < deckTransform.childCount; i++)
        {
            deckTransform.GetChild(i).gameObject.GetComponent<Image>().color = Color.white;
        }
    }

    void Update()
    {
        if (isHolding)
        {
            //gameObject.GetComponent<Image>().color = Color.white;
            Vector3 currentScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
            nextPowerUp.transform.position = Camera.main.ScreenToWorldPoint(currentScreenSpace);
            DetectMouseInteraction(Input.GetMouseButtonUp(0));
        }
        else
        {
            nextPowerUp.GetComponent<SpriteRenderer>().sprite = null;
            DetectMouseInteraction(Input.GetMouseButtonDown(0));
        }

        if (numberOfPowerUp == 2)
            textoCantidad.text = GameManager.instance.data.cantityOfPowerUpsTwo.ToString();
        if (numberOfPowerUp == 3)
            textoCantidad.text = GameManager.instance.data.cantityOfPowerUpsOne.ToString();
    }

    private void DetectMouseInteraction(bool mouseAction)
    {
        //Valida si se hizo click
        if (mouseAction)
        {
            //StopCoroutine(PlantInMousePosition());
            Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(r.origin, r.direction);
            if (hit.collider != null)
            {
                if (hit.collider.CompareTag("Celda"))
                {
                    Transform transform = hit.collider.transform;
                    ValidationsPowerUps(transform);
                }
            }
            isHolding = false;
        }

        
    }

    private void ValidationsPowerUps(Transform celdaTransform)
    {
        gameObject.GetComponent<Image>().color = Color.white;
        Debug.Log("Esto se ejecuta 4");
        if (celdaTransform.childCount != 0)
        {
            return;
        }
        Debug.Log("Esto se ejecuta 3");
        if (!canUsePowerUp)
        {
            return;
        }
        Debug.Log("Esto se ejecuta 2");
        if (isLoading) return;
        Debug.Log("Esto se ejecuta 1");
        

        if(numberOfPowerUp == 1 && GameManager.instance.data.cantityOfPowerUpsThree > 0)
        {
            StartCoroutine(CooldownCounter());
            Vector3 positionToInstantiate = new Vector3(celdaTransform.position.x, 0, 0);
            Instantiate(powerUp, positionToInstantiate, powerUp.transform.rotation);
            canUsePowerUp = false;
            GameManager.instance.data.cantityOfPowerUpsThree--;
            GameManager.instance.data.powerUpsUsed++;
        }
        else if(numberOfPowerUp == 2 && GameManager.instance.data.cantityOfPowerUpsTwo > 0)
        {
            StartCoroutine(CooldownCounter());
            GameObject.Find("Canvas").transform.GetChild(0).gameObject.SetActive(true);
            Instantiate(powerUp, celdaTransform.position, gameObject.transform.rotation);
            canUsePowerUp = false;
            GameManager.instance.data.cantityOfPowerUpsTwo--;
            GameManager.instance.data.powerUpsUsed++;
        }
        else if(numberOfPowerUp == 3 && GameManager.instance.data.cantityOfPowerUpsOne > 0)
        {
            StartCoroutine(CooldownCounter());
            Vector3 newPosition = new Vector3(celdaTransform.position.x, celdaTransform.position.y - 0.5f, celdaTransform.position.z);
            Instantiate(powerUp, newPosition, gameObject.transform.rotation);
            canUsePowerUp = false;
            GameManager.instance.data.cantityOfPowerUpsOne--;
            GameManager.instance.data.powerUpsUsed++;
        }

        GameManager.instance.SaveChanges();
    }

    private void ValidationsPowerUps()
    {

        if (isLoading) return;

        

        if (numberOfPowerUp == 1 && GameManager.instance.data.cantityOfPowerUpsOne > 0)
        {
            StartCoroutine(CooldownCounter());
            Instantiate(powerUp, Vector3.zero, powerUp.transform.rotation);
            canUsePowerUp = false;
            GameManager.instance.data.cantityOfPowerUpsOne--;
            GameManager.instance.data.powerUpsUsed++;
        }
        else if (numberOfPowerUp == 2 && GameManager.instance.data.cantityOfPowerUpsTwo > 0)
        {
            StartCoroutine(CooldownCounter());
            GameObject.Find("Canvas").transform.GetChild(0).gameObject.SetActive(true);
            Instantiate(powerUp, Vector3.zero, gameObject.transform.rotation);
            canUsePowerUp = false;
            GameManager.instance.data.cantityOfPowerUpsTwo--;
            GameManager.instance.data.powerUpsUsed++;
        }
        else if (numberOfPowerUp == 3 && GameManager.instance.data.cantityOfPowerUpsThree > 0)
        {
            StartCoroutine(CooldownCounter());
            Instantiate(powerUp, Vector3.zero, gameObject.transform.rotation);
            canUsePowerUp = false;
            GameManager.instance.data.cantityOfPowerUpsThree--;
            GameManager.instance.data.powerUpsUsed++;
        }

        GameManager.instance.SaveChanges();
    }

    public IEnumerator CooldownCounter() {
        int i = 0;
        isLoading = true;
        
        while (i < cooldown)
        {
            transform.GetChild(0).GetComponent<Text>().text = (cooldown - i).ToString();
            yield return new WaitForSeconds(1);
            i++;
        }
        transform.GetChild(0).GetComponent<Text>().text = "";
        isLoading = false;
    }

}
