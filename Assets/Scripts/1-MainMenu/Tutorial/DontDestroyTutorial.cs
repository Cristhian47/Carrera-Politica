using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyTutorial : MonoBehaviour
{

    public int timesActivated = 0;

    public static DontDestroyTutorial instance;

    private void Awake()
    {
        if (DontDestroyTutorial.instance == null)
        {
            DontDestroyTutorial.instance = this;
        }
        else if (DontDestroyTutorial.instance != null)
        {
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        //timesActivated++;
        Debug.Log("entra al enable" + GameManager.instance.data.timesEntered);
        if (GameManager.instance.data.timesEntered == 0) gameObject.SetActive(true);
        else gameObject.SetActive(false);
    }

    private void Update()
    {
        
    }
}
