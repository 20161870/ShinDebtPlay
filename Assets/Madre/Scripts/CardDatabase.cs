using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CardDatabase : MonoBehaviour
{
    public static List<Card> cardList = new List<Card>();

    void Awake(){
        //Id, NombreCarta, Ganancia, Precio, Dificultad, SpriteImagen
        cardList.Add(new Card(0, "None", 0, 0, 0, Resources.Load<Sprite>("1_low")));
        cardList.Add(new Card(1, "Abarrote - Baja calidad", Random.Range(50, 100), Random.Range(50, 200), Random.Range(1,4), Resources.Load<Sprite>("1_low")));
        cardList.Add(new Card(2, "Abarrote - Media calidad", Random.Range(100, 400), Random.Range(200, 500), Random.Range(4, 7), Resources.Load<Sprite>("1_mid")));
        cardList.Add(new Card(3, "Abarrote - Alta calidad", Random.Range(400, 601), Random.Range(500, 701), Random.Range(7, 11), Resources.Load<Sprite>("1_high")));
        cardList.Add(new Card(4, "Conservas - Baja calidad", Random.Range(50, 100), Random.Range(50, 200), Random.Range(1, 4), Resources.Load<Sprite>("2_low")));
        cardList.Add(new Card(5, "Conservas - Media calidad", Random.Range(100, 400), Random.Range(200, 500), Random.Range(4, 7), Resources.Load<Sprite>("2_mid")));
        cardList.Add(new Card(6, "Conservas - Alta calidad", Random.Range(400, 601), Random.Range(500, 701), Random.Range(7, 11), Resources.Load<Sprite>("2_high")));
        cardList.Add(new Card(7, "Lacteos - Baja calidad", Random.Range(50, 100), Random.Range(50, 200), Random.Range(1, 4), Resources.Load<Sprite>("3_low")));
        cardList.Add(new Card(8, "Lacteos - Media calidad", Random.Range(100, 400), Random.Range(200, 500), Random.Range(4, 7), Resources.Load<Sprite>("3_mid")));
        cardList.Add(new Card(9, "Lacteos - Alta calidad", Random.Range(400, 601), Random.Range(500, 701), Random.Range(7, 11), Resources.Load<Sprite>("3_high")));
        cardList.Add(new Card(10, "Botanas - Baja calidad", Random.Range(50, 100), Random.Range(50, 200), Random.Range(1, 4), Resources.Load<Sprite>("4_low")));
        cardList.Add(new Card(11, "Botanas - Media calidad", Random.Range(100, 400), Random.Range(200, 500), Random.Range(4, 7), Resources.Load<Sprite>("4_mid")));
        cardList.Add(new Card(12, "Botanas - Alta calidad", Random.Range(400, 601), Random.Range(500, 701), Random.Range(7, 11), Resources.Load<Sprite>("4_high")));
        cardList.Add(new Card(13, "Confiterias - Baja calidad", Random.Range(50, 100), Random.Range(50, 200), Random.Range(1, 4), Resources.Load<Sprite>("5_low")));
        cardList.Add(new Card(14, "Confiterias - Media calidad", Random.Range(100, 400), Random.Range(200, 500), Random.Range(4, 7), Resources.Load<Sprite>("5_mid")));
        cardList.Add(new Card(15, "Confiterias - Alta calidad", Random.Range(400, 601), Random.Range(500, 701), Random.Range(7, 11), Resources.Load<Sprite>("5_high")));
        cardList.Add(new Card(16, "Harinas - Baja calidad", Random.Range(50, 100), Random.Range(50, 200), Random.Range(1, 4), Resources.Load<Sprite>("6_low")));
        cardList.Add(new Card(17, "Harinas - Media calidad", Random.Range(100, 400), Random.Range(200, 500), Random.Range(4, 7), Resources.Load<Sprite>("6_mid")));
        cardList.Add(new Card(18, "Harinas - Alta calidad", Random.Range(400, 601), Random.Range(500, 701), Random.Range(7, 11), Resources.Load<Sprite>("6_high")));
        cardList.Add(new Card(19, "Frutas - Baja calidad", Random.Range(50, 100), Random.Range(50, 200), Random.Range(1, 4), Resources.Load<Sprite>("7_low")));
        cardList.Add(new Card(20, "Frutas - Media calidad", Random.Range(100, 400), Random.Range(200, 500), Random.Range(4, 7), Resources.Load<Sprite>("7_mid")));
        cardList.Add(new Card(21, "Frutas - Alta calidad", Random.Range(400, 601), Random.Range(500, 701), Random.Range(7, 11), Resources.Load<Sprite>("7_high")));
        cardList.Add(new Card(22, "Vegetales - Baja calidad", Random.Range(50, 100), Random.Range(50, 200), Random.Range(1, 4), Resources.Load<Sprite>("8_low")));
        cardList.Add(new Card(23, "Vegetales - Media calidad", Random.Range(100, 400), Random.Range(200, 500), Random.Range(4, 7), Resources.Load<Sprite>("8_mid")));
        cardList.Add(new Card(24, "Vegetales - Alta calidad", Random.Range(400, 601), Random.Range(500, 701), Random.Range(7, 11), Resources.Load<Sprite>("8_high")));
        cardList.Add(new Card(25, "Bebidas - Baja calidad", Random.Range(50, 100), Random.Range(50, 200), Random.Range(1, 4), Resources.Load<Sprite>("9_low")));
        cardList.Add(new Card(26, "Bebidas - Media calidad", Random.Range(100, 400), Random.Range(200, 500), Random.Range(4, 7), Resources.Load<Sprite>("9_mid")));
        cardList.Add(new Card(27, "Bebidas - Alta calidad", Random.Range(400, 601), Random.Range(500, 701), Random.Range(7, 11), Resources.Load<Sprite>("9_high")));
        cardList.Add(new Card(28, "Instantaneos - Baja calidad", Random.Range(50, 100), Random.Range(50, 200), Random.Range(1, 4), Resources.Load<Sprite>("10_low")));
        cardList.Add(new Card(29, "Instantaneos - Media calidad", Random.Range(100, 400), Random.Range(200, 500), Random.Range(4, 7), Resources.Load<Sprite>("10_mid")));
        cardList.Add(new Card(30, "Instantaneos - Alta calidad", Random.Range(400, 601), Random.Range(500, 701), Random.Range(7, 11), Resources.Load<Sprite>("10_high")));
        cardList.Add(new Card(31, "Higiene - Baja calidad", Random.Range(50, 100), Random.Range(50, 200), Random.Range(1, 4), Resources.Load<Sprite>("11_low")));
        cardList.Add(new Card(32, "Higiene - Media calidad", Random.Range(100, 400), Random.Range(200, 500), Random.Range(4, 7), Resources.Load<Sprite>("11_mid")));
        cardList.Add(new Card(33, "Higiene - Alta calidad", Random.Range(400, 601), Random.Range(500, 701), Random.Range(7, 11), Resources.Load<Sprite>("11_high")));
        cardList.Add(new Card(34, "Domestico - Baja calidad", Random.Range(50, 100), Random.Range(50, 200), Random.Range(1, 4), Resources.Load<Sprite>("12_low")));
        cardList.Add(new Card(35, "Domestico - Media calidad", Random.Range(100, 400), Random.Range(200, 500), Random.Range(4, 7), Resources.Load<Sprite>("12_mid")));
        cardList.Add(new Card(36, "Domestico - Alta calidad", Random.Range(400, 601), Random.Range(500, 701), Random.Range(7, 11), Resources.Load<Sprite>("12_high")));
        cardList.Add(new Card(37, "None", 0, 0, 0, Resources.Load<Sprite>("1_low")));
        cardList.Add(new Card(38, "None", 0, 0, 0, Resources.Load<Sprite>("1_low")));
        cardList.Add(new Card(39, "None", 0, 0, 0, Resources.Load<Sprite>("1_low")));
    }
}
