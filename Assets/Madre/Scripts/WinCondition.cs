using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

public class WinCondition : MonoBehaviour
{

    [SerializeField] TMP_Text winText;
    [SerializeField] TMP_Text loseText;
    [SerializeField] Button exit; 
    [SerializeField] Image card1;
    [SerializeField] Image card2;
    [SerializeField] Image card3;
    [SerializeField] GameObject results;
    [SerializeField] TMP_Text DineroTotalText;
    [SerializeField] TMP_Text GananciaText;
    public int DineroUniversal;
    public int GananciaUniversal;
    public int cont;

    [SerializeField] TMP_Text GanTotal;
    [SerializeField] TMP_Text DinTotal;
    [SerializeField] TMP_Text[] res;
    private string[] categories = {
        "Abarrote", "Conservas", "Lacteos", "Botanas", "Confiterias",
        "Harinas", "Frutas", "Vegetales", "Bebidas", "Instantaneos",
        "Higiene", "Domestico"
    };

    DisplayCard cardInstance1 = null;
    DisplayCard cardInstance2 = null;
    DisplayCard cardInstance3 = null;

    public List<(int, int, bool)> finalCards = new List<(int, int, bool)>();

    void Start(){
        cont = 0;

        GameObject fullcard1 = GameObject.Find("Card1");
        cardInstance1 = fullcard1.GetComponent<DisplayCard>();
        GameObject fullcard2 = GameObject.Find("Card2");
        cardInstance2 = fullcard2.GetComponent<DisplayCard>();
        GameObject fullcard3 = GameObject.Find("Card3");
        cardInstance3 = fullcard3.GetComponent<DisplayCard>();
    }
    void Update()
    {
        DineroUniversal = Convert.ToInt32(DineroTotalText.text);
        GananciaUniversal = Convert.ToInt32(GananciaText.text);
        DinTotal.text = DineroUniversal.ToString();
        GanTotal.text = GananciaUniversal.ToString();

        finalCards = cardInstance1.selectedCards
            .Union(cardInstance2.selectedCards)
            .Union(cardInstance3.selectedCards)
            .ToList();
        finalCards.Sort();

        for (int i = 0; i < finalCards.Count; i++)
        {
            var card = finalCards[i];

            if (card.Item3 == true && card.Item2 != 0)
            {
                res[i].color = Color.green;
                res[i].text = categories[i] + " - " + card.Item2.ToString() + " (VENDIDO)";
            }
            else
            {
                res[i].color = Color.red;
                res[i].text = categories[i] + " - " + card.Item2.ToString() + " (NO VENDIDO)";
            }
        }

        if (DineroUniversal <= 0)
        {
            card1.gameObject.SetActive(false);
            card2.gameObject.SetActive(false);
            card3.gameObject.SetActive(false);
            loseText.gameObject.SetActive(true);
            exit.gameObject.SetActive(true);
            results.gameObject.SetActive(true);
            DinTotal.color = Color.red;
            Time.timeScale = 0;
            GameManager.MONEY = 0;
            GameManager.DAYS = 4;
        } else
        {
            DinTotal.color = Color.green;
            if (finalCards.Count == 12)
            {
                if(GananciaUniversal >= 2000)
                {
                    card1.gameObject.SetActive(false);
                    card2.gameObject.SetActive(false);
                    card3.gameObject.SetActive(false);
                    winText.gameObject.SetActive(true);
                    exit.gameObject.SetActive(true);
                    results.gameObject.SetActive(true);
                    GanTotal.color = Color.green;
                    Time.timeScale = 0;
                    GameManager.MONEY = 400;
                    GameManager.DAYS = 4;
                } else
                {
                    card1.gameObject.SetActive(false);
                    card2.gameObject.SetActive(false);
                    card3.gameObject.SetActive(false);
                    loseText.gameObject.SetActive(true);
                    exit.gameObject.SetActive(true);
                    results.gameObject.SetActive(true);
                    GanTotal.color = Color.red;
                    Time.timeScale = 0;
                    GameManager.MONEY = 0;
                    GameManager.DAYS = 4;
                }
                
            }
        }

        /*
        if (cardInstance.nroProducto == 13 && GananciaUniversal > 2000 //Condiciones = True && GananciaTotal > 2000)
        {
            card1.gameObject.SetActive(false);
            card2.gameObject.SetActive(false);
            card3.gameObject.SetActive(false);
            winText.gameObject.SetActive(true);
            exit.gameObject.SetActive(true);
            Time.timeScale = 0;
            GameManager.MONEY = 400;
            GameManager.DAYS = 4;
        } else if(cardInstance.nroProducto != 13 && GananciaUniversal <= 2000 //Condiciones = False || GananciaTotal <= 2000)
        {
            card1.gameObject.SetActive(false);
            card2.gameObject.SetActive(false);
            card3.gameObject.SetActive(false);
            loseText.gameObject.SetActive(true);
            exit.gameObject.SetActive(true);
            Time.timeScale = 0;
            GameManager.MONEY = 0;
            GameManager.DAYS = 4;
        }*/
    }
}
