using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventDatabase : MonoBehaviour
{
    public static List<Event> cardList = new List<Event>();

    void Awake()
    {
        //1: Dinero total - 2: Deuda total
        cardList.Add(new Event(0, "None", 0, 0));
        cardList.Add(new Event(1,
            "Billy ha tomado dinero para comprarse unas nuevas zapatillas después de que las suyas se arruinaran trabajando. Se resta S/.120 del dinero total.", 
            -120, 1));
        cardList.Add(new Event(2,
            "Billy no pudo aguantar sus ganas y terminó tomando algo de dinero para comprar un nuevo videojuego. Se resta S/.180 del dinero total.",
            -180, 1));
        cardList.Add(new Event(3,
            "El vecino recompensó a Billy con un bono por su consistente buen trabajo podando su césped. Se suma S/.100 al dinero total.",
            100, 1));
        cardList.Add(new Event(4,
            "Josué les pidió a sus padres tomar un poco de dinero para asistir a un evento con sus amigos, y debido a su buen trabajo, aceptaron que se llevara un poco del dinero reunido. Se resta S/.200 del dinero total.",
            -200, 1));
        cardList.Add(new Event(5,
            "Josué se sobrecargó de trabajo y no pudo cumplir con algunas fechas, resultando que algunos padres dejen de pedir su ayuda. Se resta S/.100 del dinero total.",
            -150, 1));
        cardList.Add(new Event(6,
            "Uno de los estudiantes de Josué sacó una calificación perfecta en los últimos exámenes, y los padres del joven decidieron recompensarle por su excelente tutelaje. Se suma S/.200 al dinero total.",
            200, 1));
        cardList.Add(new Event(7,
            "Pilar ha perdido parte de su sueldo cuando iba a comprar los ingredientes para la cena, por lo que tomó un poco del ahorro familiar. Se resta S/.200 del dinero total.",
            -200, 1));
        cardList.Add(new Event(8,
            "Durante su trabajo, Pilar rompió unas cuantas botellas y tuvo que pagar por ellas. Se resta S/.150 del dinero total.",
            -150, 1));
        cardList.Add(new Event(9,
            "Pilar compró unos boletos de lotería y, sorpresivamente, pudo ganar una de las recompensas. Se suma S/.400 al dinero total.",
            400, 1));
        cardList.Add(new Event(10,
            "Roberto decidió llevar a su familia a un restaurante por el buen trabajo que estaban desempeñando. Se resta S/.300 del dinero total.",
            -300, 1));
        cardList.Add(new Event(11,
            "Roberto tuvo que pagar urgentemente algunas medicinas para su madre. Se resta S/.400 del dinero total.",
            -400, 1));
        cardList.Add(new Event(12,
            "Roberto logró ayudar a un cliente muy adinerado que le recompensó con un bono por sus servicios. Se suma S/.600 al dinero total.",
            600, 1));
        cardList.Add(new Event(13,
            "Pilar tuvo un buen rendimiento con el pago de las deudas por lo que la ZUNAT le dió un beneficio. Se resta S/.100 a la deuda total.",
            -100, 2));
        cardList.Add(new Event(14,
            "Roberto tuvo un mal rendimiento con el pago de las deudas por lo que la ZUNAT le dió un perjuicio. Se suma S/.100 a la deuda total.",
            100, 2));
        cardList.Add(new Event(15,
            "Josué no reportó los ingresos de su trabajo y fue penalizado por la ZUNAT. Se suma S/.150 a la deuda total.",
            150, 2));
        cardList.Add(new Event(16,
            "Josué no reportó los ingresos de su trabajo y fue penalizado por la ZUNAT. Se suma S/.200 a la deuda total.",
            200, 2));
        cardList.Add(new Event(17,
            "Pilar tuvo un excelente rendimiento con el pago de las deudas por lo que la ZUNAT le dió un beneficio. Se resta S/.200 a la deuda total.",
            -200, 2));
        cardList.Add(new Event(18,
            "Roberto tuvo un pesimo rendimiento con el pago de las deudas por lo que la ZUNAT le dió un perjuicio. Se suma S/.250 a la deuda total.",
            250, 2));
        cardList.Add(new Event(19,
            "¡Ladrones entraron a la casa cuando no habia nadie! Se resta S./800 al dinero total.",
            -800, 1));
        cardList.Add(new Event(20,
            "Roberto recibio un bono por su buen trabajo Se suma S/.300 al dinero total.",
            300, 1));
    }
}
