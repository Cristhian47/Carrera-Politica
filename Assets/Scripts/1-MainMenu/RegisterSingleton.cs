using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegisterSingleton : MonoBehaviour
{
    public static RegisterSingleton instance;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        if (RegisterSingleton.instance == null)
        {
            RegisterSingleton.instance = this;
        } else if (RegisterSingleton.instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        if (GameManager.instance.data.wasRegistered)
            gameObject.SetActive(false);

    }

    public void SetActive(bool value)
    {
        gameObject.SetActive(value);
    }
}
