using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using System;
using UnityEngine.UIElements;

public class DebtCheck : MonoBehaviour
{
    public static int vida;
    public int contador = 0;

    public void Awake()
    {
        contador = 0;
    }

    public void CheckValores(ref int contador)
    {
        contador = 0;
        int matches = 0;
        List<int> processedRuleIds = new List<int>(); // ñista para evitar que se repitan los valores

        foreach (Condiciones condiciones in CondicionesDB.CondicionesList)
        {
            if (matches >= 4) //max matches por reglas y condiciones generadas
            {
                break;
            }

            foreach (Reglas reglas in ReglasDB.ReglaList)
            {
                if (matches >= 4) // Break out of the loop if the maximum number of matches is reached
                {
                    break;
                }

                // Match the ID of a condition with the ID condition in a rule and check the corresponding IDs generated
                if (condiciones.id == reglas.idCond &&
                    (reglas.id == PlayerPinfo.id1 || reglas.id == PlayerPinfo.id2 || reglas.id == PlayerPinfo.id3))
                {
                    if (processedRuleIds.Contains(reglas.id)) // Check if the rule ID has already been processed
                    {
                        continue; // Skip this iteration if the rule has already been processed
                    }

                    // Mark the current rule ID as processed
                    processedRuleIds.Add(reglas.id);

                    switch (reglas.idOpRegla)
                    {
                        //1 Operador es condicion > regla
                        case 1:
                            if (condiciones.monto >= reglas.monto)
                            {
                                Debug.Log("Correcto!");
                                // Debug.Log("Id: "+condiciones.id+"\n monto r: "+ reglas.monto +"/ monto c: "+condiciones.monto);
                                contador += 1;
                                matches++;
                            }
                            else
                            {
                                Debug.Log("Incorrecto!");
                                // Debug.Log("Id: "+condiciones.id+"\n monto r: "+reglas.monto +"/ monto c: "+condiciones.monto);
                            }
                            break;

                        //2 Operador es condicion < regla
                        case 2:
                            if (condiciones.monto <= reglas.monto)
                            {
                                Debug.Log("Correcto!");
                                // Debug.Log("Id: "+condiciones.id+"\n monto r: "+reglas.monto +"/ monto c: "+condiciones.monto);
                                contador += 1;
                                matches++;
                            }
                            else
                            {
                                Debug.Log("Incorrecto!");
                                // Debug.Log("Id: "+condiciones.id+"\n monto r: "+reglas.monto +"/ monto c: "+condiciones.monto);
                            }
                            break;
                    }
                }
            }
        }
    }


public void Correcto(){
    int contador = 0;
        CheckValores(ref contador);
        if(contador >= 3){
            Debug.Log("Acierto");
            PlayerPinfo.Puntaje++;
            }

        else{
            if(vida > 0){
                vida--;
            }
            else{
                Debug.Log("Perdiste");
                PlayerPinfo.currentTime = 0;
            }
        }
         Debug.Log("contador: " +contador);
    }
public void Incorrecto(){
        int contador = 0;
        CheckValores(ref contador);
        if(contador <=2){
                Debug.Log("Acierto");
                PlayerPinfo.Puntaje++;
            }
        else
            {
            if(vida > 0){
                vida--;
            }
            else{
                Debug.Log("Perdiste");
                PlayerPinfo.currentTime = 0;
            }
            }
        Debug.Log("contador: " +contador);
        }

private void OnEnable() {
    SceneManager.sceneLoaded += OnSceneLoaded;
}

private void OnDisable() {
    SceneManager.sceneLoaded -= OnSceneLoaded;
}

private void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
    contador = 0;
}

private void OnDestroy()
    {
        Debug.Log("GameObject has been destroyed");
        contador = 0;
        // Perform any necessary cleanup here
    }

   }    
   