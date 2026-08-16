using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{
    public TMP_Text Condition;
    public TMP_Text Paragraph;
    private AudioSource Victory;
    private AudioSource Defeat;

    void Start()
    {
        Condition = GameObject.Find("title").GetComponent<TMP_Text>();
        Paragraph = GameObject.Find("paragraph").GetComponent<TMP_Text>();
    }

    void Update(){
        WinOrLose();
    }
        
    public void WinOrLose(){
        if(COINCOUNT.countDeuda <= 0 && GameManager.DAYSBY !=1){
            GameObject.Find("title").GetComponent<TMP_Text>().color = Color.green;
            Condition.text = "Ganaste";
            Paragraph.text = "Lograste completar la deuda antes que se acaba el tiempo.";
            //Victory.Play();
        }

        if(COINCOUNT.countDeuda > 0 && GameManager.DAYSBY >= 30){
            GameObject.Find("title").GetComponent<TMP_Text>().color = Color.red;
            Condition.text = "Perdiste";
            Paragraph.text = "No lograste completar la deuda antes que se acaba el tiempo.";
            //Defeat.Play();
        }
    }

    public void BackToTitle(){
        Debug.Log("Saliendo");
        Application.Quit();
        // Hace visible el texto y el boton para jugar el minijuego del hijo menor
    }
    

}
