using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollFlappyBackground : MonoBehaviour
{
    private Rigidbody2D rigidbody;

    private void Awake() {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start() {

        rigidbody.velocity = Vector2.left * FlappyGameController.instance.scrollSpeed;
    }

    private void Update() {


        if (FlappyGameController.instance.gameOver) {
            rigidbody.velocity = Vector2.zero;
        }
    }
}
