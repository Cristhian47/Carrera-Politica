using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSetActive : MonoBehaviour
{


    private void Awake()
    {
        
        
        gameObject.SetActive(GameManager.instance.data.musicIsActive);
    }
}
