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

public class Reglas : MonoBehaviour
{   
    public int id;
    public string NombreRegla;
    public string textregla;
    public int monto;
    public int idOpRegla;
    public int idCond;
    

    public Reglas(){

    }
    //Para crear las reglas es nombre, 
    public Reglas(int Id, string Name,string Rtexto,int OpRegla, int Valor, int IDC){
        id = Id;
        NombreRegla = Name;
        textregla = Rtexto;
        idOpRegla=OpRegla;
        monto = Valor;
        idCond = IDC;
    }



    }
