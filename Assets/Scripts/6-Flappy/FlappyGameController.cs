using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlappyGameController : MonoBehaviour
{
    public GameObject dieCanvas;
    public bool gameOver;
    public float scrollSpeed = -1.5f;

    public static FlappyGameController instance;

    private void Awake() {

        if (FlappyGameController.instance == null)
            FlappyGameController.instance = this;
        else if (FlappyGameController.instance != null)
            Destroy(gameObject);
    }

    public void PlayerDie() {
        dieCanvas.SetActive(true);
        gameOver = true;
    }


    private void OnDestroy() {
        if (FlappyGameController.instance == this) {

            FlappyGameController.instance = null;
        }
    }

    public void Continue() {

    }

    public void RestartScene() {

        SceneManager.LoadScene("Flappy");
      
    }
}
