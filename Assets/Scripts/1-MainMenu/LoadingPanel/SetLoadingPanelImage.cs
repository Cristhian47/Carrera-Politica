using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetLoadingPanelImage : MonoBehaviour
{
    private Image loadingImage;

    public Sprite[] images;

    private void Awake()
    {
        loadingImage = GetComponent<Image>();
    }

    private void OnEnable()
    {
        loadingImage.sprite = images[Random.Range(0,images.Length)];
    }
}
