using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkySunSpawner : MonoBehaviour
{
    public float timeBetweenSpawns;
    public Transform[] spawnPoints;
    public GameObject sunPrefab;

    //Se inicia el generador de soles al instanciar el objeto
    private IEnumerator Start() {

        while (true) {

            yield return new WaitForSeconds(timeBetweenSpawns);
            int index = 0;

            index = Random.Range(0, spawnPoints.Length);
            Vector3 instancePoint = new Vector3(spawnPoints[index].position.x, spawnPoints[index].position.y * 2, spawnPoints[index].position.z);

            GameObject go = Instantiate(sunPrefab, instancePoint, Quaternion.identity);

            Destroy(go, 7);
        }
        
    }
}
