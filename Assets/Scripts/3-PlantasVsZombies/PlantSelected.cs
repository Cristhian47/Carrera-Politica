using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlantSelected : MonoBehaviour
{
    private bool wasPressed;
    //private int numberOfPlantsSelected = 0;
    //private int currentIndex = 0;

    //public int maximumPlantsToPlant;
    //public List<Plants> plantsToUse;
    public Plants plant;

    public void SelectPlant(int plantNumber)
    {
        if (!wasPressed)
        {
            if (PlantsVsZombiesManager.instance.numberOfPlantsSelected < PlantsVsZombiesManager.instance.maximumPlantsToPlay)
            {
                //PlantsVsZombiesManager.instance.plantsToUse[PlantsVsZombiesManager.instance.indexUsed] = plant;
                PlantsVsZombiesManager.instance.plantsToUse.Add(plant);
                PlantsVsZombiesManager.instance.numberOfPlantsSelected++;
                PlantsVsZombiesManager.instance.indexUsed++;
                //numberOfPlantsSelected++;

                gameObject.GetComponent<Image>().color = Color.gray;
                wasPressed = true;
            }
        }
        else if (wasPressed)
        {
            PlantsVsZombiesManager.instance.plantsToUse.Remove(plant);
            PlantsVsZombiesManager.instance.numberOfPlantsSelected--;
            PlantsVsZombiesManager.instance.indexUsed--;
            gameObject.GetComponent<Image>().color = Color.white;
            wasPressed = false;
        }
    }
}
