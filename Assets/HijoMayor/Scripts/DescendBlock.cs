using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DescendBlock : MonoBehaviour
{
    private float descendSpeed = 0.43f;
    public Transform DestroyPoint;
     public BlocController blocController;

    public void Update()
    {
        transform.Translate(Vector3.down * descendSpeed * Time.deltaTime);
        //Si baja más de la barra de DestroyPad
        SetSpeedByTagAndDifficulty();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("DestroyBar"))
    {
        // Remove the block from the activeBlocks list
            if (blocController != null)
            {
                blocController.RemoveBlock(gameObject);
            }
        
        // Destroy the GameObject
        Destroy(gameObject);
    }
    }

    private void SetSpeedByTagAndDifficulty()
    {
        string tag = gameObject.tag;
        int dificultad = PlayerHMInfo.Dificultad;

        // Puedes ajustar estos valores como quieras
        switch (tag)
        {
            case "IntBlock":
                descendSpeed = dificultad switch
                {
                    1 => 0.75f,
                    2 => 0.75f,
                    3 => 0.75f,
                    _ => 0.75f
                };
                break;

            case "FloatBlock":
                descendSpeed = dificultad switch
                {
                    1 => 0.75f,
                    2 => 0.75f,
                    3 => 0.75f,
                    _ => 0.75f
                };
                break;

            case "FormulaBlock":
                descendSpeed = dificultad switch
                {
                    1 => 0.35f,
                    2 => 0.35f,
                    3 => 0.35f,
                    _ => 0.35f
                };
                break;

            default:
                descendSpeed = 0.5f;
                break;
        }
    }
}



