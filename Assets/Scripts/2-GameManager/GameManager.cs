using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;
using Assets.SimpleAndroidNotifications;
using System;

[Serializable]
public class Pair
{
    public int first;
    public int second;
}

public class GameManager : MonoBehaviour
{

    private string filePath;        //Directorio donde está el fichero
    private string defaultPath;
    private string jsonString;          //Lugar donde vamos a importar el codigo
    private string secondDefaultPath;

    public Button adsButton;
    public Button[] shareButtons;

    public bool isChargingScene = false;
    public static GameManager instance;
    public Toggle musicToggle;
    public Toggle effectsToggle;

    public string levelName;
    public GameObject levelObject;
    public GameObject resetAllGameCanvas;
    public GameObject tutorialObject;
    public GameObject loadingCanvas;
    public GameObject CanvasMainMenu;
    public GameObject soundObject;
    public Sprite spritePlayerSelected;
    public int playerSelectedIndex = 2;
    public GameObject[] characters;

    [Space(20)]

    public Sprite[] charactersSprites;      //seleccion de personajes
    public bool[] clothesUsed;

    [Space(20)]

    public Sprite lockLevelSprite;
    public Sprite unlockLevelSprite;

    public Text starsText;
    public Text storeStarsText;
    public Text heartsText;

    [Space(30)]
    public Text spinText;
    public Text firstStarsClaimText;
    public Text secondStarsClaimText;
    public Text thirdStarsClaimText;

    public GameData data;

    [Space(50)]
    public GameObject characterStoreButtonsParent;
    public GameObject clothesStoreButtonsParent;
    public Pair GorrosIndex;
    public Pair CollarIndex;
    public Pair GafasIndex;
    public Pair NarizIndex;
    public ActualizeItems storeActualizeItems;
    //public GameObject[] characterStoreButtons;      //Botones de Gorros
    //public GameObject[] characterStoreButtons;      //Botones de Collar
    //public GameObject[] characterStoreButtons;      //Botones de Gafas
    //public GameObject[] characterStoreButtons;      //Botonoes de Nariz

    //Datos de el panel de registro
    [Space(50)]

    public InputField nameText;
    public InputField mailText;

    public GameObject registerButton;

    public GameObject registerPanel;
    public GameObject giftPanel;
    public GameObject errorPanel;

    [Space(20)]
    public GameObject panel1;
    public GameObject panel2;
    public GameObject botonJugar1;
    public GameObject botonJugar2;

    [Space(50)]
    public ClothesSave clothesRestart;

