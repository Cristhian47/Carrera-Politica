using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectsSetActive : MonoBehaviour
{
    private void Start()
    {

        AudioSource[] audioSources = GetComponents<AudioSource>();

        for(int i = 0; i < audioSources.Length; i++)
        {
            audioSources[i].enabled = GameManager.instance.data.effectsIsActive;
        }
    }
}
