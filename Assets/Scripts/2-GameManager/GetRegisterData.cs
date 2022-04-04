using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class GetRegisterData : MonoBehaviour
{
    private string name;
    private string mail;
    private bool alreadyEntered = false;

    public InputField nameText;
    public InputField mailText;

    public GameObject registerButton;

    public GameObject registerPanel;
    public GameObject giftPanel;
    public GameObject errorPanel;

    private void Awake()
    {
        InitializeObjects();
    }

    private void OnEnable()
    {
        InitializeObjects();

    }

    private void InitializeObjects()
    {
        nameText = GameManager.instance.nameText;
        mailText = GameManager.instance.mailText;
        registerButton = GameManager.instance.registerButton;
        registerPanel = GameManager.instance.registerPanel;
        giftPanel = GameManager.instance.giftPanel;
        errorPanel = GameManager.instance.errorPanel;
    }

    public void GetDatas()
    {
        name = nameText.text;
        mail = mailText.text;

        Debug.Log(name);
        Debug.Log(mail);

        if (GameManager.instance.data.timesEntered == 1 && !alreadyEntered) GameManager.instance.tutorialObject.SetActive(true);

        alreadyEntered = true;

        StartCoroutine(UpdateDatas());
        
    }

    private IEnumerator UpdateDatas()
    {
        WWWForm form = new WWWForm();
        form.AddField("name", name);
        form.AddField("email", mail);
        UnityWebRequest www = UnityWebRequest.Post("https://www.somniastudios.com/create-person/", form);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
            errorPanel.SetActive(true);
        }
        else
        {
            giftPanel.SetActive(true);
        }
        
    }

    public void RegisterComplete()
    {
        GameManager.instance.data.wasRegistered = true;
        Debug.Log("Form upload complete!");
        //Desbloquea personaje
        registerButton.SetActive(false);
        GameManager.instance.data.haveCharacterTwo = true;
        

        GameManager.instance.ActualizeData();
    }

    public void EnableRegisterPanel()
    {
        if(!GameManager.instance.data.wasRegistered)
            registerPanel.SetActive(true);
    }
}
