using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlying : MonoBehaviour
{
    private bool isDead = false;
    private Rigidbody2D playerRigidbody;

    public float jumpForce = 200f;

    private void Awake() {

        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision) {

        isDead = true;
        FlappyGameController.instance.PlayerDie();
    }

    private void Update() {

        if(!isDead && Input.GetMouseButtonDown(0)) {
            playerRigidbody.velocity = Vector2.zero;
            playerRigidbody.AddForce(Vector2.up * jumpForce);
            
        }
    }

}
