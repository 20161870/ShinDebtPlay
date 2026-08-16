using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    //Administración General
    public static int MONEY;
    public static int COUNTDINERO = 0;
    public static int Debt;
    public static int DAYS;
    public static int DAYSBY = 1;
    public int AHORRO;
    public int rng;

    //Hijo Menor
    public static int UpgradedCut= 0;
    public static int UpgradedTime = 0;
    public static bool UpgradedSpecial = false;
    public static int UpgradedCutMayor= 0;
    public static int UpgradedTimeMayor= 0;
    public static bool UpgradedSpecialMayor = false;
    public static int UpgradedCutMadre= 0;
    public static int UpgradedTimeMadre= 0;
    public static bool UpgradedSpecialMadre = false;
    public static int UpgradedCutPadre= 0;
    public static int UpgradedTimePadre= 0;
    public static bool UpgradedSpecialPadre = false;

    void Start()
    {
        Debt = COINCOUNT.countDeuda;
    }

    void Update()
    {
        Debt = COINCOUNT.countDeuda;
    }

    public void ExitGame()
    {
        //Pago de ahorro
        AHORRO = (int)(COINCOUNT.countAhorro * (1+(0.01*DAYS)));
        COINCOUNT.countAhorro = 0;
        Debug.Log("El bono es: " + AHORRO);

        //Aumento de variables
        DAYSBY = DAYSBY + DAYS;
        COUNTDINERO = COUNTDINERO + MONEY + AHORRO;
        
        //Evento aleatorio
        rng = Random.Range(1, 11);
        Debug.Log("Valor RNG: " + rng);
        if(rng >= 8) //Default: 8
        {
            RandomEvents.flag = true;
            RandomEvents.rngEvent = Random.Range(1, 21); //ultimo numero es el tamaño total del eventdatabase+1
            RandomEvents.popupEvent = true;
        }

        //Comprobación de ultimo dia
        if (DAYSBY >= 30)
        {
            SceneManager.LoadScene("MoneyManagement");
        }
        else
        {
            SceneManager.LoadScene("MainScreen");
        }
        Debug.Log("Dia: " + DAYSBY);
    }
}