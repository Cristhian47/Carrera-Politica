using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlantsVsZombiesManager : MonoBehaviour
{
    private bool isHolding;
    private GameObject plantObject;     //La planta que se muestra si se hace un drag
    private bool canUsePlant = false;

    public int suns = 200;
    private int plantToUse = 0;
    public bool cardsIsAsigned;
    //private Plants plantDelay;

    public List<Plants> plantsToUse;      //Es una lista que contiene las plantas que se van a usar
    public List<GameObject> cooldownObjects;      //Es una lista que contiene las plantas que se van a usar

    public GameObject deck;        //Lugar donde se ubicaran las cartas
    public GameObject prefabCard;         //Prefab de la carta
    public GameObject characterToUse;
    public GameObject sunsAlert;
    public GameObject soundManager;
    public GameObject pausePanel;
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

    public int maximumPlantsToPlay = 5;
    public int numberOfPlantsSelected = 0;
    public int indexUsed = 0;

    public int starsReward = 0;

    public GameObject unlockedCardPanel;

    public static PlantsVsZombiesManager instance;
    

    private void Awake()
    {
        if (PlantsVsZombiesManager.instance == null)
        {
            PlantsVsZombiesManager.instance = this;
        }else if(PlantsVsZombiesManager.instance != null)
        {
            Destroy(gameObject);
        }

        starsText.text = (GameManager.instance.data.stars).ToString();
        heartsText.text = (GameManager.instance.data.hearts).ToString();

        plantObject = new GameObject();
        Instantiate(plantObject);
        plantObject.name = "ShowNextPlant";
        plantObject.AddComponent<SpriteRenderer>();
        //GameManager.instance.levelObject = GameObject.Find(GameManager.instance.levelName);
    }

    private void Start()
    {
        //AssignCard();
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
            go.transform.localScale = new Vector3(0.73f,0.73f,0.73f);      //Pone la escala de la carta en 0 para visualizarla correctamente
            go.tag = "Card";
            go.transform.GetChild(0).GetChild(1).gameObject.GetComponent<Text>().text = plantsToUse[i].GetComponent<Plants>().sunsPrice.ToString() + " soles";
            go.AddComponent<EventTrigger>();
            EventTrigger trigger = go.GetComponent<EventTrigger>();
            EventTrigger.Entry entry = new EventTrigger.Entry();
            entry.eventID = EventTriggerType.PointerDown;
            entry.callback.AddListener((eventData) => { isHolding = true; plantToUse = j; });
            entry.callback.AddListener((eventData) => { go.transform.GetChild(0).GetComponent<Image>().color = Color.gray; });
            entry.callback.AddListener((eventData) => { canUsePlant = true; });
            entry.callback.AddListener((eventData) => { ClearButtons(j, deck.transform); });
            

            entry.callback.AddListener((eventData) => { plantObject.GetComponent<SpriteRenderer>().sprite = plantsToUse[plantToUse].gameObject.GetComponent<Plants>().dragSprite; });
            entry.callback.AddListener((eventData) => { plantObject.GetComponent<SpriteRenderer>().sortingOrder = -100; });
            entry.callback.AddListener((eventData) => { plantObject.transform.localScale = new Vector3(.6f, .6f, .6f); });
            //entry.callback.AddListener((eventData) => { plantDelay = plantObject.GetComponent<Plants>(); });
            //entry.callback.AddListener((eventData) => { plantObject.GetComponent<Plants>().cooldownObject = go.transform.GetChild(0).gameObject; });
            
            //entry.callback.AddListener((eventData) => { plantObject = Instantiate(plantsToUse[plantToUse].gameObject); });
            trigger.triggers.Add(entry);
            //trigger.delegates.Add(entry);
            //go.GetComponent<EventTrigger>().triggers.Add();
            //go.GetComponent<EventTrigger>().OnPointerDown(new PointerEventData(EventSystem.current));

            Image img = go.transform.GetChild(0).GetComponent<Image>();       //Crea una imagen que es igual a la imagen de la carta
            img.sprite = plantsToUse[i].asignedCard;        //Cambia el sprite de la carta por la carta asignada al script plantas

            //Button boton = go.transform.GetChild(0).gameObject.GetComponent<Button>();
            Button boton = go.GetComponent<Button>();
            boton.onClick.RemoveAllListeners();
            
            boton.onClick.AddListener(() => { plantToUse = j; });
            boton.onClick.AddListener(() => { 
                if(boton != null && boton.gameObject.GetComponent<Image>() != null) boton.gameObject.GetComponent<Image>().color = Color.gray; });
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
                deckTransform.GetChild(i).GetChild(0).GetComponent<Image>().color = Color.white;
            }
        }
    }

    public void ClearAllButtons()
    {
        for (int i = 0; i < deck.transform.childCount; i++)
        {
            deck.transform.GetChild(i).GetChild(0).gameObject.GetComponent<Image>().color = Color.white;
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

                if(hit.collider != null)
                {
                    if (hit.collider.CompareTag("Celda"))
                    {
                        if(hit.collider.transform.childCount == 0)
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
            if (canUsePlant)
            {
                GameObject go = Instantiate(sunsAlert, Input.mousePosition, Quaternion.identity);

                go.transform.SetParent(GameObject.Find("Canvas").transform);

                //sunsAlert.transform.GetChild(0).transform.position = Input.mousePosition;
                Destroy(go, 1.4f);
                isHolding = false;
            }
            
            
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
        Vector3 positionToInstantiate = new Vector3(t.position.x, t.position.y + 0.7f, t.position.z);
        GameObject plantObject = Instantiate(plantsToUse[plantToUse].gameObject, positionToInstantiate, gameObject.transform.rotation);      //Instancia una planta en el punto donde se hace click

        plantObject.GetComponent<Plants>().cooldownObject = cooldownObjects[plantToUse];

        

        plantObject.transform.SetParent(t);
        //plantObject.GetComponent<SpriteRenderer>().sortingLayerName = plantObject.transform.parent.GetComponent<SpriteRenderer>().sortingLayerName;

        if(plantObject.transform.parent.GetComponent<SpriteRenderer>().sortingOrder == 0)
        {
            SpriteRenderer[] sprites = plantObject.GetComponentsInChildren<SpriteRenderer>();
            for(int i = 0; i < sprites.Length; i++)
            {
                sprites[i].sortingLayerName = "Linea1";
            }
            plantObject.GetComponent<SpriteRenderer>().sortingLayerName = "Linea1";
        }
        else if(plantObject.transform.parent.GetComponent<SpriteRenderer>().sortingOrder == 10)
        {
            SpriteRenderer[] sprites = plantObject.GetComponentsInChildren<SpriteRenderer>();
            for (int i = 0; i < sprites.Length; i++)
            {
                sprites[i].sortingLayerName = "Linea2";
            }
            plantObject.GetComponent<SpriteRenderer>().sortingLayerName = "Linea2";
        }
        else if (plantObject.transform.parent.GetComponent<SpriteRenderer>().sortingOrder == 20)
        {
            SpriteRenderer[] sprites = plantObject.GetComponentsInChildren<SpriteRenderer>();
            for (int i = 0; i < sprites.Length; i++)
            {
                sprites[i].sortingLayerName = "Linea3";
            }
            plantObject.GetComponent<SpriteRenderer>().sortingLayerName = "Linea3";
        }
        else if (plantObject.transform.parent.GetComponent<SpriteRenderer>().sortingOrder == 30)
        {
            SpriteRenderer[] sprites = plantObject.GetComponentsInChildren<SpriteRenderer>();
            for (int i = 0; i < sprites.Length; i++)
            {
                sprites[i].sortingLayerName = "Linea4";
            }
            plantObject.GetComponent<SpriteRenderer>().sortingLayerName = "Linea4";
        }
        else if (plantObject.transform.parent.GetComponent<SpriteRenderer>().sortingOrder == 40)
        {
            SpriteRenderer[] sprites = plantObject.GetComponentsInChildren<SpriteRenderer>();
            for (int i = 0; i < sprites.Length; i++)
            {
                sprites[i].sortingLayerName = "Linea5";
            }
            plantObject.GetComponent<SpriteRenderer>().sortingLayerName = "Linea5";
        }

        if (plantObject.GetComponent<Sunflower>() != null)
        {
            plantObject.transform.position = new Vector3(plantObject.transform.position.x,
                plantObject.transform.position.y, plantObject.transform.position.z);
        }

        UpdateSuns(-plantsToUse[number].sunsPrice);
        ClearAllButtons();
        canUsePlant = false;
        plantObject.GetComponent<Plants>().StartCooldown();
        //PlantCooldown(plantObject.gameObject);
    }

    public void StartCooldown(GameObject cooldownObject, float cooldownTime)
    {
        float timeLapse = 0;
        StartCoroutine(StartCooldown(timeLapse, cooldownObject, cooldownTime));
    }

    private IEnumerator StartCooldown(float currentTime, GameObject cooldownObject, float cooldownTime)
    {
        cooldownObject.GetComponent<EventTrigger>().enabled = false;
        cooldownObject.GetComponent<Button>().enabled = false;
        
        cooldownObject.transform.GetChild(0).GetChild(0).position = cooldownObject.transform.GetChild(0).position;
        while (currentTime <= cooldownTime)
        {
            cooldownObject.transform.GetChild(0).GetChild(0).GetComponent<Image>().fillAmount = (1 / cooldownTime) * currentTime;
            currentTime += Time.deltaTime;
            yield return null;
        }

        cooldownObject.transform.GetChild(0).GetChild(0).GetComponent<Image>().fillAmount = 0;
        cooldownObject.GetComponent<EventTrigger>().enabled = true;
        cooldownObject.GetComponent<Button>().enabled = true;
        yield return null;
    }

    public void PlantCooldown(GameObject plant)
    {
        StartCoroutine(StartCooldown(plant));
    }

    private IEnumerator StartCooldown(GameObject plant)
    {
        float time = plant.GetComponent<Plants>().cooldownTime;

        

        yield return null;
    }

    public void UpdateSuns(int add)
    {
        suns += add;      //Suma soles
        sunsText.text = suns.ToString();     //Actualiza el texto de los soles
    }

    public void SlowZombie(GameObject zombieObject)
    {
        zombieObject.GetComponent<Zombie>().auxiliaryVelocity = zombieObject.GetComponent<Zombie>().auxiliaryVelocity / 2;
        zombieObject.GetComponent<SpriteRenderer>().color = Color.blue;
    }
    
    public IEnumerator ZombieOnFire(GameObject zombieObject)
    {
        zombieObject.transform.GetChild(0).GetChild(1).gameObject.SetActive(true);
        float fireDuration = 20;
        float auxiliaryFireDuration = 0;
        while (auxiliaryFireDuration < fireDuration)
        {
            zombieObject.GetComponent<Zombie>().life--;
            auxiliaryFireDuration += 1f;
            zombieObject.GetComponent<SpriteRenderer>().color = Color.red;
            if (zombieObject.GetComponent<Zombie>().life-- <= 0)
            {
                auxiliaryFireDuration = fireDuration;
                Destroy(zombieObject);
            }
            yield return new WaitForSeconds(1f);
        }
        zombieObject.transform.GetChild(0).GetChild(1).gameObject.SetActive(false);
    }

    public IEnumerator StunAllTheZombies(GameObject powerUp)
    {
        GameObject[] go = GameObject.FindGameObjectsWithTag("Zombie");
        //float[] zombiesSpeeds;

        for (int i = 0; i < go.Length; i++)
        { 
            go[i].GetComponent<Zombie>().isStuned = true;
            go[i].transform.GetChild(5).gameObject.SetActive(true);
            
        }
        
        yield return new WaitForSeconds(4);

        for (int i = 0; i < go.Length; i++)
        {
            go[i].GetComponent<Zombie>().isStuned = false;
            go[i].transform.GetChild(5).gameObject.SetActive(false);
        }

        GameObject.Find("Canvas").transform.GetChild(0).gameObject.SetActive(false);
        //yield return null;
        Destroy(powerUp);
    }
}
