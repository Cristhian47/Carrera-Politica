using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sunflower : MonoBehaviour
{
    public float sunsGeneratingTime = 1;
    public GameObject sun;
    public int sunsToGenerate = 1;

    private IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(sunsGeneratingTime);
            transform.GetChild(5).gameObject.SetActive(true);
            for(int i = 0; i < sunsToGenerate; i++)
            {
                GetComponent<Animator>().SetBool("generateSun", true);
                Vector3 positionToIntantiate = new Vector3(transform.position.x, transform.position.y, -0.5f);
                GameObject go = Instantiate(sun, positionToIntantiate + Vector3.up * Random.Range(0, 1) + Vector3.left * Random.Range(-1, 1), sun.transform.rotation);
                Destroy(go, 7);
                Invoke("DisableAnimation", 1.5f);
            }
        }
    }

    private void DisableAnimation() {

        GetComponent<Animator>().SetBool("generateSun", false);
        transform.GetChild(5).gameObject.SetActive(false);
    }
}
