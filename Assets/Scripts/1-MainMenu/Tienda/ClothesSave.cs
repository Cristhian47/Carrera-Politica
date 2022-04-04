using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothesSave : MonoBehaviour
{
    public StoreItem[] ClothesScripts;

    //Habilita las prendas de ropa al iniciar el juego
    //Esto es para la ropa que ha sido equipada en una partida anterior
    private void Start()
    {
        InitializeClothes();
    }

    public void InitializeClothes()
    {
        for (int i = 0; i < ClothesScripts.Length; i++)
        {

            ClothesScripts[i].StartUsedClothes();
        }
    }

    public void RestartClothes()
    {
        for(int i = 0; i < ClothesScripts.Length; i++)
        {
            ClothesScripts[i].RestartUsedClothes(i);
        }
    }
}
