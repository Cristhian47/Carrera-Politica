using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorTutorial : MonoBehaviour
{
    public GameObject tutorialPanel;

    public GameObject ImgGlobo1;
    public GameObject ImgGlobo2;
    public GameObject ImgGlobo3;
    public GameObject ImgGlobo4;
    public GameObject ImgGlobo5;
    public GameObject ImgGloboPresidente3;

    public GameObject ImgDaniel1;
    public GameObject ImgDaniel2;
    public GameObject ImgDaniel3;
    public GameObject ImgDaniel4;
    public GameObject ImgDaniel5;

    public GameObject Flecha2;
    public GameObject Flecha3;
    public GameObject Flecha4;
    public GameObject Flecha5;

    public GameObject BotonTienda2;

    //public GameObject ImgElementos3;

    public GameObject BotonPersonajes3;

    public GameObject BotonPvZ4;
    public GameObject BotonJumper4;
    public GameObject BotonPvZ5;
    public GameObject BotonJumper5;

    public GameObject Panel3;
    public GameObject PanelTienda3;
    public GameObject PanelTiendaPersonajes3;

    public GameObject Txt1Globo1;
    public GameObject Txt2Globo1;
    public GameObject Txt3Globo1;

    public GameObject Txt1Globo2;
    public GameObject Txt2Globo2;
    public GameObject Txt3Globo2;

    public GameObject Txt1Globo3;
    public GameObject Txt2Globo3;
    public GameObject Txt3Globo3;
    public GameObject Txt4Globo3;
    public GameObject Txt5Globo3;
    public GameObject Txt6Globo3;
    public GameObject Txt1GloboPresidente3;

    public GameObject Txt1Globo4;
    public GameObject Txt2Globo4;
    public GameObject Txt3Globo4;

    public GameObject Txt1Globo5;


    public static ControladorTutorial instance;

    // Start is called before the first frame update
    private void Awake()
    {
        if (ControladorTutorial.instance == null)
        {
            ControladorTutorial.instance = this;
        }
        else if (ControladorTutorial.instance != null)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        StartCoroutine(Tutorial());
    }

    private void OnEnable()
    {
        StopAllCoroutines();
        StartCoroutine(Tutorial());
    }

    IEnumerator Tutorial()
    {
        ImgGlobo1.SetActive(true);
        ImgDaniel1.SetActive(true);
        yield return new WaitForSeconds(1);
        Txt1Globo1.SetActive(true);
        yield return new WaitForSeconds(2);
        Txt1Globo1.SetActive(false);
        Txt2Globo1.SetActive(true);
        yield return new WaitForSeconds(2);
        Txt2Globo1.SetActive(false);
        Txt3Globo1.SetActive(true);
        yield return new WaitForSeconds(2);
        Txt1Globo1.SetActive(false);
        Txt2Globo1.SetActive(false);
        Txt3Globo1.SetActive(false);
        ImgGlobo1.SetActive(false);
        ImgDaniel1.SetActive(false);
        //yield return new WaitForSeconds(1);

        ImgGlobo2.SetActive(true);
        ImgDaniel2.SetActive(true);
        Flecha2.SetActive(true);
        BotonTienda2.SetActive(true);
        yield return new WaitForSeconds(1);
        Txt1Globo2.SetActive(true);
        yield return new WaitForSeconds(2);
        Txt1Globo2.SetActive(false);
        Txt2Globo2.SetActive(true);
        yield return new WaitForSeconds(2);
        Txt2Globo2.SetActive(false);
        Txt3Globo2.SetActive(true);
        yield return new WaitForSeconds(2);
        ImgGlobo2.SetActive(false);
        ImgDaniel2.SetActive(false);
        Flecha2.SetActive(false);
        BotonTienda2.SetActive(false);
        //yield return new WaitForSeconds(1);

        ImgGlobo3.SetActive(true);
        ImgDaniel3.SetActive(true);
        Panel3.SetActive(true);
        PanelTienda3.SetActive(true);
        yield return new WaitForSeconds(1);
        Flecha3.SetActive(true);
        Txt1Globo3.SetActive(true);
        BotonPersonajes3.SetActive(true);
        yield return new WaitForSeconds(2);
        Txt1Globo3.SetActive(false);
        Txt2Globo3.SetActive(true);
        yield return new WaitForSeconds(2);
        Txt1Globo3.SetActive(false);
        Txt2Globo3.SetActive(false);
        ImgGlobo3.SetActive(false);
        ImgGloboPresidente3.SetActive(true);
        yield return new WaitForSeconds(1);
        Txt1GloboPresidente3.SetActive(true);
        yield return new WaitForSeconds(1);
        ImgGloboPresidente3.SetActive(false);
        ImgGlobo3.SetActive(true);
        Txt3Globo3.SetActive(true);
        yield return new WaitForSeconds(2);
        BotonPersonajes3.SetActive(false);
        Txt3Globo3.SetActive(false);
        //ImgElementos3.SetActive(false);
        Flecha3.SetActive(false);
        Txt4Globo3.SetActive(true);
        PanelTiendaPersonajes3.SetActive(true);
        yield return new WaitForSeconds(2);
        Txt4Globo3.SetActive(false);
        Txt5Globo3.SetActive(true);
        yield return new WaitForSeconds(3);
        Txt5Globo3.SetActive(false);
        Txt6Globo3.SetActive(true);
        yield return new WaitForSeconds(2);

        PanelTiendaPersonajes3.SetActive(false);
        ImgGlobo3.SetActive(false);
        ImgDaniel3.SetActive(false);
        Panel3.SetActive(false);
        PanelTienda3.SetActive(false);
        //yield return new WaitForSeconds(1);
        ImgGlobo4.SetActive(true);
        ImgDaniel4.SetActive(true);
        yield return new WaitForSeconds(1);
        Txt1Globo4.SetActive(true);
        Flecha4.SetActive(true);
        BotonPvZ4.SetActive(true);
        BotonJumper4.SetActive(true);
        yield return new WaitForSeconds(2);
        Txt1Globo4.SetActive(false);
        Txt2Globo4.SetActive(true);
        yield return new WaitForSeconds(3);
        Txt2Globo4.SetActive(false);
        Txt3Globo4.SetActive(true);
        yield return new WaitForSeconds(2);

        ImgGlobo4.SetActive(false);
        ImgDaniel4.SetActive(false);
        Flecha4.SetActive(false);
        BotonPvZ4.SetActive(false);
        BotonJumper4.SetActive(false);
        ImgGlobo5.SetActive(true);
        ImgDaniel5.SetActive(true);
        Flecha5.SetActive(true);
        BotonPvZ5.SetActive(true);
        BotonJumper5.SetActive(true);
        GameManager.instance.data.timesEntered++;
        yield return new WaitForSeconds(1);
        Txt1Globo5.SetActive(true);
    }

    public void SkipTutorial()
    {
        StopAllCoroutines();
        ImgGlobo1.SetActive(false);
        ImgDaniel1.SetActive(false);
        Txt1Globo1.SetActive(false);
        Txt1Globo1.SetActive(false);
        Txt2Globo1.SetActive(false);
        Txt2Globo1.SetActive(false);
        Txt3Globo1.SetActive(false);
        Txt1Globo1.SetActive(false);
        Txt2Globo1.SetActive(false);
        Txt3Globo1.SetActive(false);
        ImgGlobo1.SetActive(false);
        ImgDaniel1.SetActive(false);
        ImgGlobo2.SetActive(false);
        ImgDaniel2.SetActive(false);
        Flecha2.SetActive(false);
        BotonTienda2.SetActive(false);
        Txt1Globo2.SetActive(false);
        Txt1Globo2.SetActive(false);
        Txt2Globo2.SetActive(false);
        Txt2Globo2.SetActive(false);
        Txt3Globo2.SetActive(false);
        ImgGlobo2.SetActive(false);
        ImgDaniel2.SetActive(false);
        Flecha2.SetActive(false);
        BotonTienda2.SetActive(false);
        ImgGlobo3.SetActive(false);
        ImgDaniel3.SetActive(false);
        Panel3.SetActive(false);
        PanelTienda3.SetActive(false);
        Flecha3.SetActive(false);
        Txt1Globo3.SetActive(false);
        BotonPersonajes3.SetActive(false);
        Txt1Globo3.SetActive(false);
        Txt2Globo3.SetActive(false);
        Txt1Globo3.SetActive(false);
        Txt2Globo3.SetActive(false);
        ImgGlobo3.SetActive(false);
        ImgGloboPresidente3.SetActive(false);
        Txt1GloboPresidente3.SetActive(false);
        ImgGloboPresidente3.SetActive(false);
        ImgGlobo3.SetActive(false);
        Txt3Globo3.SetActive(false);
        BotonPersonajes3.SetActive(false);
        Txt3Globo3.SetActive(false);
        //ImgElementos3.SetActive(false);
        Flecha3.SetActive(false);
        Txt4Globo3.SetActive(false);
        PanelTiendaPersonajes3.SetActive(false);
        Txt4Globo3.SetActive(false);
        Txt5Globo3.SetActive(false);
        Txt5Globo3.SetActive(false);
        Txt6Globo3.SetActive(false);
        PanelTiendaPersonajes3.SetActive(false);
        ImgGlobo3.SetActive(false);
        ImgDaniel3.SetActive(false);
        Panel3.SetActive(false);
        PanelTienda3.SetActive(false);
        ImgGlobo4.SetActive(false);
        ImgDaniel4.SetActive(false);
        Txt1Globo4.SetActive(false);
        Flecha4.SetActive(false);
        BotonPvZ4.SetActive(false);
        BotonJumper4.SetActive(false);
        Txt1Globo4.SetActive(false);
        Txt2Globo4.SetActive(false);
        Txt2Globo4.SetActive(false);
        Txt3Globo4.SetActive(false);
        ImgGlobo4.SetActive(false);
        ImgDaniel4.SetActive(false);
        Flecha4.SetActive(false);
        BotonPvZ4.SetActive(false);
        BotonJumper4.SetActive(false);
        ImgGlobo5.SetActive(false);
        ImgDaniel5.SetActive(false);
        Flecha5.SetActive(false);
        BotonPvZ5.SetActive(false);
        BotonJumper5.SetActive(false);
        Txt1Globo5.SetActive(false);
        StartCoroutine(Tutorial());
        GameManager.instance.tutorialObject.SetActive(false);
    }

    public void ResetTutorial()
    {
        StopAllCoroutines();
        ImgGlobo1.SetActive(false);
        ImgDaniel1.SetActive(false);
        Txt1Globo1.SetActive(false);
        Txt1Globo1.SetActive(false);
        Txt2Globo1.SetActive(false);
        Txt2Globo1.SetActive(false);
        Txt3Globo1.SetActive(false);
        Txt1Globo1.SetActive(false);
        Txt2Globo1.SetActive(false);
        Txt3Globo1.SetActive(false);
        ImgGlobo1.SetActive(false);
        ImgDaniel1.SetActive(false);
        ImgGlobo2.SetActive(false);
        ImgDaniel2.SetActive(false);
        Flecha2.SetActive(false);
        BotonTienda2.SetActive(false);
        Txt1Globo2.SetActive(false);
        Txt1Globo2.SetActive(false);
        Txt2Globo2.SetActive(false);
        Txt2Globo2.SetActive(false);
        Txt3Globo2.SetActive(false);
        ImgGlobo2.SetActive(false);
        ImgDaniel2.SetActive(false);
        Flecha2.SetActive(false);
        BotonTienda2.SetActive(false);
        ImgGlobo3.SetActive(false);
        ImgDaniel3.SetActive(false);
        Panel3.SetActive(false);
        PanelTienda3.SetActive(false);
        Flecha3.SetActive(false);
        Txt1Globo3.SetActive(false);
        BotonPersonajes3.SetActive(false);
        Txt1Globo3.SetActive(false);
        Txt2Globo3.SetActive(false);
        Txt1Globo3.SetActive(false);
        Txt2Globo3.SetActive(false);
        ImgGlobo3.SetActive(false);
        ImgGloboPresidente3.SetActive(false);
        Txt1GloboPresidente3.SetActive(false);
        ImgGloboPresidente3.SetActive(false);
        ImgGlobo3.SetActive(false);
        Txt3Globo3.SetActive(false);
        BotonPersonajes3.SetActive(false);
        Txt3Globo3.SetActive(false);
        //ImgElementos3.SetActive(false);
        Flecha3.SetActive(false);
        Txt4Globo3.SetActive(false);
        PanelTiendaPersonajes3.SetActive(false);
        Txt4Globo3.SetActive(false);
        Txt5Globo3.SetActive(false);
        Txt5Globo3.SetActive(false);
        Txt6Globo3.SetActive(false);
        PanelTiendaPersonajes3.SetActive(false);
        ImgGlobo3.SetActive(false);
        ImgDaniel3.SetActive(false);
        Panel3.SetActive(false);
        PanelTienda3.SetActive(false);
        ImgGlobo4.SetActive(false);
        ImgDaniel4.SetActive(false);
        Txt1Globo4.SetActive(false);
        Flecha4.SetActive(false);
        BotonPvZ4.SetActive(false);
        BotonJumper4.SetActive(false);
        Txt1Globo4.SetActive(false);
        Txt2Globo4.SetActive(false);
        Txt2Globo4.SetActive(false);
        Txt3Globo4.SetActive(false);
        ImgGlobo4.SetActive(false);
        ImgDaniel4.SetActive(false);
        Flecha4.SetActive(false);
        BotonPvZ4.SetActive(false);
        BotonJumper4.SetActive(false);
        ImgGlobo5.SetActive(false);
        ImgDaniel5.SetActive(false);
        Flecha5.SetActive(false);
        BotonPvZ5.SetActive(false);
        BotonJumper5.SetActive(false);
        Txt1Globo5.SetActive(false);
        //StopAllCoroutines();
        StartCoroutine(Tutorial());
    }

    public void ChargePVZTutorial() {

        //SceneManager.LoadScene("TutorialPVZ");
        //tutorialPanel.SetActive(false);
        //GameObject.Find("Canvas_MainMenu").SetActive(false);

        StartCoroutine(ChargeJumperTutorial("TutorialPVZ"));
    }

    /*public IEnumerator ChargePVZTutorial(string sceneToLoad) {

        tutorialPanel.SetActive(false);
        //GameObject.Find("Canvas_MainMenu").SetActive(false);

        GameManager.instance.SetSound(false);
        AsyncOperation scene = SceneManager.LoadSceneAsync(sceneToLoad);
        GameManager.instance.loadingCanvas.SetActive(true);


        while (!scene.isDone)
            yield return null;

        if (GameManager.instance.CanvasMainMenu.activeInHierarchy)
            GameManager.instance.CanvasMainMenu.SetActive(false);
        GameManager.instance.loadingCanvas.SetActive(false);

    }*/

    public void ChargeJumperTutorial() {

        StartCoroutine(ChargeJumperTutorial("JumpOver"));
        
    }

    public IEnumerator ChargeJumperTutorial(string sceneToLoad) {

        //SceneManager.LoadScene("JumpOver");
        tutorialPanel.SetActive(false);
        //GameObject.Find("Canvas_MainMenu").SetActive(false);

        GameManager.instance.SetSound(false);
        AsyncOperation scene = SceneManager.LoadSceneAsync(sceneToLoad);
        GameManager.instance.loadingCanvas.SetActive(true);


        while (!scene.isDone)
            yield return null;

        if (GameManager.instance.CanvasMainMenu.activeInHierarchy)
            GameManager.instance.CanvasMainMenu.SetActive(false);
        GameManager.instance.loadingCanvas.SetActive(false);
        
    }
}
