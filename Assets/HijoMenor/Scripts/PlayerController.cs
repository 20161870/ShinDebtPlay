using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    MovementController controladorMovimiento;
    public SpriteRenderer sprite;
    public Animator animador;

    void Awake(){
        animador = GetComponentInChildren<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();

        controladorMovimiento = GetComponent<MovementController>();
    }

    void Update()
    {
        animador.SetBool("movimiento", true);

        if(Input.GetKey(KeyCode.LeftArrow)){
            controladorMovimiento.SetDireccion("izquierda");
        }
        if(Input.GetKey(KeyCode.RightArrow)){
            controladorMovimiento.SetDireccion("derecha");
        }
        if(Input.GetKey(KeyCode.UpArrow)){
            controladorMovimiento.SetDireccion("arriba");
        }
        if(Input.GetKey(KeyCode.DownArrow)){
            controladorMovimiento.SetDireccion("abajo");
        }

        bool flipX = false;
        if(controladorMovimiento.ultimaDireccionMovimiento == "izquierda"){
            animador.SetInteger("direccion", 0);
        }
        else if(controladorMovimiento.ultimaDireccionMovimiento == "derecha"){
            animador.SetInteger("direccion", 0);
            flipX = true;
        }
        else if(controladorMovimiento.ultimaDireccionMovimiento == "arriba"){
            animador.SetInteger("direccion", 1);
        }
        else if(controladorMovimiento.ultimaDireccionMovimiento == "abajo"){
            animador.SetInteger("direccion", 2);
        }

        sprite.flipX = flipX;
    }
}
