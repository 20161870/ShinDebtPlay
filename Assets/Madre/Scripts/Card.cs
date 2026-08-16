using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]

public class Card
{
    public int id;
    public string nombreCarta;
    public int ganancia;
    public int precio;
    public int dificultad;
    public Sprite spriteImagen;

    public Card(){

    }

    public Card(int Id, string NombreCarta, int Ganancia, int Precio, int Dificultad, Sprite SpriteImagen){
        id = Id;
        nombreCarta = NombreCarta;
        ganancia = Ganancia;
        precio = Precio;
        dificultad = Dificultad;
        spriteImagen = SpriteImagen;
    }
}