    private void Awake()
    {
        
        StartJsonFiles();

        if (GameManager.instance == null)
        {
            GameManager.instance = this;
        }else if(GameManager.instance != null)
        {
            Destroy(gameObject);
        }


        DontDestroyOnLoad(this.gameObject);
        DontDestroyOnLoad(soundObject);
        DontDestroyOnLoad(tutorialObject);
        DontDestroyOnLoad(GameObject.Find("ControladorTutorial"));
        if(registerPanel != null)
            DontDestroyOnLoad(registerPanel);
        DontDestroyOnLoad(clothesRestart.gameObject);
        

        SaveChanges();
        

        musicToggle.isOn = data.musicIsActive;
        effectsToggle.isOn = data.effectsIsActive;

        
        SaveChanges();

        data.secondYear = DateTime.Now.Year;
        data.secondMonth = DateTime.Now.Month;
        data.secondDay = DateTime.Now.Day;
        data.secondHour = DateTime.Now.Hour;
        data.secondMinute = DateTime.Now.Minute;
        data.secondSecond = DateTime.Now.Second;

        GameObject mainCanvas = spinText.GetComponentInParent<Canvas>().gameObject;
        GameObject spinCanvas = mainCanvas.transform.GetChild(12).gameObject;
        GameObject spinButton = spinCanvas.transform.GetChild(5).gameObject;

        if (data.spinActive) {
            spinButton.GetComponent<Button>().enabled = true;
            spinButton.GetComponentInChildren<Text>().text = "Girar!";
            spinButton.GetComponent<Image>().color = new Color(255, 255, 255, 1f);
        }
        else
        {
            data.spinActive = false;
            Debug.Log(spinButton.name);
            spinButton.GetComponent<Button>().enabled = false;
            spinButton.GetComponentInChildren<Text>().text = data.spinHoursDuration + ":" + data.spinMinutesDuration + ":" + data.spinSecondsDuration;
            spinButton.GetComponent<Image>().color = new Color(255, 255, 255, 0.5f);
            //SpinTimer();
            StartCoroutine(SpinCounter());
        }

        GameObject firstCanvas = firstStarsClaimText.GetComponentInParent<Canvas>().gameObject;
        GameObject starsCanvas = firstCanvas.transform.GetChild(11).gameObject;
        GameObject starsButton = starsCanvas.transform.GetChild(5).GetChild(0).GetChild(0).gameObject;

        if (data.firstStarsActive)
        {
            starsButton.GetComponent<Button>().enabled = true;
            starsButton.GetComponentInChildren<Text>().text = "Reclamar";
            starsButton.GetComponent<Image>().color = new Color(255, 255, 255, 1f);
        }
        else
        {
            data.firstStarsActive = false;
            starsButton.GetComponent<Button>().enabled = false;
            starsButton.GetComponentInChildren<Text>().text = data.firstStarsHoursDuration + ":" + data.firstStarsMinutesDuration + ":" + data.firstStarsSecondsDuration;
            starsButton.GetComponent<Image>().color = new Color(255, 255, 255, 0.5f);
            //SpinTimer();
            StartCoroutine(FirstStarsCounter());
        }

        GameObject secondCanvas = firstStarsClaimText.GetComponentInParent<Canvas>().gameObject;
        GameObject secondStarsCanvas = secondCanvas.transform.GetChild(11).gameObject;
        GameObject secondStarsButton = starsCanvas.transform.GetChild(5).GetChild(0).GetChild(1).gameObject;

        if (data.secondStarsActive)
        {
            secondStarsButton.GetComponent<Button>().enabled = true;
            secondStarsButton.GetComponentInChildren<Text>().text = "Reclamar";
            secondStarsButton.GetComponent<Image>().color = new Color(255, 255, 255, 1f);
        }
        else
        {
            data.secondStarsActive = false;
            secondStarsButton.GetComponent<Button>().enabled = false;
            secondStarsButton.GetComponentInChildren<Text>().text = data.secondStarsHoursDuration + ":" + data.secondStarsMinutesDuration + ":" + data.secondStarsSecondsDuration;
            secondStarsButton.GetComponent<Image>().color = new Color(255, 255, 255, 0.5f);
            //SpinTimer();
            StartCoroutine(SecondStarsCounter());
        }

        SaveChanges();

        if(data.firstYear < data.secondYear || data.firstMonth < data.secondMonth || data.firstDay < data.secondDay || Mathf.Abs(data.firstHour - data.secondHour) >= 8)
        {
            data.spinActive = true;
            spinButton.GetComponent<Button>().enabled = true;
            spinButton.GetComponentInChildren<Text>().text = "Girar!";
            spinButton.GetComponent<Image>().color = new Color(255, 255, 255, 1f);
            data.spinHoursDuration = 2;
            data.spinMinutesDuration = 0;
            data.spinSecondsDuration = 0;

            data.firstStarsActive = true;
            starsButton.GetComponent<Button>().enabled = true;
            starsButton.GetComponentInChildren<Text>().text = "Reclamar";
            starsButton.GetComponent<Image>().color = new Color(255, 255, 255, 1f);
            data.firstStarsHoursDuration = 2;
            data.firstStarsMinutesDuration = 0;
            data.firstStarsSecondsDuration = 0;

            data.secondStarsActive = true;
            starsButton.GetComponent<Button>().enabled = true;
            starsButton.GetComponentInChildren<Text>().text = "Reclamar";
            starsButton.GetComponent<Image>().color = new Color(255, 255, 255, 1f);
            data.secondStarsHoursDuration = 8;
            data.secondStarsMinutesDuration = 0;
            data.secondStarsSecondsDuration = 0;
        }
        else
        {
            if(Mathf.Abs(data.firstHour - data.secondHour) >= 2)
            {
                data.spinActive = true;
                spinButton.GetComponent<Button>().enabled = true;
                spinButton.GetComponentInChildren<Text>().text = "Girar!";
                spinButton.GetComponent<Image>().color = new Color(255, 255, 255, 1f);
                data.spinHoursDuration = 2;
                data.spinMinutesDuration = 0;
                data.spinSecondsDuration = 0;

                data.firstStarsActive = true;
                starsButton.GetComponent<Button>().enabled = true;
                starsButton.GetComponentInChildren<Text>().text = "Reclamar";
                starsButton.GetComponent<Image>().color = new Color(255, 255, 255, 1f);
                data.firstStarsHoursDuration = 2;
                data.firstStarsMinutesDuration = 0;
                data.firstStarsSecondsDuration = 0;

                data.secondStarsHoursDuration -= Mathf.Abs(data.firstHour - data.secondHour);
                data.secondStarsMinutesDuration -= Mathf.Abs(data.firstMinute - data.secondMinute);
                data.secondStarsSecondsDuration -= Mathf.Abs(data.firstSecond - data.secondSecond);
            }
            else
            {
                data.spinHoursDuration -= Mathf.Abs(data.firstHour - data.secondHour);
                data.spinMinutesDuration -= Mathf.Abs(data.firstMinute - data.secondMinute);
                data.spinSecondsDuration -= Mathf.Abs(data.firstSecond - data.secondSecond);

                data.firstStarsHoursDuration -= Mathf.Abs(data.firstHour - data.secondHour);
                data.firstStarsMinutesDuration -= Mathf.Abs(data.firstMinute - data.secondMinute);
                data.firstStarsSecondsDuration -= Mathf.Abs(data.firstSecond - data.secondSecond);

                data.secondStarsHoursDuration -= Mathf.Abs(data.firstHour - data.secondHour);
                data.secondStarsMinutesDuration -= Mathf.Abs(data.firstMinute - data.secondMinute);
                data.secondStarsSecondsDuration -= Mathf.Abs(data.firstSecond - data.secondSecond);
            }

        }

        if (data.spinHoursDuration < 0) data.spinHoursDuration = 0;
        if (data.spinMinutesDuration < 0) data.spinMinutesDuration = 0;
        if (data.spinSecondsDuration < 0) data.spinSecondsDuration = 0;

        if (data.firstStarsHoursDuration < 0) data.firstStarsHoursDuration = 0;
        if (data.firstStarsMinutesDuration < 0) data.firstStarsMinutesDuration = 0;
        if (data.firstStarsSecondsDuration < 0) data.firstStarsSecondsDuration = 0;

        if (data.secondStarsHoursDuration < 0) data.secondStarsHoursDuration = 0;
        if (data.secondStarsMinutesDuration < 0) data.secondStarsMinutesDuration = 0;
        if (data.secondStarsSecondsDuration < 0) data.secondStarsSecondsDuration = 0;

    }

