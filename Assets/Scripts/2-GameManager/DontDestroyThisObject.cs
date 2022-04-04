using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyThisObject : MonoBehaviour
{
    public static DontDestroyThisObject instance;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        

        if (instance == null)
        {
            instance = this;
        }else if(instance != null && gameObject.name == instance.gameObject.name)
        {
            Destroy(gameObject);
        }
    }

    /*private void Start()
    {
        GameManager.instance.dontDestroyObjects.Add(gameObject);
    }*/
}
