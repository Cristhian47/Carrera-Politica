using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceManagerMenu : MonoBehaviour {

    public static InterfaceManagerMenu instance;

    //-----------------VARIABLES---------------------
    public GameObject panelMenuPrincipal;
    public GameObject panelMensaje;
    public GameObject panelRedes;
    public GameObject panelOpciones;
    public GameObject panelEstampas;
    public GameObject panelRuleta;
    public GameObject panelAnimales;
    public GameObject panelLoading;

    public GameObject panelFacebook;
    public GameObject panelFacebookNew;
    public GameObject panelYoutube;
    public GameObject panelYoutubeNew;
    public GameObject panelTwitter;
    public GameObject panelTwitterNew;
    public GameObject panelInstagram;
    public GameObject panelInstagramNew;

    public GameObject panelPerfil;
    public GameObject panelCreditos;

    public GameObject panelRegistro;

    //public GameObject panelLogros;
    //public GameObject panelRanking;

    //--------------Variables de paneles Minijuegos---------
    public GameObject panelMundosPlantasVsZombies;
    public GameObject panelMundosPlantasVsZombiesNew;
    public GameObject panelNivelesWorldUnoPlantasVsZombies;
    public GameObject panelNivelesWorldDosPlantasVsZombies;
    public GameObject panelNivelesWorldTresPlantasVsZombies;
    //public GameObject panelNivelesWorldCuatroPlantasVsZombies;

    public GameObject panelMundosJumper;
    public GameObject panelMundosJumperNew;
    public GameObject panelNivelesWorldUnoJumper;
    public GameObject panelNivelesWorldDosJumper;
    public GameObject panelNivelesWorldTresJumper;
    //public GameObject panelNivelesWorldCuatroJumper;

    //public GameObject panelMundosAngryBirds;
    //public GameObject panelNivelesWorldUnoAngryBirds;
    //public GameObject panelNivelesWorldDosAngryBirds;
    //public GameObject panelNivelesWorldTresAngryBirds;
    //public GameObject panelNivelesWorldCuatroAngryBirds;

    //public GameObject panelMundosRunner;
    //public GameObject panelNivelesWorldUnoRunner;
    //public GameObject panelNivelesWorldDosRunner;
    //public GameObject panelNivelesWorldTresRunner;
    //public GameObject panelNivelesWorldCuatroRunner;

    //--------------FIN--Variables de paneles Minijuegos---------

    //--------------Variables de paneles Tienda---------
    public GameObject panelTienda;
    //-----------------------
    public GameObject panelTiendaSecciones;
    //-----------------------
    public GameObject panelTiendaPersonajes;
    public GameObject panelTiendaMundos;
    public GameObject panelTiendaRopa;
    public GameObject panelTiendaPowerUps;
    public GameObject panelTiendaEstrellas;
    public GameObject panelTiendaCorazones;
    //--------------FIN--Variables de paneles Tienda---------

    //--------------Variables-Compartir-En-Redes-Sociales-------------------

    [Space(100)]
    private bool isProcessing = false;      //Confirma si se esta procesando una peticion de compartir
    public Image buttonShare;       //Imagen que se mostrará al compartir
    public string mensaje;      //Mensaje que se mostrará al compartir

    [Space(20)]
    public Text titleText;
    public Text nameText;
    public Text descriptionText;

    [Space(20)]

    public Texture2D shareTexture;
    public string shareText;


    //-----------------FIN VARIABLES---------------------


    //----------------------FUNCIONES-----------------------

    private void Awake()
    {
        if (InterfaceManagerMenu.instance == null)
        {
            InterfaceManagerMenu.instance = this;
        }
        else if (InterfaceManagerMenu.instance != null)
        {
            Destroy(gameObject);
        }
    }

    //-------------------TIENDA------------------------
    public void ActivarTienda()
    {
        panelMenuPrincipal.SetActive(false);
        panelTienda.SetActive(true);
    }

    public void DesactivarPanelTienda()
    {
        panelMenuPrincipal.SetActive(true);
        panelTienda.SetActive(false);
    }

    public void ActivarListaPersonajes()
    {
        titleText.text = "Personajes";
        nameText.text = "";
        descriptionText.text = "Aquí puedes comprar todo tipo de personajes... Incluyendome!";

        panelTiendaSecciones.SetActive(false);
        panelTiendaPersonajes.SetActive(true);
        panelTiendaMundos.SetActive(false);
        panelTiendaRopa.SetActive(false);
        panelTiendaPowerUps.SetActive(false);
        panelTiendaEstrellas.SetActive(false);
        panelTiendaCorazones.SetActive(false);
    }

    public void ActivarListaMundos()
    {
        titleText.text = "Mundos";
        nameText.text = "";
        descriptionText.text = "Aquí puedes comprar todos los mundos en los que puedes jugar";

        panelTiendaSecciones.SetActive(false);
        panelTiendaPersonajes.SetActive(false);
        panelTiendaMundos.SetActive(true);
        panelTiendaRopa.SetActive(false);
        panelTiendaPowerUps.SetActive(false);
        panelTiendaEstrellas.SetActive(false);
        panelTiendaCorazones.SetActive(false);
    }

    public void ActivarListaCartas()
    {
        panelTiendaSecciones.SetActive(false);
        panelTiendaPersonajes.SetActive(false);
        panelTiendaMundos.SetActive(false);
        panelTiendaRopa.SetActive(false);
        panelTiendaPowerUps.SetActive(false);
        panelTiendaEstrellas.SetActive(false);
        panelTiendaCorazones.SetActive(false);
    }

    public void ActivarListaRopa()
    {
        titleText.text = "Ropa";
        nameText.text = "";
        descriptionText.text = "Aquí puedes comprar todos los vestuarios para usarlos en tu personaje preferido";

        panelTiendaSecciones.SetActive(false);
        panelTiendaPersonajes.SetActive(false);
        panelTiendaMundos.SetActive(false);
        panelTiendaRopa.SetActive(true);
        panelTiendaPowerUps.SetActive(false);
        panelTiendaEstrellas.SetActive(false);
        panelTiendaCorazones.SetActive(false);
    }

    public void ActivarListaPowerUps()
    {
        titleText.text = "PowerUps";
        nameText.text = "";
        descriptionText.text = "Aquí puedes comprar poderes que te pueden ayudar en tus partidas";

        panelTiendaSecciones.SetActive(false);
        panelTiendaPersonajes.SetActive(false);
        panelTiendaMundos.SetActive(false);
        panelTiendaRopa.SetActive(false);
        panelTiendaPowerUps.SetActive(true);
        panelTiendaEstrellas.SetActive(false);
        panelTiendaCorazones.SetActive(false);
    }

    public void ActivarListaEstrellas()
    {
        titleText.text = "Estrellas";
        nameText.text = "";
        descriptionText.text = "Aquí puedes reclamar estrellas cada cierto tiempo o ver un video para obtener aun mas estrellas!";

        panelTiendaSecciones.SetActive(false);
        panelTiendaPersonajes.SetActive(false);
        panelTiendaMundos.SetActive(false);
        panelTiendaRopa.SetActive(false);
        panelTiendaPowerUps.SetActive(false);
        panelTiendaEstrellas.SetActive(true);
        panelTiendaCorazones.SetActive(false);
    }

    public void ActivarListaCorazones()
    {
        titleText.text = "Corazones";
        nameText.text = "";
        descriptionText.text = "Aquí puedes comprar corazones para continuar si pierdes en una partida";

        panelTiendaSecciones.SetActive(false);
        panelTiendaPersonajes.SetActive(false);
        panelTiendaMundos.SetActive(false);
        panelTiendaRopa.SetActive(false);
        panelTiendaPowerUps.SetActive(false);
        panelTiendaEstrellas.SetActive(false);
        panelTiendaCorazones.SetActive(true);
    }

    public void VolverAListaSecciones()
    {
        panelTiendaSecciones.SetActive(true);
        panelTiendaPersonajes.SetActive(false);
        panelTiendaMundos.SetActive(false);
        panelTiendaRopa.SetActive(false);
        panelTiendaPowerUps.SetActive(false);
        panelTiendaEstrellas.SetActive(false);
        panelTiendaCorazones.SetActive(false);
    }
    //-------------------FIN-TIENDA------------------------

    //-------------------MENSAJE------------------------

    public void ActiveMessage()
    {
        panelMenuPrincipal.SetActive(false);
        panelMensaje.SetActive(true);
    }

    public void DesactiveMessage()
    {
        panelMenuPrincipal.SetActive(true);
        panelMensaje.SetActive(false);
    }
    //-------------------FIN-MENSAJE------------------------

    //-------------------REDES------------------------

    public void ActiveNetworks()
    {
        panelMenuPrincipal.SetActive(false);
        panelRedes.SetActive(true);
    }

    public void DesactiveNetworks()
    {
        panelMenuPrincipal.SetActive(true);
        panelRedes.SetActive(false);
    }

    //----Facebook----//
    public void ActiveFacebookPanel()
    {
        panelFacebookNew.SetActive(true);
        //panelFacebook.SetActive(true);
    }

    public void InviteFriendsOption()
    {
        
    }

    public void ShareInFacebookOption()
    {
        buttonShare.enabled = false;
        if (!isProcessing)
        {
            StartCoroutine(ShareScreenshot());
        }
    }

    public void CastaTutorsFacebookOption()
    {
        Application.OpenURL("https://www.facebook.com/castatutor");
    }

    public void WoldevFacebookOption() {
        Application.OpenURL("https://www.facebook.com/WoldevOficial/");
    }

    public void SomniaFacebookOption() {
        Application.OpenURL("https://www.facebook.com/enjoysomniastudios/");
    }

    public void DesactiveFacebookPanel()
    {
        panelFacebookNew.SetActive(false);
        //panelFacebook.SetActive(false);
    }
    //----Fin-Facebook----//

    //----Youtube----//
    public void ActiveYoutubePanel()
    {
        //panelYoutube.SetActive(true);
        panelYoutubeNew.SetActive(true);
    }

    public void CastaTutorsYoutubeOption()
    {
        Application.OpenURL("https://www.youtube.com/channel/UCQGRqVSTh_5bMglAs702klw");
    }

    public void WoldevYoutubeOption() {
        Application.OpenURL("https://www.youtube.com/channel/UCzd_uj9e1JXPYc6aXesROmg");
    }

    public void SomniaYoutubeOption() {
        Application.OpenURL("https://www.youtube.com/channel/UCxmjkPCcci91bLr1QTSKatw");
    }

    public void DesactiveYoutubePanel()
    {
        //panelYoutube.SetActive(false);
        panelYoutubeNew.SetActive(false);
    }
    //----Fin-Youtube----//

    //----Twitter----//
    public void ActiveTwitterPanel()
    {
        //panelTwitter.SetActive(true);
        panelTwitterNew.SetActive(true);
    }

    public void ShareInTwitterOption()
    {
        buttonShare.enabled = false;
        if (!isProcessing)
        {
            StartCoroutine(ShareScreenshot());
        }
    }

    public void CastaTutorsTwitterOption()
    {
        Application.OpenURL("https://twitter.com/castatutor");
    }

    public void WoldevTwitterOption() {
        Application.OpenURL("https://twitter.com/WoldevOficial");
    }

    public void SomniaTwitterOption() {
        Application.OpenURL("https://twitter.com/StudiosSomnia");
    }

    public void DesactiveTwitterPanel()
    {
        //panelTwitter.SetActive(false);
        panelTwitterNew.SetActive(false);
    }
    //----Fin-Twitter----//

    //----Instagram----//
    public void ActiveInstagramPanel()
    {
        //panelInstagram.SetActive(true);
        panelInstagramNew.SetActive(true);
    }

    public void CastaTutorsInstagramOption()
    {
        Application.OpenURL("https://www.instagram.com/castatutor/?hl=es");
    }

    public void WoldevInstagramOption() {
        Application.OpenURL("https://www.instagram.com/woldevoficial/?hl=es-la");
    }

    public void SomniaInstagramOption() {
        Application.OpenURL("https://www.instagram.com/somniastudio/?hl=es-la");
    }

    public void DesactiveInstagramPanel()
    {
        //panelInstagram.SetActive(false);
        panelInstagramNew.SetActive(false);
    }
    //----Fin-Instagram----//

    public void FacebookSharing()
    {
        StartCoroutine(FacebookShare());
    }

    //Función para compartir en facebook
    private IEnumerator FacebookShare()
    {

        
        yield return new WaitForEndOfFrame();
        if (GameManager.instance.data.timesShared == 0)
        {

            Debug.Log("Comparte");
            string filePath = Path.Combine(Application.temporaryCachePath, "shared img.png");
            File.WriteAllBytes(filePath, shareTexture.EncodeToPNG());

            //new NativeShare().AddFile(filePath).SetSubject("Subject goes here").SetText(shareText).Share();
            // TODO: Debe retornar un booleano para saber si se compartio de manera exitosa


            GameManager.instance.data.stars += 2000;
            GameManager.instance.gameObject.GetComponent<AudioSource>().Play();
            

            GameManager.instance.data.timesShared++;
            GameManager.instance.ActualizeData();
        }
            
    }

    public IEnumerator ShareScreenshot()
    {
        isProcessing = true;
        // wait for graphics to render
        yield return new WaitForEndOfFrame();
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- PHOTO
        // create the texture
        Texture2D screenTexture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, true);
        // put buffer into texture
        screenTexture.ReadPixels(new Rect(0f, 0f, Screen.width, Screen.height), 0, 0);
        // apply
        screenTexture.Apply();
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- PHOTO
        byte[] dataToSave = screenTexture.EncodeToPNG();
        string destination = Path.Combine(Application.persistentDataPath, System.DateTime.Now.ToString("yyyy-MM-dd-HHmmss") + ".png");
        File.WriteAllBytes(destination, dataToSave);
        if (!Application.isEditor)
        {
            // block to open the file and share it ------------START
            AndroidJavaClass intentClass = new AndroidJavaClass("android.content.Intent");
            AndroidJavaObject intentObject = new AndroidJavaObject("android.content.Intent");
            intentObject.Call<AndroidJavaObject>("setAction", intentClass.GetStatic<string>("ACTION_SEND"));
            AndroidJavaClass uriClass = new AndroidJavaClass("android.net.Uri");
            AndroidJavaObject uriObject = uriClass.CallStatic<AndroidJavaObject>("parse", "file://" + destination);
            intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_STREAM"), uriObject);

            intentObject.Call<AndroidJavaObject>("setType", "text/plain");
            intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_TEXT"), "" + mensaje);
            intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_SUBJECT"), "SUBJECT");

            intentObject.Call<AndroidJavaObject>("setType", "image/jpeg");
            AndroidJavaClass unity = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject currentActivity = unity.GetStatic<AndroidJavaObject>("currentActivity");

            currentActivity.Call("startActivity", intentObject);
            GameManager.instance.data.timesShared++;
            if(GameManager.instance.data.timesShared == 1)
            {
                GameManager.instance.data.stars += 2000;
                GameManager.instance.ActualizeData();
            }
                
        }
        isProcessing = false;
        buttonShare.enabled = true;
    }

    //-------------------FIN-REDES------------------------

    //-------------------OPCIONES------------------------

    public void ActiveOptionsPanel()
    {
        panelMenuPrincipal.SetActive(false);
        panelOpciones.SetActive(true);
    }

    public void ActiveProfile()
    {
        panelOpciones.SetActive(false);
        panelPerfil.SetActive(true);
    }

    public void DesactiveProfile()
    {
        panelOpciones.SetActive(true);
        panelPerfil.SetActive(false);
    }

    public void ActiveCredits()
    {
        panelOpciones.SetActive(false);
        panelCreditos.SetActive(true);
    }

    public void DesactiveCredits()
    {
        panelOpciones.SetActive(true);
        panelCreditos.SetActive(false);
    }

    public void DesactiveOptionsPanel()
    {
        panelMenuPrincipal.SetActive(true);
        panelOpciones.SetActive(false);
    }

    //-------------------FIN-OPCIONES------------------------

    //-------------------ESTAMPAS------------------------

    public void ActiveStampsPanel()
    {
        panelMenuPrincipal.SetActive(false);
        panelEstampas.SetActive(true);
    }

    public void DesactiveStampsPanel()
    {
        panelMenuPrincipal.SetActive(true);
        panelEstampas.SetActive(false);
    }

    //-------------------FIN-ESTAMPAS------------------------

    //-------------------RULETA------------------------

    public void ActiveRoulettePanel()
    {
        panelMenuPrincipal.SetActive(false);
        panelRuleta.SetActive(true);
    }

    public void DesactiveRoulettePanel()
    {
        panelMenuPrincipal.SetActive(true);
        panelRuleta.SetActive(false);
    }

    //-------------------FIN-RULETA------------------------

    //-------------------ANIMALES------------------------

    public void ActiveAnimalsPanel()
    {
        panelMenuPrincipal.SetActive(false);
        panelAnimales.SetActive(true);
    }

    public void DesactiveAnimalsPanel()
    {
        panelMenuPrincipal.SetActive(true);
        panelAnimales.SetActive(false);
    }

    //-------------------FIN-ANIMALES------------------------
    

    //-------------------MINIJUEGOS------------------------

    public void ActiveWorldsGameOne()
    {
            panelRuleta.SetActive(false);
            panelOpciones.SetActive(false);
            panelPerfil.SetActive(false);
            panelCreditos.SetActive(false);
            panelEstampas.SetActive(false);
            panelAnimales.SetActive(false);
            panelMundosPlantasVsZombiesNew.SetActive(true);
            //panelMundosPlantasVsZombies.SetActive(true);
            DesactiveWorldsGameTwo();
            DesactiveWorldsGameThree();
            DesactiveWorldsGameFour();
    }

    public void ActiveLevelsWorldOneGameOne()
    {
        DesactiveAllWorlds();
        panelMundosPlantasVsZombiesNew.SetActive(false);
        //panelMundosPlantasVsZombies.SetActive(false);
        panelNivelesWorldUnoPlantasVsZombies.SetActive(true);
    }

    public void DesactiveLevelsWorldOneGameOne()
    {
        DesactiveAllWorlds();
        panelMundosPlantasVsZombiesNew.SetActive(true);
        //panelMundosPlantasVsZombies.SetActive(true);
        panelNivelesWorldUnoPlantasVsZombies.SetActive(false);
    }

    public void ActiveLevelsWorldTwoGameOne()
    {
        DesactiveAllWorlds();
        panelMundosPlantasVsZombiesNew.SetActive(false);
        //panelMundosPlantasVsZombies.SetActive(false);
        panelNivelesWorldDosPlantasVsZombies.SetActive(true);
    }

    public void DesactiveLevelsWorldTwoGameOne()
    {
        DesactiveAllWorlds();
        panelMundosPlantasVsZombiesNew.SetActive(true);
        //panelMundosPlantasVsZombies.SetActive(true);
        panelNivelesWorldDosPlantasVsZombies.SetActive(false);
    }

    public void ActiveLevelsWorldThreeGameOne()
    {
        DesactiveAllWorlds();
        panelMundosPlantasVsZombiesNew.SetActive(false);
        //panelMundosPlantasVsZombies.SetActive(false);
        panelNivelesWorldTresPlantasVsZombies.SetActive(true);
    }

    public void DesactiveLevelsWorldThreeGameOne()
    {
        DesactiveAllWorlds();
        panelMundosPlantasVsZombiesNew.SetActive(true);
        //panelMundosPlantasVsZombies.SetActive(true);
        panelNivelesWorldTresPlantasVsZombies.SetActive(false);
    }

    public void ActiveLevelsWorldFourGameOne()
    {
        DesactiveAllWorlds();
        panelMundosPlantasVsZombiesNew.SetActive(false);
        //panelMundosPlantasVsZombies.SetActive(false);
        //panelNivelesWorldCuatroPlantasVsZombies.SetActive(true);
    }

    public void DesactiveLevelsWorldFourGameOne()
    {
        DesactiveAllWorlds();
        panelMundosPlantasVsZombiesNew.SetActive(true);
        //panelMundosPlantasVsZombies.SetActive(true);
        //panelNivelesWorldCuatroPlantasVsZombies.SetActive(false);
    }

    public void DesactiveWorldsGameOne()
    {
        panelMundosPlantasVsZombiesNew.SetActive(false);
        //panelMundosPlantasVsZombies.SetActive(false);
        panelNivelesWorldUnoPlantasVsZombies.SetActive(false);
        panelNivelesWorldDosPlantasVsZombies.SetActive(false);
        panelNivelesWorldTresPlantasVsZombies.SetActive(false);
    }

    public void ActiveWorldsGameTwo()
    {
            panelRuleta.SetActive(false);
            panelOpciones.SetActive(false);
            panelPerfil.SetActive(false);
            panelCreditos.SetActive(false);
            panelEstampas.SetActive(false);
            panelAnimales.SetActive(false);
            //panelMundosJumper.SetActive(true);
            panelMundosJumperNew.SetActive(true);
            DesactiveWorldsGameOne();
            DesactiveWorldsGameThree();
            DesactiveWorldsGameFour();
    }

    public void ActiveLevelsWorldOneGameTwo()
    {
        DesactiveAllWorlds();
        panelMundosJumperNew.SetActive(false);
        //panelMundosJumper.SetActive(false);
        panelNivelesWorldUnoJumper.SetActive(true);
    }

    public void DesactiveLevelsWorldOneGameTwo()
    {
        DesactiveAllWorlds();
        Time.timeScale = 1;
        panelMundosJumperNew.SetActive(true);
        //panelMundosJumper.SetActive(true);
        panelNivelesWorldUnoJumper.SetActive(false);
    }

    public void ActiveLevelsWorldTwoGameTwo()
    {
        DesactiveAllWorlds();
        panelMundosJumperNew.SetActive(false);
        //panelMundosJumper.SetActive(false);
        panelNivelesWorldDosJumper.SetActive(true);
    }

    public void DesactiveLevelsWorldTwoGameTwo()
    {
        DesactiveAllWorlds();
        Time.timeScale = 1;
        panelMundosJumperNew.SetActive(true);
        //panelMundosJumper.SetActive(true);
        panelNivelesWorldDosJumper.SetActive(false);
    }

    public void ActiveLevelsWorldThreeGameTwo()
    {
        DesactiveAllWorlds();
        panelMundosJumperNew.SetActive(false);
        //panelMundosJumper.SetActive(false);
        panelNivelesWorldTresJumper.SetActive(true);
    }

    public void DesactiveLevelsWorldThreeGameTwo()
    {
        DesactiveAllWorlds();
        Time.timeScale = 1;
        panelMundosJumperNew.SetActive(true);
        //panelMundosJumper.SetActive(true);
        panelNivelesWorldTresJumper.SetActive(false);
    }

    public void ActiveLevelsWorldFourGameTwo()
    {
        DesactiveAllWorlds();
        panelMundosJumperNew.SetActive(false);
        //panelMundosJumper.SetActive(false);
        //panelNivelesWorldCuatroJumper.SetActive(true);
    }

    public void DesactiveLevelsWorldFourGameTwo()
    {
        DesactiveAllWorlds();
        Time.timeScale = 1;
        panelMundosJumperNew.SetActive(true);
        //panelMundosJumper.SetActive(true);
        //panelNivelesWorldCuatroJumper.SetActive(false);
    }

    public void DesactiveWorldsGameTwo()
    {
        //panelMundosJumper.SetActive(false);
        panelMundosJumperNew.SetActive(false);
        panelNivelesWorldUnoJumper.SetActive(false);
        panelNivelesWorldDosJumper.SetActive(false);
        panelNivelesWorldTresJumper.SetActive(false);
    }

    public void ActiveWorldsGameThree()
    {
            panelRuleta.SetActive(false);
            panelOpciones.SetActive(false);
            panelPerfil.SetActive(false);
            panelCreditos.SetActive(false);
            panelEstampas.SetActive(false);
            panelAnimales.SetActive(false);
            //panelMundosAngryBirds.SetActive(true);
            DesactiveWorldsGameOne();
            DesactiveWorldsGameTwo();
            DesactiveWorldsGameFour();
    }

    public void ActiveLevelsWorldOneGameThree()
    {
        DesactiveAllWorlds();
        //panelMundosAngryBirds.SetActive(false);
        //panelNivelesWorldUnoAngryBirds.SetActive(true);
    }

    public void DesactiveLevelsWorldOneGameThree()
    {
        DesactiveAllWorlds();
        //panelMundosAngryBirds.SetActive(true);
        //panelNivelesWorldUnoAngryBirds.SetActive(false);
    }

    public void ActiveLevelsWorldTwoGameThree()
    {
        DesactiveAllWorlds();
        //panelMundosAngryBirds.SetActive(false);
        //panelNivelesWorldDosAngryBirds.SetActive(true);
    }

    public void DesactiveLevelsWorldTwoGameThree()
    {
        DesactiveAllWorlds();
        //panelMundosAngryBirds.SetActive(true);
        //panelNivelesWorldDosAngryBirds.SetActive(false);
    }

    public void ActiveLevelsWorldThreeGameThree()
    {
        DesactiveAllWorlds();
        //panelMundosAngryBirds.SetActive(false);
        //panelNivelesWorldTresAngryBirds.SetActive(true);
    }

    public void DesactiveLevelsWorldThreeGameThree()
    {
        DesactiveAllWorlds();
        //panelMundosAngryBirds.SetActive(true);
        //panelNivelesWorldTresAngryBirds.SetActive(false);
    }

    public void ActiveLevelsWorldFourGameThree()
    {
        DesactiveAllWorlds();
        //panelMundosAngryBirds.SetActive(false);
        //panelNivelesWorldCuatroAngryBirds.SetActive(true);
    }

    public void DesactiveLevelsWorldFourGameThree()
    {
        DesactiveAllWorlds();
        //panelMundosAngryBirds.SetActive(true);
        //panelNivelesWorldCuatroAngryBirds.SetActive(false);
    }

    public void DesactiveWorldsGameThree()
    {
        //panelMundosAngryBirds.SetActive(false);
        //panelNivelesWorldUnoAngryBirds.SetActive(false);
        //panelNivelesWorldDosAngryBirds.SetActive(false);
        //panelNivelesWorldTresAngryBirds.SetActive(false);
        //panelNivelesWorldCuatroAngryBirds.SetActive(false);
    }

    public void ActiveWorldsGameFour()
    {
            panelRuleta.SetActive(false);
            panelOpciones.SetActive(false);
            panelPerfil.SetActive(false);
            panelCreditos.SetActive(false);
            panelEstampas.SetActive(false);
            panelAnimales.SetActive(false);
            //panelMundosRunner.SetActive(true);
            DesactiveWorldsGameOne();
            DesactiveWorldsGameTwo();
            DesactiveWorldsGameThree();
    }

    public void ActiveLevelsWorldOneGameFour()
    {
        DesactiveAllWorlds();
        //panelMundosRunner.SetActive(false);
        //panelNivelesWorldUnoRunner.SetActive(true);
    }

    public void DesactiveLevelsWorldOneGameFour()
    {
        DesactiveAllWorlds();
        //panelMundosRunner.SetActive(true);
        //panelNivelesWorldUnoRunner.SetActive(false);
    }

    public void ActiveLevelsWorldTwoGameFour()
    {
        DesactiveAllWorlds();
        //panelMundosRunner.SetActive(false);
        //panelNivelesWorldDosRunner.SetActive(true);
    }

    public void DesactiveLevelsWorldTwoGameFour()
    {
        DesactiveAllWorlds();
        //panelMundosRunner.SetActive(true);
        //panelNivelesWorldDosRunner.SetActive(false);
    }

    public void ActiveLevelsWorldThreeGameFour()
    {
        DesactiveAllWorlds();
        //panelMundosRunner.SetActive(false);
        //panelNivelesWorldTresRunner.SetActive(true);
    }

    public void DesactiveLevelsWorldThreeGameFour()
    {
        DesactiveAllWorlds();
        //panelMundosRunner.SetActive(true);
        //panelNivelesWorldTresRunner.SetActive(false);
    }

    public void ActiveLevelsWorldFourGameFour()
    {
        DesactiveAllWorlds();
        //panelMundosRunner.SetActive(false);
        //panelNivelesWorldCuatroRunner.SetActive(true);
    }

    public void DesactiveLevelsWorldFourGameFour()
    {
        DesactiveAllWorlds();
        //panelMundosRunner.SetActive(true);
        //panelNivelesWorldCuatroRunner.SetActive(false);
    }

    public void DesactiveWorldsGameFour()
    {
        //panelMundosRunner.SetActive(false);
        //panelNivelesWorldUnoRunner.SetActive(false);
        //panelNivelesWorldDosRunner.SetActive(false);
        //panelNivelesWorldTresRunner.SetActive(false);
        //panelNivelesWorldCuatroRunner.SetActive(false);
    }

    public void DesactiveAllWorlds()
    {
        DesactiveWorldsGameOne();
        DesactiveWorldsGameTwo();
        DesactiveWorldsGameThree();
        DesactiveWorldsGameFour();
    }

    private bool HaveLevelsActive()
    {
        bool haveActive = false;

        if (panelNivelesWorldUnoPlantasVsZombies.activeInHierarchy || panelNivelesWorldDosPlantasVsZombies.activeInHierarchy || panelNivelesWorldTresPlantasVsZombies.activeInHierarchy)
        {
            haveActive = true;
        }else if (panelNivelesWorldUnoJumper.activeInHierarchy || panelNivelesWorldDosJumper.activeInHierarchy || panelNivelesWorldTresJumper.activeInHierarchy)
        {
            haveActive = true;
        }/*else if (panelNivelesWorldUnoAngryBirds.activeInHierarchy || panelNivelesWorldDosAngryBirds.activeInHierarchy || panelNivelesWorldTresAngryBirds.activeInHierarchy || panelNivelesWorldCuatroAngryBirds.activeInHierarchy)
        {
            haveActive = true;
        }else if (panelNivelesWorldUnoRunner.activeInHierarchy || panelNivelesWorldDosRunner.activeInHierarchy || panelNivelesWorldTresRunner.activeInHierarchy || panelNivelesWorldCuatroRunner.activeInHierarchy)
        {
            haveActive = true;
        }*/

        return haveActive;
    }

    //-------------------FIN-MINIJUEGOS------------------------

    public void OpenStars()
    {
        panelTienda.SetActive(true);
        panelTiendaEstrellas.SetActive(true);
        panelTiendaCorazones.SetActive(false);
        panelTiendaMundos.SetActive(false);
        panelTiendaRopa.SetActive(false);
        panelTiendaPersonajes.SetActive(false);
        panelTiendaPowerUps.SetActive(false);
        panelTiendaSecciones.SetActive(false);
    }

    public void OpenHearts()
    {
        panelTienda.SetActive(true);
        panelTiendaEstrellas.SetActive(false);
        panelTiendaCorazones.SetActive(true);
        panelTiendaMundos.SetActive(false);
        panelTiendaPersonajes.SetActive(false);
        panelTiendaPowerUps.SetActive(false);
        panelTiendaSecciones.SetActive(false);
    }

    public void OpenCredits()
    {
        panelCreditos.SetActive(true);
    }

    public void CloseAll()
    {
        panelMenuPrincipal.SetActive(true);
        panelMensaje.SetActive(false);
        panelRedes.SetActive(false);
        panelOpciones.SetActive(false);
        panelEstampas.SetActive(false);
        panelRuleta.SetActive(false);
        panelAnimales.SetActive(false);
        panelLoading.SetActive(false);

        panelFacebook.SetActive(false);
        panelFacebookNew.SetActive(false);
        panelYoutube.SetActive(false);
        panelYoutubeNew.SetActive(false);
        panelTwitter.SetActive(false);
        panelTwitterNew.SetActive(false);
        panelInstagram.SetActive(false);
        panelInstagramNew.SetActive(false);

        panelPerfil.SetActive(false);
        panelCreditos.SetActive(false);

        panelMundosPlantasVsZombiesNew.SetActive(false);
        panelMundosPlantasVsZombies.SetActive(false);
        panelNivelesWorldUnoPlantasVsZombies.SetActive(false);
        panelNivelesWorldDosPlantasVsZombies.SetActive(false);
        panelNivelesWorldTresPlantasVsZombies.SetActive(false);
        //panelNivelesWorldCuatroPlantasVsZombies.SetActive(false);

        panelMundosJumper.SetActive(false);
        panelMundosJumperNew.SetActive(false);
        panelNivelesWorldUnoJumper.SetActive(false);
        panelNivelesWorldDosJumper.SetActive(false);
        panelNivelesWorldTresJumper.SetActive(false);
        //panelNivelesWorldCuatroJumper.SetActive(false);

        //panelMundosAngryBirds.SetActive(false);
        //panelNivelesWorldUnoAngryBirds.SetActive(false);
        //panelNivelesWorldDosAngryBirds.SetActive(false);
        //panelNivelesWorldTresAngryBirds.SetActive(false);
        //panelNivelesWorldCuatroAngryBirds.SetActive(false);

        //panelMundosRunner.SetActive(false);
        //panelNivelesWorldUnoRunner.SetActive(false);
        //panelNivelesWorldDosRunner.SetActive(false);
        //panelNivelesWorldTresRunner.SetActive(false);
        //panelNivelesWorldCuatroRunner.SetActive(false);

        panelTienda.SetActive(false);
        panelTiendaSecciones.SetActive(true);
        panelTiendaPersonajes.SetActive(false);
        panelTiendaMundos.SetActive(false);
        panelTiendaRopa.SetActive(false);
        panelTiendaPowerUps.SetActive(false);
        panelTiendaEstrellas.SetActive(false);
        panelTiendaCorazones.SetActive(false);
    }

    public void AceptRegister()
    {
        panelRegistro.SetActive(false);
    }

    public void NoRegister()
    {
        panelRegistro.SetActive(false);
        if (GameManager.instance.data.timesEntered == 1) GameManager.instance.tutorialObject.SetActive(true);
    }

    public void GoToWorlds()
    {
        panelTienda.SetActive(true);
        panelTiendaEstrellas.SetActive(false);
        panelTiendaCorazones.SetActive(false);
        panelTiendaMundos.SetActive(true);
        panelTiendaRopa.SetActive(false);
        panelTiendaPersonajes.SetActive(false);
        panelTiendaPowerUps.SetActive(false);
        panelTiendaSecciones.SetActive(false);
    }

    public void CloseGame()
    {
        Debug.Log("Cerrar juego");
        Application.Quit();
    }

    //----------------------FIN FUNCIONES-----------------------
}
