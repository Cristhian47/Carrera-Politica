using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSoundSetActive : MonoBehaviour
{
    public static MainSoundSetActive instance;

    private void Awake()
    {
        if (MainSoundSetActive.instance == null)
        {
            MainSoundSetActive.instance = this;
            GameManager.instance.soundObject = this.gameObject;
        }
        else if (MainSoundSetActive.instance != null)
        {
            Destroy(gameObject);
        }

    }
}
