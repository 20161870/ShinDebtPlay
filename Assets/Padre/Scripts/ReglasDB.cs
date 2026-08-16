using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReglasDB : MonoBehaviour
{
     public static List<Reglas> ReglaList = new List<Reglas>();
    //tiempo inicial es 600
    //1 Operador es condicion > regla
    //2 Operador es condicion < regla
    void Awake(){
        ReglaList.Add(new Reglas(1, "Requisito de Ingreso Mínimo", "La regla indica el ingreso mínimo para aprobación de un préstamo es de $2,000 al mes. ¿Cumple con el requisito mínimo?", 1, 2000, 1));
        ReglaList.Add(new Reglas(2, "Límite Máximo de Deuda", "Sí el límite establecido de deuda acumulada es de $10, 000. ¿Se debería rechazar esta solicitud?", 2, 10000, 1));
        ReglaList.Add(new Reglas(3, "Tasa de interés", "Sí la tasa´máxima es de 25%, ¿Aprobarías este prestamo, o lo rechazarías por riesgo financiero?", 2, 25, 3));
        ReglaList.Add(new Reglas(4, "Cuenta de Ahorro", "Las cuentas con ahorros menores a $3000 son eligibles. ¿Aprobarías el préstamo?", 2, 3000, 4));
        ReglaList.Add(new Reglas(5, "Límite Máximo de Deuda", "La deuda del del solicitante no debe superar el límite permitido de $3,500. Entonces, ¿Se debería aprobar el documento?", 2, 3500, 1));
        ReglaList.Add(new Reglas(6, "Requisito de Ingreso Mínimo", "Para la aprobación de esta solicitud, el ingreso mensual mínimo debe ser de $4000. Por ello, ¿Esta solicitud cumple con la regla?", 1, 4000, 2));
        ReglaList.Add(new Reglas(7, "Cuenta de Ahorro", "Las cuentas con un ahorro mínimo de $5000 son eligibles para reducir su interés. Por ello. ¿Se aprobaría la reducción para esta solicitud?", 1, 5000, 4));
        ReglaList.Add(new Reglas(8, "Tasa de interés", "La tasa de interés máxima no debe exceder el 15%. En base a eso, ¿Se debería aprobar la solictud", 2, 15, 3));

        ReglaList.Add(new Reglas(9, "Requisito de Ingreso Mínimo", "El ingreso mensual mínimo debe ser de $4,000 para aprobar el préstamo. ¿Esta solicitud cumple el requerimiento?", 2, 4000, 1));
        ReglaList.Add(new Reglas(10, "Límite Máximo de Deuda", "Si la deuda del soliciante excede el límite mínimo de $3,000, el préstamo debe ser rechazado.", 1, 3000, 1));
        ReglaList.Add(new Reglas(11, "Tasa de interés", "El interés inicial sé aumentará con el tiempo, pero no que superará el límite del 7%.", 1, 7, 3));
        ReglaList.Add(new Reglas(12, "Cuenta de Ahorro", "Para saber sí tienes un buen historial y aprobar este documento, el solicitante requiere almenos $5000 en ahorros.", 1, 5000, 4));
        ReglaList.Add(new Reglas(13, "Límite Máximo de Deuda", "La línea de crédito permite endeudarse con un máximo de $2000, en caso de exceso, no se debe aprobar ninguna solicitud.", 2, 2000, 1));
        ReglaList.Add(new Reglas(14, "Requisito de Ingreso Mínimo", "Para la aprobación de la solicitud, el solicitnate debe contar con un ingreso mínimo de $4000.", 1, 4000, 2));
        ReglaList.Add(new Reglas(15, "Cuenta de Ahorro", "El documento será aceptado solo si cuenta con ahorros.", 1, 0, 4));
        ReglaList.Add(new Reglas(16, "Tasa de interés", "Durante los años, la tasa de interés ha alcanzado un interés de almenos 20%.", 1, 20, 3));
    }
}
