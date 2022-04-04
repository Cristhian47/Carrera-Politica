using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarFlower : MonoBehaviour
{
    public float starsGeneratingTime = 1;
    public GameObject star;
    public int starsToGenerate = 1;

    private IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(starsGeneratingTime);
            GetComponent<AudioSource>().Play();
            for (int i = 0; i < starsToGenerate; i++)
            {
                Vector3 positionToInstantiate = new Vector3(transform.position.x, transform.position.y, -8f);
                GameObject go = Instantiate(star, positionToInstantiate + Vector3.up * Random.Range(0, 1) + Vector3.left * Random.Range(-1, 1), star.transform.rotation);
                Destroy(go, 7);
            }
        }
    }
}
