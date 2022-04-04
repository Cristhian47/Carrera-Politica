using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextWithTeam : MonoBehaviour
{
    public GameObject TeamPanel;
    public GameObject challengeDescription;
    public GameObject loseCanvas;
    public GameObject alertPanel;
    public PlantsVsZombiesManager gameManager;

    private void Awake()
    {
        Time.timeScale = 0;
        gameManager.enabled = false;
    }

    public void SeeDescription()
    {
        if (PlantsVsZombiesManager.instance.plantsToUse.Count > 1){
            TeamPanel.SetActive(false);
            challengeDescription.SetActive(true);
        }
        else
        {
            alertPanel.SetActive(true);
            //alertPanel.GetComponent<Animator>().SetBool("isOpening", true);
        }
    }

    public void StartGame()
    {
        
        Time.timeScale = 1;
        gameManager.enabled = true;
        challengeDescription.SetActive(false);
        PlantsVsZombiesManager.instance.AssignCard();
    }
}
