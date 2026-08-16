using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public GameObject nodoActual;

    // VELOCIDAD DEL JUGADOR
    public static float velocidad = 4f;

    public string direccion = "";
    public string ultimaDireccionMovimiento = "";

    void Update()
    {
        NodeController controladorNodoActual = nodoActual.GetComponent<NodeController>();
        
        transform.position = Vector2.MoveTowards(transform.position, nodoActual.transform.position, (velocidad + GameManager.UpgradedCut)* Time.deltaTime);

        bool direccionRevesa = false;
        if(
            (direccion == "izquierda" && ultimaDireccionMovimiento == "derecha")
            || (direccion == "derecha" && ultimaDireccionMovimiento == "izquierda")
            || (direccion == "arriba" && ultimaDireccionMovimiento == "abajo")
            || (direccion == "abajo" && ultimaDireccionMovimiento == "arriba")
        ){
            direccionRevesa = true;
        }

        if((transform.position.x == nodoActual.transform.position.x && transform.position.y == nodoActual.transform.position.y) || direccionRevesa){
            GameObject nuevoNodo = controladorNodoActual.ObtenerNodoDesdeDireccion(direccion);
            if(nuevoNodo != null){
                nodoActual = nuevoNodo;
                ultimaDireccionMovimiento = direccion;
            }
            else{
                direccion = ultimaDireccionMovimiento;
                nuevoNodo = controladorNodoActual.ObtenerNodoDesdeDireccion(direccion);
                if(nuevoNodo != null){
                    nodoActual = nuevoNodo;
                }
            }
        }
    }

    public void SetDireccion(string nuevaDireccion){
        direccion = nuevaDireccion;
    }
}
