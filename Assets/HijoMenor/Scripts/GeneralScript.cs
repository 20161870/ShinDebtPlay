using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GeneralScript : MonoBehaviour
{
    public static int UpgradedTime;
    public static bool UpgradedSpecial;
    public int cont = 0; 
    public float porcentage;
    public float currentTime = 0f;
    public float startingTime = 10f;

    [SerializeField] TMP_Text countdownText;
    [SerializeField] TMP_Text porcentageText;
    [SerializeField] TMP_Text winText;
    [SerializeField] TMP_Text loseText;
    [SerializeField] Button exit; 

    void Start()
    {
        UpgradedTime = GameManager.UpgradedTime;
        currentTime = startingTime + UpgradedTime;
        UpgradedSpecial = COINCOUNT.LowPenalty;
    }

    
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        countdownText.text = currentTime.ToString("0");

        porcentage = (cont/298f) * 100f;
        porcentageText.text = porcentage.ToString("0") + "%";

        // WIN CONDITION - ENVIAR DINERO
        if(cont == 298){
            winText.gameObject.SetActive(true);
            exit.gameObject.SetActive(true);
            Time.timeScale = 0;
            GameManager.MONEY = 100;
            GameManager.DAYS =1;
        }

        // LOSE CONDITION - NO ENVIAR DINERO
        if(currentTime <= 0){
            currentTime = 0;
            loseText.gameObject.SetActive(true);
            exit.gameObject.SetActive(true);
            Time.timeScale = 0;
            GameManager.DAYS =1;

            if(GameManager.UpgradedSpecial == true){
                GameManager.MONEY = 25;
            }
            else{
                GameManager.MONEY = 0;
            }
        }
    }
}
