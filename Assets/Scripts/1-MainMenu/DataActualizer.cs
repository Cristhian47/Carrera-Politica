using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataActualizer : MonoBehaviour
{
    private void Start()
    {
        GameManager.instance.ActualizeData();
    }
}
