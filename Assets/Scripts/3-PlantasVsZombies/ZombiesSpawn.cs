using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;


[Serializable]
public class ZombiesSpawnList{
    public int index = 0;
    public int[] timesToSpawn;
    public int[] zombiesQuantityToSpawn;
}

public class ZombiesSpawn : MonoBehaviour
{
    private bool alreadySpawnHorde = false;

    public List<Zombie> zombiesToUse;
    public float spawnTime;

    //public ZombiesSpawnList zombiesSpawn;

    private int zombiesInHorde;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(5f);

        while (true)
        {
            yield return new WaitForSeconds(spawnTime);
            //transform.GetChild[Mathf.RoundToInt(Random.Range(0, 5))]
            //transform.GetChild(Random.Range(0, 4))

            int initialIndex = UnityEngine.Random.Range(0, 5);
            Vector3 initialPosition = new Vector3(transform.GetChild(initialIndex).position.x,
                transform.GetChild(initialIndex).position.y + 0.7f,
                transform.GetChild(initialIndex).position.z);

            int index = UnityEngine.Random.Range(0, zombiesToUse.Count);
            GameObject go = Instantiate(zombiesToUse[index], initialPosition
                , Quaternion.identity).gameObject;

            //go.tag = "Zombie";

            SpriteRenderer[] sprites = go.GetComponentsInChildren<SpriteRenderer>();

            foreach(SpriteRenderer sprite in sprites)
            {
                sprite.sortingLayerName = transform.GetChild(initialIndex).GetComponent<SpriteRenderer>().sortingLayerName;
            }

            go.layer = 8;
        }
    }

    private void Update()
    {
        HordeOfZombies();
        if(PlantsVsZombiesManager.instance.currentTime % 50 == 0){
            if (spawnTime < 6)
                spawnTime -= 2;
        }
    }

    /*private void HordeOfZombies()
    {
        if (PlantsVsZombiesManager.instance.currentTime == zombiesSpawn.timesToSpawn[zombiesSpawn.index] && !alreadySpawnHorde)
        {
            alreadySpawnHorde = true;
            zombiesInHorde = zombiesSpawn.zombiesQuantityToSpawn[zombiesSpawn.index];
            StartCoroutine(InstanceZombies());
        }
    }*/

    private void HordeOfZombies()
    {
        float currentTime = PlantsVsZombiesManager.instance.currentTime;
        //Cada 100 segundos
        if (currentTime % 100 == 0 && !alreadySpawnHorde)
        {

            alreadySpawnHorde = true;
            if (currentTime <= 100) {
                zombiesInHorde = Mathf.CeilToInt(currentTime*currentTime/910);
            }else if(currentTime > 100 && currentTime <= 300) {
                zombiesInHorde = Mathf.CeilToInt(0.7f*Mathf.Log(currentTime,(float)Math.E) * Mathf.Log(currentTime, (float)Math.E));
            }else if(currentTime > 300) {
                zombiesInHorde = Mathf.CeilToInt(currentTime * Mathf.Log10(currentTime) / 35);
            }

            StartCoroutine(InstanceZombies());
        }
    }

    private IEnumerator InstanceZombies()
    {
        for (int i = 0; i < zombiesInHorde; i++)
        {
            yield return new WaitForSeconds(1f);

            int indexSpawn = UnityEngine.Random.Range(0, 5);

            GameObject go = Instantiate(zombiesToUse[UnityEngine.Random.Range(0, zombiesToUse.Count)],
                    new Vector3(transform.GetChild(indexSpawn).position.x, transform.GetChild(indexSpawn).position.y + 0.7f,
                    transform.GetChild(indexSpawn).position.z)
                    , Quaternion.identity).gameObject;

            SpriteRenderer[] sprites = go.GetComponentsInChildren<SpriteRenderer>();

            foreach (SpriteRenderer sprite in sprites) {
                sprite.sortingLayerName = transform.GetChild(indexSpawn).GetComponent<SpriteRenderer>().sortingLayerName;
            }

            go.layer = 8;
            
        }
        alreadySpawnHorde = false;


    }
}