    public void SetSound(bool value) {

        soundObject.SetActive(value);
    }

    private void Start()
    {
        /*if(data.timesEntered != 1)
        {
            tutorialObject.SetActive(false);
            data.timesEntered++;
        }*/
            
            
    }

    private void StartJsonFiles()
    {
        filePath = Application.persistentDataPath + "/GameManagerSave.json";
        defaultPath = Application.dataPath + "/GameManager.json";

        if (File.Exists(filePath))
        {
            jsonString = File.ReadAllText(filePath);
            data = JsonUtility.FromJson<GameData>(jsonString);
        }
        else
        {
            TextAsset file = Resources.Load("GameManager") as TextAsset;
            string content = file.text;
            File.WriteAllText(filePath, content);
            jsonString = File.ReadAllText(filePath);
            data = JsonUtility.FromJson<GameData>(jsonString);
        }
    }

    public void GiveReward() {
        //Le da 1000 estrellas al jugador por publicidad
        GameManager.instance.gameObject.GetComponent<AudioSource>().Play();
        GameManager.instance.data.stars += 1000;
        storeStarsText.text = GameManager.instance.data.stars.ToString();
        ActualizeData();
        //TODO: Mostrar anuncio que gano estrellas
    }

    private void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            data.firstYear = DateTime.Now.Year;
            data.firstMonth = DateTime.Now.Month;
            data.firstDay = DateTime.Now.Day;
            data.firstHour = DateTime.Now.Hour;
            data.firstMinute = DateTime.Now.Minute;
            data.firstSecond = DateTime.Now.Second;
            SaveChanges();
        }
    }

    private void OnApplicationQuit()
    {
        data.firstYear = DateTime.Now.Year;
        data.firstMonth = DateTime.Now.Month;
        data.firstDay = DateTime.Now.Day;
        data.firstHour = DateTime.Now.Hour;
        data.firstMinute = DateTime.Now.Minute;
        data.firstSecond = DateTime.Now.Second;
        SaveChanges();
    }

    //Recibe como parametros la cantidad de niveles a desbloquear y el transform del objeto padre
    public void LockAndUnlock(int levelsToUnlock, Transform parentTransform)
    {
        for (int i = 0; i < parentTransform.childCount; i++)
        {
            if (i <= levelsToUnlock)
            {
                //parentTransform.GetChild(i).gameObject.GetComponent<Button>().enabled = true;
                //if(i != 0) parentTransform.GetChild(i).gameObject.GetComponent<Image>().sprite = unlockLevelSprite;
                parentTransform.GetChild(i).gameObject.GetComponent<Button>().enabled = true;
                parentTransform.GetChild(i).transform.GetChild(0).gameObject.SetActive(true);
                parentTransform.GetChild(i).transform.GetChild(1).gameObject.SetActive(false);
            }
            else
            {
                
                parentTransform.GetChild(i).gameObject.GetComponent<Button>().enabled = false;
                parentTransform.GetChild(i).transform.GetChild(0).gameObject.SetActive(false);
                parentTransform.GetChild(i).transform.GetChild(1).gameObject.SetActive(true);
                ///parentTransform.GetChild(i).gameObject.GetComponent<Image>().sprite = lockLevelSprite;
            }
        }
    }

    public void ActualizeData()
    {
        starsText.text = data.stars.ToString();
        heartsText.text = data.hearts.ToString();
        SaveChanges();
    }

    public void SaveChanges()
    {
        jsonString = JsonUtility.ToJson(data);
        File.WriteAllText(filePath, jsonString);

    }

    public void SoundValueChange()
    {
        if (musicToggle.isOn)
        {
            data.musicIsActive = true;
            SaveChanges();
        }
        else
        {
            data.musicIsActive = false;
            SaveChanges();
        }
        soundObject.SetActive(data.musicIsActive);
    }

    public void EffectsValueChange()
    {
        if (effectsToggle.isOn)
        {
            data.effectsIsActive = true;
            SaveChanges();
        }
        else
        {
            data.effectsIsActive = false;
            SaveChanges();
        }
    }

    //Funciones con el tiempo a esperar para la obtencion de estrellas

    public void SpinTimer()
    {
        GameObject mainCanvas = spinText.GetComponentInParent<Canvas>().gameObject;
        GameObject spinCanvas = mainCanvas.transform.GetChild(12).gameObject;
        GameObject spinButton = spinCanvas.transform.GetChild(5).gameObject;
        data.spinActive = false;
        data.spinHoursDuration = 2;
        data.spinMinutesDuration = 0;
        data.spinSecondsDuration = 0;
        spinButton.GetComponentInChildren<Text>().text = data.spinHoursDuration + ":" + data.spinMinutesDuration + ":" + data.spinSecondsDuration;
        spinButton.GetComponent<Button>().enabled = false;//7200 segundos
        NotificationManager.SendWithAppIcon(TimeSpan.FromSeconds(7200), "Ruleta", "Ya puedes volver a girar la ruleta!", new Color(0, 0.6f, 1), NotificationIcon.Message);
        StartCoroutine(SpinCounter());
    }

    private IEnumerator SpinCounter()
    {
        GameObject mainCanvas = spinText.GetComponentInParent<Canvas>().gameObject;
        GameObject spinCanvas = mainCanvas.transform.GetChild(12).gameObject;
        GameObject spinButton = spinCanvas.transform.GetChild(5).gameObject;

        while (data.spinHoursDuration > 0 || data.spinMinutesDuration > 0 || data.spinSecondsDuration > 0)
        {
            if (data.spinActive) break;

            if (data.spinHoursDuration > 0)
            {
                if (data.spinMinutesDuration < 0) data.spinMinutesDuration = Mathf.Abs(data.spinMinutesDuration);
                if (data.spinSecondsDuration < 0) data.spinSecondsDuration = Mathf.Abs(data.spinSecondsDuration);

                if (data.spinMinutesDuration == 0 && data.spinSecondsDuration == 0)
                {
                    data.spinHoursDuration--;
                    data.spinMinutesDuration = 59;
                    data.spinSecondsDuration = 60;
                }
            }

            if (data.spinMinutesDuration > 0)
            {
                if (data.spinSecondsDuration < 0) data.spinSecondsDuration = Mathf.Abs(data.spinSecondsDuration);

                if (data.spinSecondsDuration == 0)
                {
                    
                    data.spinMinutesDuration--;
                    data.spinSecondsDuration = 60;
                }
            }

            yield return new WaitForSeconds(1);

            data.spinSecondsDuration--;
            spinButton.GetComponentInChildren<Text>().text = data.spinHoursDuration + ":" + data.spinMinutesDuration + ":" + data.spinSecondsDuration;
        }
        data.spinActive = true;
        spinButton.GetComponent<Button>().enabled = true;
        spinButton.GetComponentInChildren<Text>().text = "Girar!";
        spinButton.GetComponent<Image>().color = new Color(255, 255, 255, 1f);
        data.spinHoursDuration = 2;
        data.spinMinutesDuration = 0;
        data.spinSecondsDuration = 0;
    }

    public void FirstStarsTimer()
    {

        InterfaceManagerMenu.instance.nameText.text = "Estrellas x100";
        InterfaceManagerMenu.instance.descriptionText.text = "Puedes reclamar 100 estrellas cada 2 horas, estas sirven para comprar objetos de la tienda";

        storeActualizeItems.ActualizeDatas();
        data.stars += 100;
        data.starsObtained += 100;
        GameManager.instance.gameObject.GetComponent<AudioSource>().Play();
        GameObject mainCanvas = firstStarsClaimText.GetComponentInParent<Canvas>().gameObject;
        GameObject starsCanvas = mainCanvas.transform.GetChild(11).gameObject;
        GameObject starsButton = starsCanvas.transform.GetChild(5).GetChild(0).GetChild(0).gameObject;
        data.firstStarsActive = false;
        data.firstStarsHoursDuration = 2;
        data.firstStarsMinutesDuration = 0;
        data.firstStarsSecondsDuration = 0;
        starsButton.transform.GetChild(0).GetComponent<Text>().text = data.firstStarsHoursDuration + ":" + data.firstStarsMinutesDuration + ":" + data.firstStarsSecondsDuration;
        starsButton.GetComponent<Button>().enabled = false;//7200 segundos
        NotificationManager.SendWithAppIcon(TimeSpan.FromSeconds(7200), "Estrellas", "Ya puedes reclamar 100 estrellas!", new Color(0, 0.6f, 1), NotificationIcon.Message);
        ActualizeData();
        StartCoroutine(FirstStarsCounter());
    }

    private IEnumerator FirstStarsCounter()
    {
        GameObject mainCanvas = firstStarsClaimText.GetComponentInParent<Canvas>().gameObject;
        GameObject starsCanvas = mainCanvas.transform.GetChild(11).gameObject;
        GameObject starsButton = starsCanvas.transform.GetChild(5).GetChild(0).GetChild(0).gameObject;

        while (data.firstStarsHoursDuration > 0 || data.firstStarsMinutesDuration > 0 || data.firstStarsSecondsDuration > 0)
        {
            if (data.firstStarsActive) break;

            if (data.firstStarsHoursDuration > 0)
            {
                if (data.firstStarsMinutesDuration <= 0 && data.firstStarsSecondsDuration <= 0)
                {
                    data.firstStarsHoursDuration--;
                    data.firstStarsMinutesDuration = 59;
                    data.firstStarsSecondsDuration = 60;
                }
            }

            if (data.firstStarsMinutesDuration > 0)
            {
                if (data.firstStarsSecondsDuration <= 0)
                {
                    data.firstStarsMinutesDuration--;
                    data.firstStarsSecondsDuration = 60;
                }
            }

            yield return new WaitForSeconds(1);

            data.firstStarsSecondsDuration--;
            starsButton.GetComponentInChildren<Text>().text = data.firstStarsHoursDuration + ":" + data.firstStarsMinutesDuration + ":" + data.firstStarsSecondsDuration;
        }
        data.firstStarsActive = true;
        starsButton.GetComponent<Button>().enabled = true;
        starsButton.GetComponentInChildren<Text>().text = "Reclamar";
        starsButton.GetComponent<Image>().color = new Color(255, 255, 255, 1f);
        data.firstStarsHoursDuration = 2;
        data.firstStarsMinutesDuration = 0;
        data.firstStarsSecondsDuration = 0;
    }

    public void DarEstrellas(int estrellas)
    {
        data.stars += estrellas;
        data.starsObtained += estrellas;
    }
    public void SecondStarsTimer()
    {
        InterfaceManagerMenu.instance.nameText.text = "Estrellas x500";
        InterfaceManagerMenu.instance.descriptionText.text = "Puedes reclamar 500 estrellas cada 8 horas, estas sirven para comprar objetos de la tienda";

        storeActualizeItems.ActualizeDatas();
        data.stars += 500;
        data.starsObtained += 500;
        GameManager.instance.gameObject.GetComponent<AudioSource>().Play();
        GameObject mainCanvas = secondStarsClaimText.GetComponentInParent<Canvas>().gameObject;
        GameObject starsCanvas = mainCanvas.transform.GetChild(11).gameObject;
        GameObject starsButton = starsCanvas.transform.GetChild(5).GetChild(0).GetChild(1).gameObject;
        data.secondStarsActive = false;
        data.secondStarsHoursDuration = 8;
        data.secondStarsMinutesDuration = 0;
        data.secondStarsSecondsDuration = 0;
        starsButton.GetComponentInChildren<Text>().text = data.secondStarsHoursDuration + ":" + data.secondStarsMinutesDuration + ":" + data.secondStarsSecondsDuration;
        starsButton.GetComponent<Button>().enabled = false;//7200 segundos
        NotificationManager.SendWithAppIcon(TimeSpan.FromSeconds(28800), "Estrellas", "Ya puedes reclamar 500 estrellas!", new Color(0, 0.6f, 1), NotificationIcon.Message);
        ActualizeData();
        StartCoroutine(SecondStarsCounter());
    }

    private IEnumerator SecondStarsCounter()
    {
        GameObject mainCanvas = firstStarsClaimText.GetComponentInParent<Canvas>().gameObject;
        GameObject starsCanvas = mainCanvas.transform.GetChild(11).gameObject;
        GameObject starsButton = starsCanvas.transform.GetChild(5).GetChild(0).GetChild(1).gameObject;

        while (data.secondStarsHoursDuration > 0 || data.secondStarsMinutesDuration > 0 || data.secondStarsSecondsDuration > 0)
        {
            if (data.secondStarsActive) break;

            if (data.secondStarsHoursDuration > 0)
            {
                if (data.secondStarsMinutesDuration <= 0 && data.secondStarsSecondsDuration <= 0)
                {
                    data.secondStarsHoursDuration--;
                    data.secondStarsMinutesDuration = 59;
                    data.secondStarsSecondsDuration = 60;
                }
            }

            if (data.secondStarsMinutesDuration > 0)
            {
                if (data.secondStarsSecondsDuration <= 0)
                {
                    data.secondStarsMinutesDuration--;
                    data.secondStarsSecondsDuration = 60;
                }
            }

            yield return new WaitForSeconds(1);

            data.secondStarsSecondsDuration--;
            starsButton.GetComponentInChildren<Text>().text = data.secondStarsHoursDuration + ":" + data.secondStarsMinutesDuration + ":" + data.secondStarsSecondsDuration;
        }
        data.secondStarsActive = true;
        starsButton.GetComponent<Button>().enabled = true;
        starsButton.GetComponentInChildren<Text>().text = "Reclamar";
        starsButton.GetComponent<Image>().color = new Color(255, 255, 255, 1f);
        data.secondStarsHoursDuration = 8;
        data.secondStarsMinutesDuration = 0;
        data.secondStarsSecondsDuration = 0;
    }

    public void ThirdStarsTimer()
    {


        data.stars += 1000;
        data.starsObtained += 1000;
        GameObject mainCanvas = secondStarsClaimText.GetComponentInParent<Canvas>().gameObject;
        GameObject starsCanvas = mainCanvas.transform.GetChild(11).gameObject;
        GameObject starsButton = starsCanvas.transform.GetChild(5).GetChild(0).GetChild(2).gameObject;
        data.thirdStarsActive = false;
        starsButton.GetComponentInChildren<Text>().text = data.thirdStarsHoursDuration + ":" + data.thirdStarsMinutesDuration + ":" + data.thirdStarsSecondsDuration;
        starsButton.GetComponent<Button>().enabled = false;//7200 segundos
        NotificationManager.SendWithAppIcon(TimeSpan.FromSeconds(86400), "Estrellas", "Ya puedes reclamar 500 estrellas!", new Color(0, 0.6f, 1), NotificationIcon.Message);
        ActualizeData();
        StartCoroutine(ThirdStarsCounter());
    }

    private IEnumerator ThirdStarsCounter()
    {
        GameObject mainCanvas = firstStarsClaimText.GetComponentInParent<Canvas>().gameObject;
        GameObject starsCanvas = mainCanvas.transform.GetChild(11).gameObject;
        GameObject starsButton = starsCanvas.transform.GetChild(5).GetChild(0).GetChild(2).gameObject;

        while (data.thirdStarsHoursDuration > 0 || data.thirdStarsMinutesDuration > 0 || data.thirdStarsSecondsDuration > 0)
        {
            if (data.thirdStarsActive) break;

            if (data.thirdStarsHoursDuration > 0)
            {
                if (data.thirdStarsMinutesDuration <= 0 && data.thirdStarsSecondsDuration <= 0)
                {
                    data.thirdStarsHoursDuration--;
                    data.thirdStarsMinutesDuration = 59;
                    data.thirdStarsSecondsDuration = 60;
                }
            }

            if (data.thirdStarsMinutesDuration > 0)
            {
                if (data.thirdStarsSecondsDuration <= 0)
                {
                    data.thirdStarsMinutesDuration--;
                    data.thirdStarsSecondsDuration = 60;
                }
            }

            yield return new WaitForSeconds(1);

            data.thirdStarsSecondsDuration--;
            starsButton.GetComponentInChildren<Text>().text = data.thirdStarsHoursDuration + ":" + data.thirdStarsMinutesDuration + ":" + data.thirdStarsSecondsDuration;
        }
        data.thirdStarsActive = true;
        starsButton.GetComponent<Button>().enabled = true;
        starsButton.GetComponentInChildren<Text>().text = "";
        starsButton.GetComponent<Image>().color = new Color(255, 255, 255, 1f);
        data.thirdStarsHoursDuration = 24;
        data.thirdStarsMinutesDuration = 0;
        data.thirdStarsSecondsDuration = 0;
    }


    public void RestartAllGame()
    {

        
        PlayerPrefs.DeleteAll();

        

        resetAllGameCanvas.SetActive(true);
        tutorialObject.GetComponent<DontDestroyTutorial>().timesActivated = 0;
        //Boton para reiniciar
        playerSelectedIndex = 0;
        Button resetGameButton = GameObject.Find("ResetGameButton").GetComponent<Button>();
        resetGameButton.onClick.RemoveAllListeners();
        resetGameButton.onClick.AddListener(() => { StartCoroutine(ResetAllCanvas()); });

        //foreach (Button shareButton in shareButtons)
        //    shareButton.gameObject.GetComponent<Button>().interactable = true;

        //Boton para no reiniciar
        Button noResetGameButton = GameObject.Find("NoResetGameButton").GetComponent<Button>();
        noResetGameButton.onClick.RemoveAllListeners();
        noResetGameButton.onClick.AddListener(() => { resetAllGameCanvas.SetActive(false); });
    }

    public IEnumerator ResetAllCanvas()
    {
        yield return new WaitForSeconds(5);

        File.Delete(filePath);
        StartJsonFiles();
        ActualizeData();
        //data.timesEntered++;
        musicToggle.isOn = true;
        effectsToggle.isOn = true;
        soundObject.SetActive(true);
        tutorialObject.SetActive(true);
        
        //scrollJuego1.PreviousScreen(true);
        //scrollJuego2.PreviousScreen(true);
        InterfaceManagerMenu.instance.CloseAll();
        resetAllGameCanvas.SetActive(false);
        GameObject.Find("ControladorTutorial").GetComponent<ControladorTutorial>().ResetTutorial();
        clothesRestart.RestartClothes();
        panel1.SetActive(true);
        panel2.SetActive(true);
        botonJugar1.SetActive(true);
        botonJugar2.SetActive(true);
    }

    //OPERACIONES ENTRE FECHAS
    private int OperationBetweenYears()
    {
        int diference = data.secondYear - data.firstYear;
        if (diference > 0) return diference;
        else return 0;
    }

    private int OperationBetweenMonths()
    {
        int diference = data.secondMonth - data.firstMonth;
        if (diference > 0) return diference;
        else return 0;
    }

    private int OperationBetweenDays()
    {
        int diference = data.secondDay - data.firstDay;
        if (diference > 0) return diference;
        else return 0;
    }

    private int OperationBetweenHours()
    {
        int diference = Mathf.Abs(data.secondHour - data.firstHour);
        return diference;
    }

    private int OperationBetweenMinutes()
    {
        int diference = Mathf.Abs(data.secondMinute - data.firstMinute);
        return diference;
    }

    private int OperationBetweenSeconds()
    {
        int diference = Mathf.Abs(data.secondSecond - data.firstSecond);
        return diference;
    }

    private void Update()
    {
        if (data.stars < 0) {
            data.stars = 0;
            ActualizeData();
        }
        
        if (SceneManager.GetActiveScene().name == "1-MainMenu" && data.musicIsActive && !loadingCanvas.activeInHierarchy)
             SetSound(true);
        else SetSound(false);
    }

    public IEnumerator ChargeMainScene()
    {
        AsyncOperation scene = SceneManager.LoadSceneAsync("1-MainMenu");
        loadingCanvas.SetActive(true);

        while (!scene.isDone)
            yield return null;

        loadingCanvas.SetActive(false);
    }
}

