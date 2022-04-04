using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatFlappyBackground : MonoBehaviour
{
    private BoxCollider2D groundCollider;
    private float groundHorizontalLenght;

    private void Awake()
    {
        groundCollider = GetComponent<BoxCollider2D>();
    }

    private void Start()
    {
        groundHorizontalLenght = groundCollider.size.x + transform.localScale.x;
    }

    private void RepositionBackground()
    {
        transform.Translate(Vector2.right * groundHorizontalLenght * 2);
    }

    private void Update()
    {
        if(transform.position.x < -groundHorizontalLenght)
            RepositionBackground();
    }
}
