using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DeletePlant : MonoBehaviour
{
    private bool isHolding;
    //private bool canUsePowerUp = false;
    private GameObject deleteObject;

    public Sprite deleteSprite;

    void Start()
    {
        //nextPowerUp = GameObject.Find("ShowNextPlant");

        deleteObject = new GameObject();
        Instantiate(deleteObject);
        deleteObject.AddComponent<SpriteRenderer>();
        deleteObject.transform.localScale = new Vector3(.5f, .5f, .5f);

        gameObject.AddComponent<EventTrigger>();

        EventTrigger trigger = gameObject.GetComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerDown;

        entry.callback.AddListener((eventData) => { isHolding = true; });
        entry.callback.AddListener((eventData) => { deleteObject.GetComponent<SpriteRenderer>().sprite = deleteSprite; });
        //entry.callback.AddListener((eventData) => { canUsePowerUp = true; });
        trigger.triggers.Add(entry);
    }

    void Update()
    {
        if (isHolding)
        {
            //gameObject.GetComponent<Image>().color = Color.white;
            Vector3 currentScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
            deleteObject.transform.position = Camera.main.ScreenToWorldPoint(currentScreenSpace);
            DetectMouseInteraction(Input.GetMouseButtonUp(0));
        }
        else
        {
            deleteObject.GetComponent<SpriteRenderer>().sprite = null;
            //DetectMouseInteraction(Input.GetMouseButtonDown(0));
        }
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
                if (hit.collider.gameObject.layer == 12)
                {
                    Transform transform = hit.collider.transform;
                    Validations(transform);
                }

                /*if (hit.collider.layer("Celda"))
                {
                    Transform transform = hit.collider.transform;
                    Validations(transform);
                }*/
            }
            isHolding = false;
        }
    }

    private void Validations(Transform celdaTransform)
    {
        gameObject.GetComponent<Image>().color = Color.white;
        if (celdaTransform.childCount != 0)
        {
            Destroy(celdaTransform.gameObject);
            isHolding = false;
        }
    }
}
