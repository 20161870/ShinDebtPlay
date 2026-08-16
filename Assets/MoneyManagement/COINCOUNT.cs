using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class COINCOUNT : MonoBehaviour
{
   // public static float countAhorro;
    public static int countDeuda = 1500;
    public static int countAhorro = 0;
    public Button InputUser;
    //Variable para instanciar y mover dinero 
    private int Transaction;
    // variables para los cuadros de texto
    public static TMP_Text TextDineroT;
    public static TMP_Text TextDeuda;
    public static TMP_Text TextAhorro;
    public TMP_Text TextSpeed;
    public TMP_Text TextTime;
    public TMP_Text TextSpecial;
    public TMP_InputField inputTxt;
    public TMP_InputField inputTxtAhorro;

    //Variables para Mejoras
    public static int MaxSpeed = 1;
    public static int MaxTime = 5;
    public static  bool LowPenalty = false;

    
    void Start()
    {
        TextDineroT = GameObject.Find("DineroT").GetComponent<TMP_Text>();
        TextDeuda = GameObject.Find("deuda").GetComponent<TMP_Text>();
        TextAhorro = GameObject.Find("ahorro").GetComponent<TMP_Text>();
        UpdateAccounts();       
    }   

    void Update(){
        UpdateAccounts(); 
    }

    public static void UpdateAccounts(){
        TextDeuda.text = "  " + countDeuda;
        TextAhorro.text = "  " + countAhorro;
        //cambiar eventualmente por eventos random
        TextDineroT.text = "  " +  GameManager.COUNTDINERO;
    }

    //PAGAR DEUDA
    public void PayDebt() 
    {
        GameManager.COUNTDINERO = int.Parse(TextDineroT.text);
        Transaction = int.Parse(inputTxt.text);
        if(GameManager.COUNTDINERO > 0){
            GameManager.COUNTDINERO -= Transaction;
            countDeuda -= Transaction;
        }

        if(GameManager.COUNTDINERO < 0){
            GameManager.COUNTDINERO = 0;
            countDeuda -= Transaction;
            if(countDeuda < 0){
            countDeuda = 0;
            Debug.Log("Deuda completa");
            }
        }
        if(GameManager.COUNTDINERO == 0){
            Debug.Log("No hay más fondos");
        }
        UpdateAccounts();
    }

    //AHORRO
    public void PaySaving() 
    {
        GameManager.COUNTDINERO = int.Parse(TextDineroT.text);
        Transaction = int.Parse(inputTxtAhorro.text);
        if(GameManager.COUNTDINERO > 0){
            GameManager.COUNTDINERO -= Transaction;
            countAhorro += Transaction;
        }

        if(GameManager.COUNTDINERO < 0){
            GameManager.COUNTDINERO = 0;
            if(countAhorro < 0){
            countAhorro = 0;
            }
        }
        if(GameManager.COUNTDINERO == 0){
            Debug.Log("No hay más fondos");
        }
        Debug.Log(countAhorro);
        UpdateAccounts();
    }

    // ------------------------------------------------------BOTON SPEED--------------------------------------------------//
    public void UpgradeSpeedPadre()
    {
        TextSpeed = GameObject.Find("SPEED").GetComponent<TMP_Text>();
        int costoC = 150;
        if(GameManager.COUNTDINERO >= costoC){
            if(GameManager.UpgradedCutPadre < MaxSpeed){
                GameManager.UpgradedCutPadre += 1;
                GameManager.COUNTDINERO -= costoC;
                Debug.Log(GameManager.COUNTDINERO);
                UpdateAccounts();
            }
        
            if (GameManager.UpgradedCutPadre >= MaxSpeed){
                Debug.Log("Mejora al Máximo");
                TextSpeed.text = "Nivel Máximo";
            }   

        }
        else{
            Debug.Log("No tienes dinero suficiente");
        }
        UpdateAccounts();
    }
    public void UpgradeSpeedMadre()
    {
        TextSpeed = GameObject.Find("SPEED").GetComponent<TMP_Text>();
        int costoC = 150;
        if(GameManager.COUNTDINERO >= costoC){
            if(GameManager.UpgradedCutMadre < MaxSpeed){
                GameManager.UpgradedCutMadre += 50;
                GameManager.COUNTDINERO -= costoC;
                Debug.Log(GameManager.COUNTDINERO);
                UpdateAccounts();
            }
        
            if (GameManager.UpgradedCut >= MaxSpeed){
                Debug.Log("Mejora al Máximo");
                TextSpeed.text = "Nivel Máximo";
            }   

        }
        else{
            Debug.Log("No tienes dinero suficiente");
        }
        UpdateAccounts();
    }
    //Más puntaje por bloque
     public void UpgradeSpeedMayor()
    {
        TextSpeed = GameObject.Find("SPEED").GetComponent<TMP_Text>();
        int costoC = 150;
        if(GameManager.COUNTDINERO >= costoC){
            if(GameManager.UpgradedCutMayor < MaxSpeed){
                GameManager.UpgradedCutMayor += 5;
                GameManager.COUNTDINERO -= costoC;
                Debug.Log(GameManager.COUNTDINERO);
                UpdateAccounts();
            }
        
            if (GameManager.UpgradedCutMayor >= MaxSpeed){
                Debug.Log("Mejora al Máximo");
                TextSpeed.text = "Nivel Máximo";
            }   

        }
        else{
            Debug.Log("No tienes dinero suficiente");
        }
        UpdateAccounts();
    }
    
    public void UpgradeSpeedMenor()
    {
        TextSpeed = GameObject.Find("SPEED").GetComponent<TMP_Text>();
        int costoC = 150;
        if(GameManager.COUNTDINERO >= costoC){
            if(GameManager.UpgradedCut < MaxSpeed){
                GameManager.UpgradedCut += 2;
                GameManager.COUNTDINERO -= costoC;
                Debug.Log(GameManager.COUNTDINERO);
                UpdateAccounts();
            }
        
            if (GameManager.UpgradedCut >= MaxSpeed){
                Debug.Log("Mejora al Máximo");
                TextSpeed.text = "Nivel Máximo";
            }   

        }
        else{
            Debug.Log("No tienes dinero suficiente");
        }
        UpdateAccounts();
    }
    // ------------------------------------------------------BOTON TIEMPO--------------------------------------------------// 
    public void UpgradeTimePadre()
    {
        TextTime = GameObject.Find("TIME").GetComponent<TMP_Text>();
        int costoT = 250;
        if(GameManager.COUNTDINERO >= costoT){
            if(GameManager.UpgradedTimePadre < MaxTime){
                GameManager.UpgradedTimePadre+=60;
                GameManager.COUNTDINERO -= costoT;
                Debug.Log(GameManager.COUNTDINERO);
                UpdateAccounts();
            }   
            if (GameManager.UpgradedTimePadre >= MaxTime){
                Debug.Log("Mejora al Máximo");
            }
        }
        else{
            Debug.Log("No tienes dinero suficiente");
        }
        UpdateAccounts();
    }
    public void UpgradeTimeMadre()
    {
        TextTime = GameObject.Find("TIME").GetComponent<TMP_Text>();
        int costoT = 250;
        if(GameManager.COUNTDINERO >= costoT){
            if(GameManager.UpgradedTimeMadre < MaxTime){
                GameManager.UpgradedTimeMadre+=300;
                GameManager.COUNTDINERO -= costoT;
                Debug.Log(GameManager.COUNTDINERO);
                UpdateAccounts();
            }   
            if (GameManager.UpgradedTimeMadre >= MaxTime){
                Debug.Log("Mejora al Máximo");
            }
        }
        else{
            Debug.Log("No tienes dinero suficiente");
        }
        UpdateAccounts();
    }
    //vidas extra
    public void UpgradeTimeMayor()
    {
        TextTime = GameObject.Find("TIME").GetComponent<TMP_Text>();
        int costoT = 250;
        if(GameManager.COUNTDINERO >= costoT){
            if(GameManager.UpgradedTimeMayor < MaxTime+3){
                GameManager.UpgradedTimeMayor+=2;
                GameManager.COUNTDINERO -= costoT;
                Debug.Log(GameManager.COUNTDINERO);
                UpdateAccounts();
            }   
            if (GameManager.UpgradedTimeMayor >= MaxTime){
                Debug.Log("Mejora al Máximo");
            }
        }
        else{
            Debug.Log("No tienes dinero suficiente");
        }
        UpdateAccounts();
    }
    public void UpgradeTimeMenor()
    {
        TextTime = GameObject.Find("TIME").GetComponent<TMP_Text>();
        int costoT = 250;
        if(GameManager.COUNTDINERO >= costoT){
            if(GameManager.UpgradedTime < MaxTime){
                GameManager.UpgradedTime+=5;
                GameManager.COUNTDINERO -= costoT;
                Debug.Log(GameManager.COUNTDINERO);
                UpdateAccounts();
            }   
            if (GameManager.UpgradedTime >= MaxTime){
                Debug.Log("Mejora al Máximo");
            }
        }
        else{
            Debug.Log("No tienes dinero suficiente");
        }
        UpdateAccounts();
    }
    

    // ------------------------------------------------------BOTON ESPECIAL--------------------------------------------------// 

    public void UpgradeSpecialPadre()
    {
        TextSpecial = GameObject.Find("SPECIAL").GetComponent<TMP_Text>();
        int costoS = 400;
            if(GameManager.COUNTDINERO >= costoS){
                if(GameManager.UpgradedSpecialPadre == false){
                    GameManager.UpgradedSpecialPadre = true;
                    DebtCheck.vida++;
                    GameManager.COUNTDINERO -= costoS;
                    Debug.Log(GameManager.COUNTDINERO);
                }
            }
        
        UpdateAccounts();
    }

    public void UpgradeSpecialMadre()
    {
        TextSpecial = GameObject.Find("SPECIAL").GetComponent<TMP_Text>();
        int costoS = 400;
            if(GameManager.COUNTDINERO >= costoS){
                if(GameManager.UpgradedSpecialMadre == false){
                    GameManager.UpgradedSpecialMadre = true;
                    GameManager.COUNTDINERO -= costoS;
                    Debug.Log(GameManager.COUNTDINERO);
                }
            }
        
        UpdateAccounts();
    }


    public void UpgradeSpecialMayor()
    {
        TextSpecial = GameObject.Find("SPECIAL").GetComponent<TMP_Text>();
        int costoS = 400;
            if(GameManager.COUNTDINERO >= costoS){
                if(GameManager.UpgradedSpecialMayor == false){
                    GameManager.UpgradedSpecialMayor = true;
                    GameManager.COUNTDINERO -= costoS;
                    Debug.Log(GameManager.COUNTDINERO);
                }
            }
        
        UpdateAccounts();
    }

    public void UpgradeSpecialMenor()
    {
        TextSpecial = GameObject.Find("SPECIAL").GetComponent<TMP_Text>();
        int costoS = 400;
            if(GameManager.COUNTDINERO >= costoS){
                if(GameManager.UpgradedSpecial == false){
                    GameManager.UpgradedSpecial = true;
                    GameManager.COUNTDINERO -= costoS;
                    Debug.Log(GameManager.COUNTDINERO);
                }
            }
        
        UpdateAccounts();
    }

    public void Back(){
        if (GameManager.DAYSBY > 30 || countDeuda <= 0)
        {
            SceneManager.LoadScene("EndScreen");
        }
        else{
            
            SceneManager.LoadScene("MainScreen");
            
        }
    }

}
