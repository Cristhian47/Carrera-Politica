using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertPanel : MonoBehaviour
{
    public void DesactivatePanel()
    {
        gameObject.SetActive(false);
        //GetComponent<Animator>().SetBool("isOpening", false);
    }
}
