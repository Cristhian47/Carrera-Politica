using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UnlockLevel : MonoBehaviour
{
    private int levelsToUnlock;

    public int numberOfWorld;
    public int numberOfGame;
    public string nameOfSceneToCreate;

    private void WorldOne()
    {
        if(numberOfGame == 1)
        {
            levelsToUnlock = GameManager.instance.data.levelsUnlockedWorldOneGameOne;
        }
        else if(numberOfGame == 2)
        {
            levelsToUnlock = GameManager.instance.data.levelsUnlockedWorldOneGameTwo;
        }
        else if(numberOfGame == 3)
        {
            levelsToUnlock = GameManager.instance.data.levelsUnlockedWorldOneGameThree;
        }
        else if(numberOfGame == 4)
        {
            levelsToUnlock = GameManager.instance.data.levelsUnlockedWorldOneGameFour;
        }
    }

    private void WorldTwo()
    {
        if (numberOfGame == 1)
        {
            levelsToUnlock = GameManager.instance.data.levelsUnlockedWorldTwoGameOne;
        }
        else if (numberOfGame == 2)
        {
            levelsToUnlock = GameManager.instance.data.levelsUnlockedWorldTwoGameTwo;
        }
        else if (numberOfGame == 3)
        {
            levelsToUnlock = GameManager.instance.data.levelsUnlockedWorldTwoGameThree;
        }
        else if (numberOfGame == 4)
        {
            levelsToUnlock = GameManager.instance.data.levelsUnlockedWorldTwoGameFour;
        }
    }

    private void WorldThree()
    {
        if (numberOfGame == 1)
        {
            levelsToUnlock = GameManager.instance.data.levelsUnlockedWorldThreeGameOne;
        }
        else if (numberOfGame == 2)
        {
            levelsToUnlock = GameManager.instance.data.levelsUnlockedWorldThreeGameTwo;
        }
        else if (numberOfGame == 3)
        {
            levelsToUnlock = GameManager.instance.data.levelsUnlockedWorldThreeGameThree;
        }
        else if (numberOfGame == 4)
        {
            levelsToUnlock = GameManager.instance.data.levelsUnlockedWorldThreeGameFour;
        }
    }

    private void WorldFour()
    {
        if (numberOfGame == 1)
        {
            levelsToUnlock = GameManager.instance.data.levelsUnlockedWorldFourGameOne;
        }
        else if (numberOfGame == 2)
        {
            levelsToUnlock = GameManager.instance.data.levelsUnlockedWorldFourGameTwo;
        }
        else if (numberOfGame == 3)
        {
            levelsToUnlock = GameManager.instance.data.levelsUnlockedWorldFourGameThree;
        }
        else if (numberOfGame == 4)
        {
            levelsToUnlock = GameManager.instance.data.levelsUnlockedWorldFourGameFour;
        }
    }

    private void OnEnable()
    {
        if (numberOfWorld == 1)
        {
            WorldOne();
        }
        else if (numberOfWorld == 2)
        {
            WorldTwo();
        }
        else if (numberOfWorld == 3)
        {
            WorldThree();
        }
        else if (numberOfWorld == 4)
        {
            WorldFour();
        }

        GameManager.instance.LockAndUnlock(levelsToUnlock, transform);
    }

    //-----------------NIVELES A INICIAR------------------------
    
    public void StartInfiniteLevel()
    {
        //GameManager.instance.levelName = gameObject.name;//TERMINAR
        //GameObject.FindGameObjectWithTag("NextChallenges").AddComponent<Challenges>().

        StartCoroutine(ChargeScene());
        //DontDestroyOnLoad(GetComponentInParent<Canvas>().gameObject);
        //GameManager.instance.levelObject = GameObject.Find(GameManager.instance.levelName);
        //GetComponentInParent<Canvas>().gameObject.SetActive(false);

    }

    private IEnumerator ChargeScene()
    {
        GameManager.instance.SetSound(false);
        AsyncOperation scene = SceneManager.LoadSceneAsync(nameOfSceneToCreate);
        GameManager.instance.loadingCanvas.SetActive(true);
        GameManager.instance.isChargingScene = true;


        while (!scene.isDone)
            yield return null;

        Debug.Log("Si entra???");
        GameManager.instance.isChargingScene = false;
        if (GameManager.instance.CanvasMainMenu.activeInHierarchy)
            GameManager.instance.CanvasMainMenu.SetActive(false);
        GameManager.instance.loadingCanvas.SetActive(false);
    }
}
