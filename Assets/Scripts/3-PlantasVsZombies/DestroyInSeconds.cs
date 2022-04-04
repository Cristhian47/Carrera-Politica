using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyInSeconds : MonoBehaviour
{
    //public float lifeTime;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(30);
        Destroy(gameObject);
    }

    private void Update()
    {
        transform.Translate(-0.03f, 0, 0);
    }
}
