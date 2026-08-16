using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Condiciones : MonoBehaviour
{
    public int id;
    public string NombreC;
    public int monto;

    public Condiciones(){

    }
    //Para las condiciones del trato a revisar
    public Condiciones(int Id,string NombreCondicion, int generado){
        id = Id;
        NombreC = NombreCondicion;
        monto = generado;
    }
}
