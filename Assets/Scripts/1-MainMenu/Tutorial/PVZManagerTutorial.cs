using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PVZManagerTutorial : MonoBehaviour
{
    private bool isHolding;
    private GameObject plantObject;     //La planta que se muestra si se hace un drag
    private bool canUsePlant = false;

    public ZombieTutorial zombie;
    public int suns = 200;
    public int plantToUse = 0;
    public bool cardsIsAsigned;

    private int liderIndex;
    public bool LiderWasPressed;
    private int danielIndex;
    public bool DanielWasPressed;
    public bool ZombieWasKilled;
    //private Plants plantDelay;

    public List<PlantsTutorial> plantsToUse;      //Es una lista que contiene las plantas que se van a usar
    public List<GameObject> cooldownObjects;      //Es una lista que contiene las plantas que se van a usar

    public GameObject deck;        //Lugar donde se ubicaran las cartas
    public GameObject prefabCard;         //Prefab de la carta
    public GameObject characterToUse;
    public GameObject sunsAlert;
    public Text sunsText;
    public Text starsText;
    public Text heartsText;

    public Vector3 zombiesDetectionDirection = Vector3.left;

    public int currentLevel = 0;
    public int currentWorld = 0;

    public int zombiesKilled = 0;
    public int currentTime;
    public int starsObtained = 0;
    public int objectsObtained = 0;
    public int animalsObtained = 0;

    public int maximumPlantsToPlay = 6;
    public int numberOfPlantsSelected = 0;
    public int indexUsed = 0;

    public int starsReward = 0;

    public static PVZManagerTutorial instance;

    public PVZTutorial pvzTutorial;
    public GameObject zombiePrefab;
    public Transform instancePosition;


    private void Awake()
    {
        if (PVZManagerTutorial.instance == null)
        {
            PVZManagerTutorial.instance = this;
        }
        else if (PVZManagerTutorial.instance != null)
        {
            Destroy(gameObject);
        }

        //starsText.text = (GameManager.instance.data.stars).ToString();
        //heartsText.text = (GameManager.instance.data.hearts).ToString();

        plantObject = new GameObject();
        Instantiate(plantObject);
        plantObject.name = "ShowNextPlant";
        plantObject.AddComponent<SpriteRenderer>();
        //GameManager.instance.levelObject = GameObject.Find(GameManager.instance.levelName);
    }

    private void Start()
    {
        AssignCard();
    }

    public void AssignCard()
    {
        UpdateSuns(0);
        //Recorre todos los datos de la lista
        for (int i = 0; i < plantsToUse.Count; i++)
        {

            int j = i;
            GameObject go = Instantiate(prefabCard) as GameObject;       //Crea un objeto instancia de la carta
            //Debug.Log(go.name);
            //cooldownObjects.Add(go);
            go.transform.SetParent(deck.transform);        //Pone el prefab carta como hijo del deck
            go.transform.position = Vector3.zero;       //Pone la posicion de la carta en 0 para evitar errores
            go.transform.localScale = Vector3.one;      //Pone la escala de la carta en 0 para visualizarla correctamente
            go.tag = "Card";
            if (i == 0) pvzTutorial.botonLider = go;
            else if (i == 1) pvzTutorial.botonDaniel = go;
            go.AddComponent<EventTrigger>();
            EventTrigger trigger = go.GetComponent<EventTrigger>();
            EventTrigger.Entry entry = new EventTrigger.Entry();
            entry.eventID = EventTriggerType.PointerDown;
            entry.callback.AddListener((eventData) => { isHolding = true; plantToUse = j; });
            entry.callback.AddListener((eventData) => { go.GetComponent<Image>().color = Color.gray; });
            entry.callback.AddListener((eventData) => { canUsePlant = true; });
            entry.callback.AddListener((eventData) => { ClearButtons(j, deck.transform); });


            entry.callback.AddListener((eventData) => { plantObject.GetComponent<SpriteRenderer>().sprite = plantsToUse[plantToUse].gameObject.GetComponent<PlantsTutorial>().dragSprite; });
            entry.callback.AddListener((eventData) => { plantObject.GetComponent<SpriteRenderer>().sortingOrder = -100; });
            entry.callback.AddListener((eventData) => { plantObject.transform.localScale = new Vector3(.6f, .6f, .6f); });
            //entry.callback.AddListener((eventData) => { plantDelay = plantObject.GetComponent<Plants>(); });
            //entry.callback.AddListener((eventData) => { plantObject.GetComponent<Plants>().cooldownObject = go.transform.GetChild(0).gameObject; });

            //entry.callback.AddListener((eventData) => { plantObject = Instantiate(plantsToUse[plantToUse].gameObject); });
            trigger.triggers.Add(entry);
            //trigger.delegates.Add(entry);
            //go.GetComponent<EventTrigger>().triggers.Add();
            //go.GetComponent<EventTrigger>().OnPointerDown(new PointerEventData(EventSystem.current));

            Image img = go.GetComponent<Image>();       //Crea una imagen que es igual a la imagen de la carta
            img.sprite = plantsToUse[i].asignedCard;        //Cambia el sprite de la carta por la carta asignada al script plantas

            Button boton = go.GetComponent<Button>();
            boton.onClick.RemoveAllListeners();

            boton.onClick.AddListener(() => { plantToUse = j; });
            boton.onClick.AddListener(() => { boton.gameObject.GetComponent<Image>().color = Color.gray; });
            boton.onClick.AddListener(() => { canUsePlant = true; });
            boton.onClick.AddListener(() => { ClearButtons(j, deck.transform); });
        }
        cardsIsAsigned = true;
    }



    public void ClearButtons(int j, Transform deckTransform)
    {
        for (int i = 0; i < deckTransform.childCount; i++)
        {
            if (i != j)
            {
                deckTransform.GetChild(i).gameObject.GetComponent<Image>().color = Color.white;
            }
        }
    }

    public void ClearAllButtons()
    {
        for (int i = 0; i < deck.transform.childCount; i++)
        {
            deck.transform.GetChild(i).gameObject.GetComponent<Image>().color = Color.white;
            // deckTransform.GetChild(i).gameObject.GetComponent<Image>().color = Color.white;
        }
    }


    private void Update()
    {
        /*
        if(plantObject != null)
        {
            plantObject.layer = 2;
            Destroy(plantObject.GetComponent<Plants>());
        }
        */

        if (cardsIsAsigned)
        {
            if (isHolding)
            {

                Vector3 currentScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
                plantObject.transform.position = Camera.main.ScreenToWorldPoint(currentScreenSpace);
                Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(r.origin, r.direction);

                if (hit.collider != null)
                {
                    if (hit.collider.CompareTag("Celda"))
                    {
                        if (hit.collider.transform.childCount == 0)
                        {
                            
                            plantObject.transform.position = new Vector3(hit.collider.transform.position.x,
                            hit.collider.transform.position.y + 1.1f,
                            hit.collider.transform.position.z);
                        }
                    }
                }

                DetectMouseInteraction(Input.GetMouseButtonUp(0));
            }
            else
            {
                //Destroy(plantObject);
                plantObject.GetComponent<SpriteRenderer>().sprite = null;
                DetectMouseInteraction(Input.GetMouseButtonDown(0));
            }
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
                if (hit.collider.CompareTag("Celda"))
                {
                    
                    Transform t = hit.collider.transform;
                    ValidationsPlant(plantToUse, t);
                }
                else if (hit.collider.CompareTag("Sun"))
                {
                    UpdateSuns(25);
                    Destroy(hit.collider.gameObject);
                }
                else if (hit.collider.CompareTag("Star"))
                {
                    //Debug.Log("Estrellas++");
                    GameManager.instance.data.stars++;
                    GameManager.instance.data.starsObtained++;
                    starsObtained++;
                    starsText.text = (GameManager.instance.data.stars).ToString();
                    Destroy(hit.collider.gameObject);
                }
            }

            isHolding = false;
        }
    }

    private void ValidationsPlant(int numero, Transform t)
    {

        if (plantsToUse[numero].sunsPrice > suns)
        {
            
            GameObject go = Instantiate(sunsAlert, Input.mousePosition, Quaternion.identity);

            go.transform.SetParent(GameObject.Find("Canvas").transform);

            //sunsAlert.transform.GetChild(0).transform.position = Input.mousePosition;
            Destroy(go, 1);

            return;
        }
        if (t.childCount != 0)
        {
            return;
        }
        if (!canUsePlant)
        {
            return;
        }

        CreatePlant(numero, t);
    }

    private void CreatePlant(int number, Transform t)
    {
        
        Vector3 positionToInstantiate = new Vector3(t.position.x, t.position.y , t.position.z);
        GameObject plantObject = Instantiate(plantsToUse[plantToUse].gameObject, positionToInstantiate, gameObject.transform.rotation);      //Instancia una planta en el punto donde se hace click
        
        if(plantObject.GetComponent<PlantsTutorial>().cooldownObject != null)
            plantObject.GetComponent<PlantsTutorial>().cooldownObject = cooldownObjects[plantToUse];
        Debug.Log("Bugaso");
        /*if (plantObject.GetComponent<Sunflower>() != null)
        {
            plantObject.transform.localScale = new Vector3(-0.4136269f,
                0.4136269f, 0.4136269f);
        }*/

        plantObject.transform.SetParent(t);
        //plantObject.GetComponent<SpriteRenderer>().sortingLayerName = plantObject.transform.parent.GetComponent<SpriteRenderer>().sortingLayerName;
        Debug.Log("Bugaso");
        if (plantObject.transform.parent.GetComponent<SpriteRenderer>().sortingOrder == 0)
        {
            plantObject.GetComponent<SpriteRenderer>().sortingLayerName = "Linea1";
        }
        else if (plantObject.transform.parent.GetComponent<SpriteRenderer>().sortingOrder == 10)
        {
            plantObject.GetComponent<SpriteRenderer>().sortingLayerName = "Linea2";
        }
        else if (plantObject.transform.parent.GetComponent<SpriteRenderer>().sortingOrder == 20)
        {
            plantObject.GetComponent<SpriteRenderer>().sortingLayerName = "Linea3";
        }
        else if (plantObject.transform.parent.GetComponent<SpriteRenderer>().sortingOrder == 30)
        {
            plantObject.GetComponent<SpriteRenderer>().sortingLayerName = "Linea4";
        }
        else if (plantObject.transform.parent.GetComponent<SpriteRenderer>().sortingOrder == 40)
        {
            plantObject.GetComponent<SpriteRenderer>().sortingLayerName = "Linea5";
        }
        Debug.Log("Bugaso");
        UpdateSuns(-plantsToUse[number].sunsPrice);
        Debug.Log("Bugaso");
        ClearAllButtons();
        canUsePlant = false;
        if (number == 0) LiderWasPressed = true;
        //plantObject.GetComponent<PlantsTutorial>().StartCooldown();
        //PlantCooldown(plantObject.gameObject);
    }

    public void UpdateSuns(int add)
    {
        suns += add;      //Suma soles
        sunsText.text = suns.ToString();     //Actualiza el texto de los soles
    }

    public void SlowZombie(GameObject zombieObject)
    {
        zombieObject.GetComponent<ZombieTutorial>().speedMovement = zombieObject.GetComponent<ZombieTutorial>().speedMovement / 2;
        zombieObject.GetComponent<SpriteRenderer>().color = Color.blue;
    }

    public IEnumerator ZombieOnFire(GameObject zombieObject)
    {
        float fireDuration = 20;
        float auxiliaryFireDuration = 0;
        while (auxiliaryFireDuration < fireDuration)
        {
            zombieObject.GetComponent<ZombieTutorial>().life--;
            auxiliaryFireDuration += 1f;
            zombieObject.GetComponent<SpriteRenderer>().color = Color.red;
            if (zombieObject.GetComponent<ZombieTutorial>().life-- <= 0)
            {
                auxiliaryFireDuration = fireDuration;
                Destroy(zombieObject);
            }
            yield return new WaitForSeconds(1f);
        }
    }

    public IEnumerator StunAllTheZombies()
    {
        GameObject[] go = GameObject.FindGameObjectsWithTag("Zombie");
        //float[] zombiesSpeeds;

        for (int i = 0; i < go.Length; i++)
        {
            //zombiesSpeeds[i] = go[i].GetComponent<Zombie>().speedMovement;
            go[i].GetComponent<ZombieTutorial>().speedMovement = 0;

        }
        //yield return new WaitForSeconds(4);
        yield return null;
    }

    public void InstantiateZombieTutorial() {
        GameObject go = Instantiate(zombiePrefab, instancePosition.position, Quaternion.identity);
        go.GetComponent<ZombieTutorial>().speedMovement = 0;
        zombie = go.GetComponent<ZombieTutorial>();
    }
}
