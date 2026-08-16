using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NodeController : MonoBehaviour
{
    public bool puedeMoverIzq = false;
    public bool puedeMoverDer = false;
    public bool puedeMoverArr = false;
    public bool puedeMoverAba = false;

    public GameObject nodoIzq;
    public GameObject nodoDer;
    public GameObject nodoArr;
    public GameObject nodoAba;

    public bool esNodoGrass = false;
    public bool tieneGrass = false;

    public SpriteRenderer grassSprite;
    public GeneralScript gameManager;

    void Awake()
    {
        gameManager = GameObject.Find("GeneralScript").GetComponent<GeneralScript>();
        if(transform.childCount > 0){
            tieneGrass = true;
            esNodoGrass = true;
            grassSprite = GetComponentInChildren<SpriteRenderer>();
        }

        RaycastHit2D[] hitAbajo;
        hitAbajo = Physics2D.RaycastAll(transform.position, -Vector2.up);
        for (int i = 0; i < hitAbajo.Length; i++){
            float distancia = Mathf.Abs(hitAbajo[i].point.y - transform.position.y);
            if(distancia < 0.4f && hitAbajo[i].collider.tag == "Node"){
                puedeMoverAba = true;
                nodoAba = hitAbajo[i].collider.gameObject;
            }
        }

        RaycastHit2D[] hitArriba;
        hitArriba = Physics2D.RaycastAll(transform.position, Vector2.up);
        for (int i = 0; i < hitArriba.Length; i++){
            float distancia = Mathf.Abs(hitArriba[i].point.y - transform.position.y);
            if(distancia < 0.4f && hitArriba[i].collider.tag == "Node"){
                puedeMoverArr = true;
                nodoArr = hitArriba[i].collider.gameObject;
            }
        }

        RaycastHit2D[] hitDerecha;
        hitDerecha = Physics2D.RaycastAll(transform.position, Vector2.right);
        for (int i = 0; i < hitDerecha.Length; i++){
            float distancia = Mathf.Abs(hitDerecha[i].point.x - transform.position.x);
            if(distancia < 0.4f && hitDerecha[i].collider.tag == "Node"){
                puedeMoverDer = true;
                nodoDer = hitDerecha[i].collider.gameObject;
            }
        }

        RaycastHit2D[] hitIzquierda;
        hitIzquierda = Physics2D.RaycastAll(transform.position, -Vector2.right);
        for (int i = 0; i < hitIzquierda.Length; i++){
            float distancia = Mathf.Abs(hitIzquierda[i].point.x - transform.position.x);
            if(distancia < 0.4f && hitIzquierda[i].collider.tag == "Node"){
                puedeMoverIzq = true;
                nodoIzq = hitIzquierda[i].collider.gameObject;
            }
        }
    }

    public GameObject ObtenerNodoDesdeDireccion(string direccion){
        if (direccion == "izquierda" && puedeMoverIzq){
            return nodoIzq;
        } 
        else if(direccion == "derecha" && puedeMoverDer){
            return nodoDer;
        }
        else if(direccion == "arriba" && puedeMoverArr){
            return nodoArr;
        }
        else if(direccion == "abajo" && puedeMoverAba){
            return nodoAba;
        }
        else{
            return null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.tag == "Player" && esNodoGrass){
            if(tieneGrass == true){
                gameManager.cont += 1;

                // PARA LA MEJORA TIEMPO
                gameManager.currentTime += 0.09f ;
            }
            tieneGrass = false;
            grassSprite.enabled = false;
        }
    }
}