[System.Serializable]
public class GameData
{
    public bool wasRegistered;

    public int hearts;
    public int stars;
    public bool musicIsActive;
    public bool effectsIsActive;

    public int timesEntered;

    //Seccion para el perfil

    public int starsObtained;
    public int heartsUsed;
    public int powerUpsUsed;
    public int animalsCaptured;
    public int firstGameScore;
    public int secondGameScore;

    //Seccion para la ropa usada
    public bool useClothOne;
    public bool useClothTwo;
    public bool useClothThree;
    public bool useClothFour;
    public bool useClothFive;
    public bool useClothSix;

    //Seccion para los animales capturados

    public int elephantsCaptured;
    public int lizardsCaptured;
    public int monkeysCaptured;
    public int presidentsCaptured;
    public int ratsCaptured;
    public int serafinsCaptured;

    //End perfil

    public int spinHoursDuration;
    public int spinMinutesDuration;
    public int spinSecondsDuration;
    public bool spinActive;

    public int firstStarsHoursDuration;
    public int firstStarsMinutesDuration;
    public int firstStarsSecondsDuration;
    public bool firstStarsActive;

    public int secondStarsHoursDuration;
    public int secondStarsMinutesDuration;
    public int secondStarsSecondsDuration;
    public bool secondStarsActive;

