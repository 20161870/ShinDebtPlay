using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]

public class Event
{
    public int id;
    public string textoEvent;
    public int dinero;
    public int tipoVariable;

    public Event()
    {

    }

    public Event(int Id, string TextoEvent, int Dinero, int TipoVariable)
    {
        id = Id;
        textoEvent = TextoEvent;
        dinero = Dinero;
        tipoVariable = TipoVariable;
    }
}
