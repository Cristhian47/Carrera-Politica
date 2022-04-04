using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegisterState : MonoBehaviour
{
    private void Start() {
        if (GameManager.instance.data.wasRegistered) {
            gameObject.SetActive(false);
        }
    }
}
