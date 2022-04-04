using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockWorlds : MonoBehaviour
{
    public int world;
    public int game;

    public Sprite levelUnlockedSprite;
    public Sprite levelLockedSprite;
    

    private void OnEnable(){
        if(game == 1){

            if(world == 2){

                if(GameManager.instance.data.haveWorldTwoGameOne){
                    GetComponent<Button>().enabled = true;
                    GetComponent<Image>().sprite = levelUnlockedSprite;
                    transform.parent.GetChild(1).gameObject.SetActive(false);
                }else{
                    GetComponent<Button>().enabled = false;
                    GetComponent<Image>().sprite = levelLockedSprite;
                }

            }else if(world == 3){

                if(GameManager.instance.data.haveWorldThreeGameOne){
                    GetComponent<Button>().enabled = true;
                    GetComponent<Image>().sprite = levelUnlockedSprite;
                    transform.parent.GetChild(1).gameObject.SetActive(false);
                }
                else{
                    GetComponent<Button>().enabled = false;
                    GetComponent<Image>().sprite = levelLockedSprite;
                }

            }

        }else if(game == 2){

            if(world == 2){

                if(GameManager.instance.data.haveWorldTwoGameTwo){
                    GetComponent<Button>().enabled = true;
                    GetComponent<Image>().sprite = levelUnlockedSprite;
                    transform.parent.GetChild(1).gameObject.SetActive(false);
                }
                else{
                    GetComponent<Button>().enabled = false;
                    GetComponent<Image>().sprite = levelLockedSprite;
                }

            }else if(world == 3){

                if(GameManager.instance.data.haveWorldThreeGameTwo){
                    GetComponent<Button>().enabled = true;
                    GetComponent<Image>().sprite = levelUnlockedSprite;
                    transform.parent.GetChild(1).gameObject.SetActive(false);
                }
                else{
                    GetComponent<Button>().enabled = false;
                    GetComponent<Image>().sprite = levelLockedSprite;
                }
                
            }

        }
    }
}
