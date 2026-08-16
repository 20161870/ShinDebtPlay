using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainScreen : MonoBehaviour
{
    private TMP_Text CountDays;

    void Awake(){
         CountDays = GameObject.Find("DaysCount").GetComponent<TMP_Text>();
    }
    void Update(){
         CountDays.text = "Dia " + GameManager.DAYSBY;
    }

    public void PlayHijoMenor(){
        SceneManager.LoadScene("GameConfirmationMenor");
        
        // Hace visible el texto y el boton para jugar el minijuego del hijo menor
    }

     public void PlayHijMayor(){
        SceneManager.LoadScene("GameConfirmationMayor");
        
        // Hace visible el texto y el boton para jugar el minijuego del hijo menor
    }

      public void PlayMadre(){
        SceneManager.LoadScene("GameConfirmationMadre");
        
        // Hace visible el texto y el boton para jugar el minijuego del hijo menor
    }

      public void PlayPadre(){
        SceneManager.LoadScene("GameConfirmationPadre");
        
        // Hace visible el texto y el boton para jugar el minijuego del hijo menor
    }

    public void GestionDeFinanzas(){
        SceneManager.LoadScene("MoneyManagement");
    }

    public void Iniciar(){
        SceneManager.LoadScene("MainScreen");
    }
}
