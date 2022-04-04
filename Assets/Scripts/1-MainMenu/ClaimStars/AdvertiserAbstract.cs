using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AdvertiserAbstract
{


    public AdvertiserAbstract() {

    }

    abstract public void FetchAd();
    abstract public void ShowAd();
    abstract public bool IsReady();


}
