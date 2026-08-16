using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Animations;
using System;
using UnityEngine.UIElements;
using TMPro;
using Unity.VisualScripting;

public class FormulaBlock : MonoBehaviour
{
    private TMP_Text DATOS_BLOCK;
    private TMP_Text RPTA_BLOCK;
    private TMP_Text PREG_BLOCK;
    private int interes;
    private int capital;
    private int tasa;
    private int tiempo;
    private int ValorFinal;
    private int DATOS;
    private int RPTA;
    private int PREG;
    public int resFORMULA; // donde se almacenará el resultado

    void Start()
    {//Establecer componentes a usar



        DATOS_BLOCK = transform.Find("DATOS").GetComponentInChildren<TMP_Text>();
        RPTA_BLOCK = transform.Find("RPTA").GetComponentInChildren<TMP_Text>();
        PREG_BLOCK = transform.Find("PREG").GetComponentInChildren<TMP_Text>();
        GenerarValores();
        Debug.Log("Tipo: " + PREG);
        Debug.Log("Formula: " + resFORMULA);
    }

    private void GenerarValores()
    {
        switch (PlayerHMInfo.Dificultad)
        {
            case 1: 
                PREG = UnityEngine.Random.Range(0, 0);
                break;

            case 2:
                PREG = UnityEngine.Random.Range(1, 2);
                break;

            case 3:
                PREG = UnityEngine.Random.Range(0, 2);
                break;
        }

        if (PREG == 0) //Buscar Valor Final
        {
            //DIf 1
            if (PlayerHMInfo.Dificultad == 1)
            {
                tiempo = UnityEngine.Random.Range(1, 6);
                capital = UnityEngine.Random.Range(1, 6) * 100;
                tasa = UnityEngine.Random.Range(1, 6);
                interes = tiempo * capital * tasa / 100;
                ValorFinal = capital + interes;
                
            }
            else if (PlayerHMInfo.Dificultad == 2)
            {
                tiempo = UnityEngine.Random.Range(1, 9);
                capital = UnityEngine.Random.Range(1, 11) * 100;
                tasa = UnityEngine.Random.Range(1, 11);
                interes = tiempo * capital * tasa / 100;
                ValorFinal = capital + interes;

            }
            else
            {
                tiempo = UnityEngine.Random.Range(1, 11);
                capital = UnityEngine.Random.Range(1, 16) * 100;
                tasa = UnityEngine.Random.Range(1, 16);
                interes = tiempo * capital * tasa / 100;
                ValorFinal = capital + interes;

            }
            resFORMULA = ValorFinal;
        }
        else //Buscar el interes total
        {
            if (PlayerHMInfo.Dificultad == 1)
            {
                tiempo = UnityEngine.Random.Range(1, 6);
                capital = UnityEngine.Random.Range(1, 6) * 100;
                tasa = UnityEngine.Random.Range(1, 6);
                interes = tiempo * capital * tasa / 100;
                ValorFinal = capital + interes;

            }
            else if (PlayerHMInfo.Dificultad == 2)
            {
                tiempo = UnityEngine.Random.Range(1, 9);
                capital = UnityEngine.Random.Range(1, 11) * 100;
                tasa = UnityEngine.Random.Range(1, 11);
                interes = tiempo * capital * tasa/100;
                ValorFinal = capital + interes;

            }
            else
            {
                tiempo = UnityEngine.Random.Range(1, 11);
                capital = UnityEngine.Random.Range(1, 16) * 100;
                tasa = UnityEngine.Random.Range(1, 16);
                interes = tiempo * capital * tasa/100;
                ValorFinal = capital + interes;

            }
            resFORMULA = interes;
        }
    

        UpdateValues();
    }

    private void UpdateValues(){

        if (PREG == 0) //Buscar Valor Final
        {

            DATOS_BLOCK.text =
            "Interés:" + "\n" +
            "I = " + interes + "\n" +
            "Capital: " + "\n" +
            "C = " + capital + "\n" +
            "Tasa de Interés: " +
            "i = " + tasa + "%\n" +
            "Tiempo (Años): " + "\n" +
            "t = " + tiempo;

            PREG_BLOCK.text = "¿Cuanto es el " + "\n" +
                "Valor Final (Vf)?";
        }
        else
        {
            DATOS_BLOCK.text =
           "Capital: " + "\n" +
           "C = " + capital + "\n" +
           "Tasa de Interés: " + "\n" +
           "i = " + tasa + "%\n" +
           "Tiempo (Años): " + "\n" +
           "t = " + tiempo;


            PREG_BLOCK.text = "¿Cuanto es " + "\n" +
                "el Interés (I)?";
        }
    }

}
