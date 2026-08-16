using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using System;
using Random = UnityEngine.Random;
using Unity.VisualScripting;
using System.Linq;

public class DisplayCard : MonoBehaviour
{
    public List<Card> displayCard = new List<Card>();
    public int displayId;

    public int id;
    public string nombreCarta;
    public int ganancia;
    public int precio;
    public int dificultad;
    public Sprite spriteImagen;
    [SerializeField] TMP_Text nombreText;
    [SerializeField] TMP_Text gananciaText;
    [SerializeField] TMP_Text precioText;
    [SerializeField] TMP_Text dificultadText;
    [SerializeField] Image arteImagen;

    [SerializeField] TMP_Text GananciaTotalText;
    public int GananciaUniversal;
    [SerializeField] TMP_Text DineroTotalText;
    public int DineroUniversal;

    public float rng;
    public bool hit;
    [SerializeField] TMP_Text sucessText;
    [SerializeField] TMP_Text failText;

    public int nroProducto;
    public List<(int, int, bool)> selectedCards = new List<(int, int, bool)>();

    public int carta;

    void Awake(){
        GananciaUniversal = 0;
        DineroUniversal = 4500 + GameManager.UpgradedTimeMadre; //MEJORA #2, TE DA 300 extra
        rng = 0f;
        hit = false;

        nroProducto = 1;
        selectedCards.Clear();
    }

    void Start()
    {
        displayId = carta;
        GananciaTotalText.text = GananciaUniversal.ToString();
        DineroTotalText.text = DineroUniversal.ToString();
    }

    void Update()
    {
        displayCard[0] = CardDatabase.cardList[displayId];

        //Display de cartas
        id = displayCard[0].id;
        nombreCarta = displayCard[0].nombreCarta;
        ganancia = displayCard[0].ganancia;
        precio = displayCard[0].precio;
        dificultad = displayCard[0].dificultad;
        spriteImagen = displayCard[0].spriteImagen;

        nombreText.text = " " + nombreCarta;
        gananciaText.text = "Utilidades: " + ganancia;
        precioText.text = "Precio: " + precio;
        dificultadText.text = "Dificultad Venta: " + dificultad + "/10";
        arteImagen.sprite = spriteImagen;

        //Dinero Ganado
        GananciaUniversal = Convert.ToInt32(GananciaTotalText.text);

        //Dinero Restante
        DineroUniversal = Convert.ToInt32(DineroTotalText.text);
    }

    public void Shuffle(){
        if (displayId > 36 || displayId == 0) {
            displayId = 0;
        }
        else {
            displayId = displayId + 3;
            nroProducto += 1;
        }
    }

    public void Seleccionar(){
        //Tira de dados aleatorios
        for(int i = 0; i < (11 - dificultad); i++){
            rng = Random.Range(1,11);
            if (rng >= 9){
                hit = true;
            }
        }

        //Condicion de acierto
        if (hit == true){
            //Mejora 1: todas las cartas dan +50 extra
            GananciaUniversal = displayCard[0].ganancia + GananciaUniversal + GameManager.UpgradedCutMadre;  
            //Debug.Log(GameManager.UpgradedCutMadre);
            GananciaTotalText.text = GananciaUniversal.ToString("0");
            failText.gameObject.SetActive(false);
            sucessText.gameObject.SetActive(true);

            selectedCards.Add((nroProducto, displayCard[0].ganancia, true));
   
        }
        else {
            //MEJORA Special: Salva 50 puntos de VENTAS MALAS
            if (GameManager.UpgradedSpecialMadre == true){
                GananciaUniversal = GananciaUniversal + 50;
            }
            else{
                GananciaUniversal = GananciaUniversal + 0; 
            } 

            GananciaTotalText.text = GananciaUniversal.ToString("0");
            sucessText.gameObject.SetActive(false);
            failText.gameObject.SetActive(true);

            selectedCards.Add((nroProducto, displayCard[0].ganancia, false));
            
        }
        Debug.Log(selectedCards.LastOrDefault());

        //Gasto de Dinero
        DineroUniversal = DineroUniversal - displayCard[0].precio;
        DineroTotalText.text = DineroUniversal.ToString("0");

        rng = 0;
        hit = false;
    }
}
