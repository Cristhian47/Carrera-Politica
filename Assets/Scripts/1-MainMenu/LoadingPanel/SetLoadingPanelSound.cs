using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetLoadingPanelSound : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip[] sounds;

    private void Awake() {

        audioSource = GetComponent<AudioSource>();

    }

    private void OnEnable() {

        audioSource.clip = sounds[Random.Range(0, sounds.Length)];
        audioSource.Play();

    }
}
