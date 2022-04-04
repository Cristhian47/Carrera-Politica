using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    public PlantsVsZombiesManager gameManager;
    public GameObject pausePanel;
    public GameObject loseCanvas;
    public Text heartsText;
    //public GameObject mainMenuCanvas;
    public string sceneToReload = "PlantsVsZombiesInfinite";

    [Space(20)]

    public GameObject pruners;

    private void Awake()
    {
        DeleteStars();
        DeletePigs();
    }

    public void PauseGame()
    {
        if (GameManager.instance.data.firstGameScore < PlantsVsZombiesManager.instance.currentTime)
        {
            GameManager.instance.data.firstGameScore = PlantsVsZombiesManager.instance.currentTime;
        }
        PlantsVsZombiesManager.instance.soundManager.SetActive(false);
        Time.timeScale = 0;
        PlantsVsZombiesManager.instance.cardsIsAsigned = false;
        gameManager.enabled = false;
        pausePanel.SetActive(true);
    }

    public void ReturnGame()
    {
        if (GameManager.instance.data.firstGameScore < PlantsVsZombiesManager.instance.currentTime)
        {
            GameManager.instance.data.firstGameScore = PlantsVsZombiesManager.instance.currentTime;
        }
        PlantsVsZombiesManager.instance.soundManager.SetActive(true);
        Time.timeScale = 1;
        PlantsVsZombiesManager.instance.cardsIsAsigned = true;
        GameManager.instance.levelObject.SetActive(false);
        gameManager.enabled = true;
        pausePanel.SetActive(false);
    }

    public void RestartGame()
    {
        if (GameManager.instance.data.firstGameScore < PlantsVsZombiesManager.instance.currentTime)
        {
            GameManager.instance.data.firstGameScore = PlantsVsZombiesManager.instance.currentTime;
        }

        Time.timeScale = 1;
        GameManager.instance.levelObject.SetActive(true);
        GameManager.instance.SaveChanges();
        DeleteStars();
        DeletePigs();
        SceneManager.LoadScene(sceneToReload);
    }

    private void DeleteStars()
    {
        GameObject[] stars = GameObject.FindGameObjectsWithTag("Star");

        for(int i = 0; i < stars.Length; i++)
        {
            Destroy(stars[i]);
        }
    }

    private void DeletePigs()
    {
        GameObject[] pigs = GameObject.FindGameObjectsWithTag("Pig");

        for (int i = 0; i < pigs.Length; i++)
        {
            Destroy(pigs[i]);
        }
    }

    public void ReturnMainMenu()
    {
        if (GameManager.instance.data.firstGameScore < PlantsVsZombiesManager.instance.currentTime)
        {
            GameManager.instance.data.firstGameScore = PlantsVsZombiesManager.instance.currentTime;
        }

        Time.timeScale = 1;
        PlantsVsZombiesManager.instance.cardsIsAsigned = true;
        gameManager.enabled = true;
        GameManager.instance.levelObject.SetActive(true);
        GameManager.instance.SaveChanges();
        GameManager.instance.ActualizeData();
        
        //GameManager.instance.levelObject.GetComponentInParent<Canvas>().gameObject.SetActive(true);
        StartCoroutine(ChargeMainScene());
        GameManager.instance.loadingCanvas.SetActive(false);
    }

    public void ContinueGame()
    {
        if (GameManager.instance.data.firstGameScore < PlantsVsZombiesManager.instance.currentTime)
        {
            GameManager.instance.data.firstGameScore = PlantsVsZombiesManager.instance.currentTime;
        }

        if (GameManager.instance.data.hearts > 0)
        {
            PlantsVsZombiesManager.instance.soundManager.SetActive(true);
            GameObject[] zombies = GameObject.FindGameObjectsWithTag("Zombie");
            for (int i = 0; i < zombies.Length; i++)
            {

                zombies[i].GetComponent<Animator>().SetBool("isDie", true);
                Destroy(zombies[i], 3);
            }

            for(int i = 0; i < pruners.transform.childCount; i++)
            {
                pruners.transform.GetChild(i).gameObject.SetActive(true);
            }
            GameManager.instance.data.hearts--;
            GameManager.instance.data.heartsUsed++;
            heartsText.text = (GameManager.instance.data.hearts).ToString();

            GameManager.instance.ActualizeData();
            Time.timeScale = 1;
            PlantsVsZombiesManager.instance.cardsIsAsigned = true;
            loseCanvas.SetActive(false);
            
        }
        PlantsVsZombiesManager.instance.pausePanel.SetActive(false);
    }

    public void ClaimReward()
    {
        if (GameManager.instance.data.firstGameScore < PlantsVsZombiesManager.instance.currentTime)
        {
            GameManager.instance.data.firstGameScore = PlantsVsZombiesManager.instance.currentTime;
        }

        GameManager.instance.data.stars += PlantsVsZombiesManager.instance.starsReward;
        GameManager.instance.data.starsObtained += PlantsVsZombiesManager.instance.starsReward;
        GameManager.instance.SaveChanges();

        if(PlantsVsZombiesManager.instance.currentWorld == 1 && GameManager.instance.data.levelsUnlockedWorldOneGameOne < PlantsVsZombiesManager.instance.currentLevel + 1)
            GameManager.instance.data.levelsUnlockedWorldOneGameOne = PlantsVsZombiesManager.instance.currentLevel + 1;
        if(PlantsVsZombiesManager.instance.currentWorld == 2 && GameManager.instance.data.levelsUnlockedWorldTwoGameOne < PlantsVsZombiesManager.instance.currentLevel + 1)
            GameManager.instance.data.levelsUnlockedWorldTwoGameOne = PlantsVsZombiesManager.instance.currentLevel + 1;
        if (PlantsVsZombiesManager.instance.currentWorld == 3 && GameManager.instance.data.levelsUnlockedWorldThreeGameOne < PlantsVsZombiesManager.instance.currentLevel + 1)
            GameManager.instance.data.levelsUnlockedWorldThreeGameOne = PlantsVsZombiesManager.instance.currentLevel + 1;
        if (PlantsVsZombiesManager.instance.currentWorld == 4 && GameManager.instance.data.levelsUnlockedWorldFourGameOne < PlantsVsZombiesManager.instance.currentLevel + 1)
            GameManager.instance.data.levelsUnlockedWorldFourGameOne = PlantsVsZombiesManager.instance.currentLevel + 1;

        //Muestra publicidad
        /*if(AdManager.instance.isReady[1])
            AdManager.instance.ShowRewardedAd();*/

        Time.timeScale = 1;
        GameManager.instance.levelObject.SetActive(true);
        GameManager.instance.ActualizeData();
        StartCoroutine(GameManager.instance.ChargeMainScene());
        //SceneManager.LoadScene("1-MainMenu");
        GameManager.instance.loadingCanvas.SetActive(false);
    }

    private IEnumerator ChargeMainScene()
    {
        AsyncOperation scene = SceneManager.LoadSceneAsync("1-MainMenu");
        GameManager.instance.loadingCanvas.SetActive(true);
        GameManager.instance.isChargingScene = true;

        while (!scene.isDone)
            yield return null;

        GameManager.instance.isChargingScene = false;
        GameManager.instance.loadingCanvas.SetActive(false);
        GameManager.instance.SetSound(true);
        
    }
}
