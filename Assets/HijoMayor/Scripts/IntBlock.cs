using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Animations;
using System;
using UnityEngine.UIElements;
using TMPro;
using Unity.VisualScripting;

public class IntBlock : MonoBehaviour
{
    private TMP_Text NU1;
    private TMP_Text NU2;
    private TMP_Text OP;
    private int N1;
    private int N2;
    private string Operator;
    public int resI; // donde se almacenará el resultado

    void Start()
    {
        NU1 = transform.Find("N1").GetComponentInChildren<TMP_Text>();      
        NU2 = transform.Find("N2").GetComponentInChildren<TMP_Text>();
        OP =  transform.Find("OP").GetComponentInChildren<TMP_Text>();
        GenerarValores();
        Debug.Log(resI);
    }

    private void GenerarValores()
    {
        //DIf 1
        if(PlayerHMInfo.Dificultad == 1){
            N1 = UnityEngine.Random.Range(1, 10);
            N2 = UnityEngine.Random.Range(1, 10);
        }
        else if(PlayerHMInfo.Dificultad == 2){
            N1 = UnityEngine.Random.Range(-10, 10);
            N2 = UnityEngine.Random.Range(-10, 10);
        }
        else{
            N1 = UnityEngine.Random.Range(-10, 101);
            N2 = UnityEngine.Random.Range(-10, 101);
        }

        //
        Operator = GenerarOperador();
        resI = CalcularOP();
        UpdateValues();
    }

    private void UpdateValues(){
        NU1.text = "" + N1.ToString();
        NU2.text = "" + N2.ToString();
        OP.text = "" + Operator;
    }

    //Genera la operación de manera aleatoria
    public string GenerarOperador()
    {
        if (PlayerHMInfo.Dificultad == 1)
    {
        string[] operador = { "+", "-" };
        int randomOP = UnityEngine.Random.Range(0, operador.Length);
        return operador[randomOP];
    }
    else if (PlayerHMInfo.Dificultad == 2)
    {
        string[] operador = { "+", "-", "*" };
        int randomOP = UnityEngine.Random.Range(0, operador.Length);
        return operador[randomOP];
    }
    else if (PlayerHMInfo.Dificultad == 3)
    {
        string[] operador = { "+", "-", "*", "/" };
        int randomOP = UnityEngine.Random.Range(0, operador.Length);
        return operador[randomOP];
    }
    else
    {
        Debug.LogError("Nivel de dificultad no válido");
        return "";
    }
    }    

     private int CalcularOP()
    {
        switch (Operator)
        {
            //suma
            case "+":
                return N1 + N2;
            //resta
            case "-":
                return N1 - N2;
            //multi
            case "*":
                return N1 * N2;
            //division
            case "/":
                if (N2 != 0)
                {
                    return N1 / N2;
                }
                else
                {
                    Debug.LogError("División entre cero da error");
                    return 0;
                }
            //potencia

            //raiz

            default:
                return 0;
        }
    }

}
