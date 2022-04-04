using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanzaGuisantes : MonoBehaviour
{
    public float shootingTime = 1;
    public GameObject guisante;
    public Transform mouth;
    public int guisantesToGenerate = 1;
    public LayerMask zombieLayer;

    [Space(10)]
    public bool isPlantOfIce;
    public bool isPlantOfFire;

    [Space(20)]
    public GameObject frog;
    public GameObject deadParticles;


    private IEnumerator Start()
    {

        while (true)
        {
            yield return new WaitForSeconds(shootingTime);

            RaycastHit2D hit = Physics2D.Raycast(mouth.position, Vector3.right, 13f, zombieLayer);

            Debug.DrawRay(mouth.position, Vector3.right * 13);

            if(hit.collider != null)
            {
                for (int i = 0; i < guisantesToGenerate; i++)
                {
                    GetComponent<Animator>().SetBool("skillActive", true);
                    Invoke("InstantiateBullet", 0.45f);

                    if (guisantesToGenerate == 1)
                        yield return new WaitForSeconds(.95f);
                    else if (guisantesToGenerate == 2)
                        yield return new WaitForSeconds(0.3f);
                    
                }
            }
            GetComponent<Animator>().SetBool("skillActive", false);
        }
    }

    public void InstantiateBullet()
    {
        GameObject go = Instantiate(guisante, mouth.position, guisante.transform.rotation);
        if (isPlantOfIce)
            go.GetComponent<Guisante>().isOnIce = true;
        else if (isPlantOfFire)
            go.GetComponent<Guisante>().isOnFire = true;

        Destroy(go, 10);
    }

    public void InstanceCabalObjects() {

        GameObject gob = Instantiate(deadParticles, transform.position, Quaternion.identity);
        Destroy(gob, 3);
        GameObject go = Instantiate(frog, transform.position, Quaternion.identity);
        Destroy(go, 3);
    }
}
