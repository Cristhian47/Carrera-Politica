using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShareButton : MonoBehaviour
{
    private void OnEnable()
    {
        if (GameManager.instance.data.timesShared >= 1)
        {
            GetComponent<Button>().interactable = false;
        }
        else
        {
            GetComponent<Button>().interactable = true;
        }
    }

    public void DisableButton()
    {
        GetComponent<Button>().interactable = false;
    }
}