    public int thirdStarsHoursDuration;
    public int thirdStarsMinutesDuration;
    public int thirdStarsSecondsDuration;
    public bool thirdStarsActive;

    public int levelsUnlockedWorldOneGameOne;
    public int levelsUnlockedWorldTwoGameOne;
    public int levelsUnlockedWorldThreeGameOne;
    public int levelsUnlockedWorldFourGameOne;

    public int levelsUnlockedWorldOneGameTwo;
    public int levelsUnlockedWorldTwoGameTwo;
    public int levelsUnlockedWorldThreeGameTwo;
    public int levelsUnlockedWorldFourGameTwo;

    public int levelsUnlockedWorldOneGameThree;
    public int levelsUnlockedWorldTwoGameThree;
    public int levelsUnlockedWorldThreeGameThree;
    public int levelsUnlockedWorldFourGameThree;

    public int levelsUnlockedWorldOneGameFour;
    public int levelsUnlockedWorldTwoGameFour;
    public int levelsUnlockedWorldThreeGameFour;
    public int levelsUnlockedWorldFourGameFour;

    public int cantityOfPowerUpsOne;
    public int cantityOfPowerUpsTwo;
    public int cantityOfPowerUpsThree;

    public bool haveCardThree;
    public bool haveCardFour;
    public bool haveCardFive;
    public bool haveCardSix;
    public bool haveCardSeven;
    public bool haveCardEight;
    public bool haveCardNine;
    public bool haveCardTen;


