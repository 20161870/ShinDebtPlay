using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Animations;
using System;
using UnityEngine.UIElements;
using TMPro;

public class FloatBlock : MonoBehaviour
{
    private TMP_Text NU1;
    private TMP_Text NU2;
    private TMP_Text OP;
    private float N1;
    private float N2;
    private string Operator;
    public float resf; // donde se almacenará el resultado


    // Start is called before the first frame update
    void Start()
    {
        NU1 = transform.Find("F1").GetComponentInChildren<TMP_Text>();
        NU2 = transform.Find("F2").GetComponentInChildren<TMP_Text>();
        OP =  transform.Find("FOP").GetComponentInChildren<TMP_Text>();
       
        GenerarValores();
        UpdateValues();  
        Debug.Log(resf);
    }

    // Update is called once per frame
     private void GenerarValores()
    {
        if (PlayerHMInfo.Dificultad == 1)
        {
            N1 = Mathf.Round(UnityEngine.Random.Range(1f, 10f) * 10f) / 10f;
            N2 = Mathf.Round(UnityEngine.Random.Range(1f, 10f) * 10f) / 10f;
        }
        else if (PlayerHMInfo.Dificultad == 2)
        {
            N1 = Mathf.Round(UnityEngine.Random.Range(-10f, 10f) * 10f) / 10f;
            N2 = Mathf.Round(UnityEngine.Random.Range(-10f, 10f) * 10f) / 10f;
        }
        else
        {
            N1 = Mathf.Round(UnityEngine.Random.Range(-10f, 10f) * 10f) / 10f;
            N2 = Mathf.Round(UnityEngine.Random.Range(-10f, 10f) * 10f) / 10f;
        }

        Operator = GenerarOperador();
        resf = (Mathf.Round(CalcularOP() * 100) / 100);
    }

    public void UpdateValues()
    {
        NU1.text = (Mathf.Round(N1 * 100) / 100).ToString();
        NU2.text = (Mathf.Round(N2 * 100) / 100).ToString();
        OP.text = Operator;
    }

    //Genera la operación de manera aleatoria
    public string GenerarOperador()
    {
        if (PlayerHMInfo.Dificultad == 3)
        {
        string[] operador = { "+", "-", "*" };
        int randomOP = UnityEngine.Random.Range(0, operador.Length);
         return operador[randomOP];
        }
        else if (PlayerHMInfo.Dificultad != 3)
    {
        string[] operador = { "+", "-" };
        int randomOP = UnityEngine.Random.Range(0, operador.Length);
        return operador[randomOP];
    }
     else
    {
        Debug.LogError("Nivel de dificultad no válido");
        return "";
    }
    } 

     private float CalcularOP()
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
