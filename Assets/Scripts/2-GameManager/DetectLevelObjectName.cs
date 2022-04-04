using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectLevelObjectName : MonoBehaviour
{

    public void SetNameNextLevel()
    {
        GameManager.instance.levelName = gameObject.name;
        GameManager.instance.levelObject = gameObject;
    }
}