    public bool haveCharacterOne;
    public bool haveCharacterTwo;
    public bool haveCharacterThree;
    public bool haveCharacterFour;
    public bool haveCharacterFive;
    public bool haveCharacterSix;
    public bool haveCharacterSeven;
    public bool haveCharacterEight;
    public bool haveCharacterNine;
    public bool haveCharacterTen;
    public bool haveCharacterEleven;
    public bool haveCharacterTwelve;
    public bool haveCharacterThirteen;
    public bool haveCharacterFourteen;
    public bool haveCharacterFifteen;
    public bool haveCharacterSixteen;

    public int firstDay;
    public int firstMonth;
    public int firstYear;
    public int secondDay;
    public int secondMonth;
    public int secondYear;

    public int firstHour;
    public int firstMinute;
    public int firstSecond;
    public int secondHour;
    public int secondMinute;
    public int secondSecond;

    public bool haveClothOne;
    public bool haveClothTwo;
    public bool haveClothThree;
    public bool haveClothFour;
    public bool haveClothFive;
    public bool haveClothSix;

    public bool haveWorldTwoGameOne;
    public bool haveWorldThreeGameOne;
    public bool haveWorldTwoGameTwo;
    public bool haveWorldThreeGameTwo;

    public bool haveStampOne;
    public bool haveStampTwo;
    public bool haveStampThree;
    public bool haveStampFour;
    public bool haveStampFive;
    public bool haveStampSix;
    public bool haveStampSeven;
    public bool haveStampEight;

    public int timesShared;

    public override string ToString()
    {
        return string.Format("{0}: {1}: {2}", hearts, stars, timesEntered);
    }
}
