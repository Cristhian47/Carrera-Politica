using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssignCardCooldown : MonoBehaviour
{
    private void Start()
    {
        //gameObject.GetComponent<RectTransform>().rect.height = gameObject.transform.parent.GetComponent<RectTransform>().rect.height;
        transform.position = new Vector3(transform.position.x - transform.parent.position.x, 0, 0);
        transform.localScale = transform.parent.localScale;
        PlantsVsZombiesManager.instance.cooldownObjects.Add(gameObject);
    }
}
