using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunAllZombies : MonoBehaviour
{

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(0.2f);
        StartCoroutine(PlantsVsZombiesManager.instance.StunAllTheZombies(gameObject));
    }
}
