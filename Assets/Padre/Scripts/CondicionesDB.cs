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

public class CondicionesDB : MonoBehaviour
{
 public static List<Condiciones> CondicionesList = new List<Condiciones>();
    void Awake(){
      CondicionesList.Add(new Condiciones(1,"Deuda",UnityEngine.Random.Range(2000, 5001)));
      CondicionesList.Add(new Condiciones(2,"Ingreso Mensual",UnityEngine.Random.Range(2000, 5001)));
      CondicionesList.Add(new Condiciones(3, "Tasa de Interés",UnityEngine.Random.Range(1, 35)));
      CondicionesList.Add(new Condiciones(4, "Cuenta de Ahorro", UnityEngine.Random.Range(2000, 5001)));
    }
}
