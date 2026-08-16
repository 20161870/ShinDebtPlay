using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class RandomEvents : MonoBehaviour
{
    public static bool popupEvent;
    public static int rngEvent;
    public static bool flag = false; 
    [SerializeField] GameObject popup;
    [SerializeField] TMP_Text eventText;

    void Start()
    {

    }

    void Update()
    {
        if(popupEvent)
        {
            eventText.text = EventDatabase.cardList[rngEvent].textoEvent;
            if(flag)
            {
                if (EventDatabase.cardList[rngEvent].tipoVariable == 1)
                {
                    GameManager.COUNTDINERO += EventDatabase.cardList[rngEvent].dinero;
                }
                else if (EventDatabase.cardList[rngEvent].tipoVariable == 2)
                {
                    COINCOUNT.countDeuda += EventDatabase.cardList[rngEvent].dinero;
                }
                flag = false;
            }
            popup.SetActive(true);
        }
        else
        {
            popup.SetActive(false);
            flag = false;
        }
    }

    public void disablePopup()
    {
        popupEvent = false;
        flag = false;
    }

    
}
