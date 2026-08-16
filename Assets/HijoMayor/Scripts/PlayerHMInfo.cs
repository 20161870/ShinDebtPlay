using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using System;
using System.Data.Common;
public class PlayerHMInfo : MonoBehaviour
{
    private TMP_Text TScore;
    private TMP_Text TDif;
    private TMP_Text TVidas;
    public static GameObject EndScreen;
    public static int Puntaje;
    public static int Dificultad = 1;
    public static int NumVida;
    public static float CashOut;
    public static float Multiplier=1.0f;
    [SerializeField] TMP_Text loseText;
    [SerializeField] UnityEngine.UI.Button Exit; 

    // Start is called before the first frame update
    void Start()
    {
        Puntaje=0;
        NumVida = 5 + GameManager.UpgradedTimeMayor;
        TScore = GameObject.Find("Score").GetComponent<TMP_Text>();
        TDif = GameObject.Find("Dif").GetComponent<TMP_Text>();
        TVidas = GameObject.Find("Life").GetComponent<TMP_Text>();
        UpdateInfo();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateInfo();
        AdaptDificulty();
        if(NumVida <= 0){
            NumVida = 0;
            loseText.gameObject.SetActive(true);
            Exit.gameObject.SetActive(true);
            FindObjectOfType<BlocController>().ClearActiveBlocks();
            FindObjectOfType<BlocController>().StopSpawnBlocks();
            Payout();
        }
        
        
    }

    void UpdateInfo()
    {
        TScore.text = "Tu puntaje: " + Puntaje;
        TDif.text = "Dificultad: " + Dificultad;
        TVidas.text = "Vidas restantes: " + NumVida;
    }

//End Rewards 
    public static void Payout(){
                CashOut = Puntaje * Multiplier;
                Debug.Log("Total pay: " + CashOut);
                GameManager.MONEY = (int)CashOut;
                GameManager.DAYS =2;
    }

    public static void AdaptDificulty()
    {
        // Con mejora activada
        if (GameManager.UpgradedSpecialMayor)
        {
            if (CalulatorController.CorrectAnswer >= 16)
            {
                Dificultad = 3;
                Multiplier = 1.65f;
            }
            else if (CalulatorController.CorrectAnswer >= 8)
            {
                Dificultad = 2;
                Multiplier = 1.3f;
            }
            else
            {
                Dificultad = 1;
                Multiplier = 1.10f;
            }
        }
        // Sin mejora
        else
        {
            if (CalulatorController.CorrectAnswer > 16)
            {
                Dificultad = 3;
                Multiplier = 1.4f;
            }
            else if (CalulatorController.CorrectAnswer >= 8)
            {
                Dificultad = 2;
                Multiplier = 1.25f;
            }
            else
            {
                Dificultad = 1;
                Multiplier = 1f;
            }
        }
    }
}
