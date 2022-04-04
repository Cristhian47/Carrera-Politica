using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlantsToSelect : MonoBehaviour
{
    private bool wasPressed;
    private int numberOfPlantsSelected = 0;
    //private int currentIndex = 0;

    public int maximumPlantsToPlant;
    public List<Plants> plantsToUse;

    public void SelectPlant(int plantNumber)
    {
        if(numberOfPlantsSelected < maximumPlantsToPlant)
        {
            if (!wasPressed)
            {
                if (plantNumber == 1)
                {
                    PlantsVsZombiesManager.instance.plantsToUse[plantNumber - 1] = plantsToUse[plantNumber - 1];
                    numberOfPlantsSelected++;
                }
                else if (plantNumber == 2)
                {

                }
                else if (plantNumber == 3)
                {

                }
                else if (plantNumber == 4)
                {

                }
                else if (plantNumber == 5)
                {

                }
                else if (plantNumber == 6)
                {

                }
                else if (plantNumber == 7)
                {

                }
                else if (plantNumber == 8)
                {

                }
                else if (plantNumber == 9)
                {

                }
                //gameObject.GetComponent<Image>().color = Color.blue;
                wasPressed = true;
            }
            else if (wasPressed)
            {
                if (plantNumber == 1)
                {
                    PlantsVsZombiesManager.instance.plantsToUse[plantNumber - 1] = null;
                    numberOfPlantsSelected--;
                }
                else if (plantNumber == 2)
                {

                }
                else if (plantNumber == 3)
                {

                }
                else if (plantNumber == 4)
                {

                }
                else if (plantNumber == 5)
                {

                }
                else if (plantNumber == 6)
                {

                }
                else if (plantNumber == 7)
                {

                }
                else if (plantNumber == 8)
                {

                }
                else if (plantNumber == 9)
                {

                }
                //gameObject.GetComponent<Image>().color = Color.white;
                wasPressed = false;
            }
        }
    }
}
