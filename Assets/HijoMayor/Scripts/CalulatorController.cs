using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using System;
using UnityEngine.UIElements;

public class CalulatorController : MonoBehaviour
{
    public TMP_InputField BtnText;
    private string Resultado;
    public static int CorrectAnswer;
    private BlocController blocController;

   void Start(){
        Resultado = "";
        CorrectAnswer = 0;
        blocController = FindObjectOfType<BlocController>();
   }

        public void OnButtonClick(GameObject Button)
    {
        string buttonText = Button.GetComponentInChildren<TextMeshProUGUI>().text;
        Resultado += buttonText;
        BtnText.text = Resultado;
    }

     public void OnDecimalButtonClick()
    {
        //Decimales
        if (!Resultado.Contains("."))
        {
            Resultado += ".";
            BtnText.text = Resultado;
        }
    }

    public void OnNegativeButtonClick()
    {
        //Negativos
        if (!Resultado.Contains("-"))
        {
            Resultado += "-";
            BtnText.text = Resultado;
        }
    }

public void CheckButtonClick()
{
    int ResInt;
    float ResFloat;
    float ResFormula;
    bool Correcto = false;

    foreach (GameObject blockGameObject in blocController.activeBlocks)
    {
        IntBlock intBlock = blockGameObject.GetComponent<IntBlock>();
        FloatBlock floatBlock = blockGameObject.GetComponent<FloatBlock>();
        FormulaBlock formulaBlock = blockGameObject.GetComponent<FormulaBlock>();

            if (intBlock != null && int.TryParse(Resultado, out ResInt))
            {
                int correctIntResult = intBlock.resI;

                if (ResInt == correctIntResult)
                {
                    ClearNumber();
                    Debug.Log("Correcto!");
                    PlayerHMInfo.Puntaje += 15 + GameManager.UpgradedCutMayor;
                    CorrectAnswer += 1;
                    PlayerHMInfo.AdaptDificulty();
                    Correcto = true;
                    DestroyBlock(blockGameObject);
                }
            }
            else if (floatBlock != null && float.TryParse(Resultado, out ResFloat))
            {
                float correctFloatResult = floatBlock.resf;

                if (ResFloat == correctFloatResult)
                {
                    ClearNumber();
                    Debug.Log("Correcto!");
                    PlayerHMInfo.Puntaje += 15 + GameManager.UpgradedCutMayor;
                    CorrectAnswer += 1;
                    Debug.Log("Rpta: " + CorrectAnswer);
                    PlayerHMInfo.AdaptDificulty();
                    Correcto = true;
                    DestroyBlock(blockGameObject);
                }
            }
            else if(formulaBlock != null && float.TryParse(Resultado, out ResFormula))
            {
                    int correctFormulaResult = formulaBlock.resFORMULA;

                    if (ResFormula == correctFormulaResult)
                    {
                        ClearNumber();
                        Debug.Log("Correcto!");
                        PlayerHMInfo.Puntaje += 60 + GameManager.UpgradedCutMayor;
                        CorrectAnswer += 1;
                        PlayerHMInfo.AdaptDificulty();
                        Correcto = true;
                        FindObjectOfType<BlocController>().ClearActiveBlocks();
                }



                }
    }

    if (!Correcto)
    {
        Debug.Log("Incorrecto!");
        PlayerHMInfo.NumVida--;
        ClearNumber();
        // Handle incorrect answer here if needed
    }

    ClearNumber();
}

    public void ClearNumber()
    {
        Resultado = "";
        BtnText.text = Resultado;
        Debug.Log(Resultado);
    }
private void DestroyBlock(GameObject blockGameObject)
    {
        if (blockGameObject != null)
        {
            blocController.RemoveBlock(blockGameObject);
            Destroy(blockGameObject);
        }
    }

}
