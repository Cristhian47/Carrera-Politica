using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InstantiatePig : MonoBehaviour
{
    public GameObject pigObject;

    private void OnDestroy()
    {
        if(SceneManager.GetActiveScene().name == "PlantsVsZombiesInfinite" || SceneManager.GetActiveScene().name == "Congreso") Instantiate(pigObject, transform.position, Quaternion.identity);
        
    }
}
