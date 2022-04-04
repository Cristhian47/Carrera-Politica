using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockClothes : MonoBehaviour
{
    public bool haveHat;
    private void Start()
    {
        for(int i = 0; i < GameManager.instance.clothesUsed.Length; i++)
        {
            if (GameManager.instance.clothesUsed[i])
                if(transform.GetChild(i) != null)
                {
                    if(haveHat && i < 3)
                        transform.GetChild(i).gameObject.SetActive(false);
                    else
                        transform.GetChild(i).gameObject.SetActive(true);
                }
                    
        }
    }
}
