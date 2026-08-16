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

public class PlayerPinfo : MonoBehaviour
{
    public static List<int> ReglasUsadas = new List<int>();
    public static List<Condiciones> ConditionRandomizer = new List<Condiciones>();
    public int displayId;
    public int id;
    public string NombreC;
    public string NombreRegla;
    public string textregla;
    public int monto;
    public int IDcond;
    private TMP_Text ScoreT;
    private TMP_Text LifeT;
    private TMP_Text RE1;
    private TMP_Text RE2;
    private TMP_Text RE3;
    private TMP_Text C1;
    private TMP_Text C2;
    private TMP_Text C3;
    private TMP_Text C4;
    public static int id1;
    public static int id2;
    public static int id3;
    public static int Puntaje;
    private int CantPapers;
    public int cont = 1;
    public static float currentTime = 0f;
    public static float startingTime = 300f;
    [SerializeField] GameObject panel;
    [SerializeField] TMP_Text countdownText;
    [SerializeField] TMP_Text winText;
    [SerializeField] TMP_Text loseText;
    [SerializeField] TMP_Text lifeText;
    [SerializeField] UnityEngine.UI.Button Exit; 

    // Start is called before the first frame update
    void Start()
    {
        CantPapers = UnityEngine.Random.Range(5, 6) - GameManager.UpgradedCutPadre;
        currentTime = startingTime + GameManager.UpgradedTimePadre;
        Puntaje = 0;
        panel.gameObject.SetActive(false);
        lifeText.gameObject.SetActive(false);
        UpdateValues();
        
    }
    void Awake()
    {
        Puntaje = 0;
        ScoreT = GameObject.Find("Score").GetComponent<TMP_Text>();
        LifeT = GameObject.Find("Life").GetComponent<TMP_Text>();
        RE1 = GameObject.Find("R1").GetComponent<TMP_Text>();
        RE2 = GameObject.Find("R2").GetComponent<TMP_Text>();
        RE3 = GameObject.Find("R3").GetComponent<TMP_Text>();
        C1 = GameObject.Find("C1").GetComponent<TMP_Text>();
        C2 = GameObject.Find("C2").GetComponent<TMP_Text>();
        C3 = GameObject.Find("C3").GetComponent<TMP_Text>();
        C4 = GameObject.Find("C4").GetComponent<TMP_Text>();
        GenerarRegla();
        GenerarCondicion();
    }

    void Update(){
        UpdateValues();
        currentTime -= 1 * Time.deltaTime;
        countdownText.text = currentTime.ToString("0");

        if(GameManager.UpgradedSpecialPadre){
            lifeText.gameObject.SetActive(true);
        }

        if(Puntaje >= CantPapers){
            panel.gameObject.SetActive(true);
            winText.gameObject.SetActive(true);
            Exit.gameObject.SetActive(true);
            Time.timeScale = 0;
            GameManager.MONEY = 800;
            GameManager.DAYS =8;
        }

        if(currentTime <= 0){
            panel.gameObject.SetActive(true);
            currentTime = 0;
            loseText.gameObject.SetActive(true);
            Exit.gameObject.SetActive(true);
            Time.timeScale = 0;
            GameManager.MONEY = 0;
            GameManager.DAYS =8;
        }
        
    }

    public void UpdateValues()
    {
        ScoreT.text = "" + Puntaje + "/" + CantPapers;
        LifeT.text = "" + DebtCheck.vida;
    }
   public void GenerarRegla()
{
    cont = 0; // Reset cont to 0 at the beginning
    ReglasUsadas.Clear(); // Clear the list of used rule IDs

    while (cont < 3)
    {
        displayId = UnityEngine.Random.Range(1, 16);
        
        // Check if the rule ID is not already used
        if (displayId >= 0 && displayId <= 16 && !ReglasUsadas.Contains(displayId))
        {
            Reglas selectedRegla = ReglasDB.ReglaList[displayId];
            id = selectedRegla.id;
            NombreRegla = selectedRegla.NombreRegla;
            textregla = selectedRegla.textregla;
            monto = selectedRegla.monto;
            IDcond = selectedRegla.idCond;
            cont++;

            // Add the used rule ID to the list
            ReglasUsadas.Add(displayId);

            switch (cont)
            { 
                case 1:
                    Debug.Log("id: " + displayId);
                    id1 = IDcond;
                    RE1.text = textregla;
                    //Debug.Log("cant: " + monto);
                    break;
                case 2:
                    Debug.Log("id: " + displayId);
                    id2 = IDcond;
                    RE2.text = textregla;
                    //Debug.Log("cant: " + monto);
                    break;
                case 3:
                    Debug.Log("id: " + displayId);
                    id3 = IDcond;
                    RE3.text = textregla;
                    //Debug.Log("cant: " + monto);
                    break;
            }
        }
    }
}
public void GenerarCondicion()
    {
        cont = 0;
        if (ConditionRandomizer.Count == 0)
        {
            ConditionRandomizer = new List<Condiciones>(CondicionesDB.CondicionesList);
            RandomizeCondiciones(ConditionRandomizer);
        }

        foreach (Condiciones selectedCondicion in ConditionRandomizer)
        {
            if (cont >= 4)
            {
                ConditionRandomizer.Clear();
                break;
            }
            id = selectedCondicion.id;
            NombreC = selectedCondicion.NombreC;
            cont++;
            
            switch (cont)
            {
                case 1:
                    if(selectedCondicion.id == 3){
                        C1.text = NombreC + ": " + (selectedCondicion.monto + UnityEngine.Random.Range(-2, 7)).ToString()+"%";
                    }
                    else
                    {
                        C1.text = NombreC + ": $" + (selectedCondicion.monto + UnityEngine.Random.Range(-2000, 1500)).ToString();
                    }
                    break;
                
                case 2:
                    if(selectedCondicion.id == 3){
                        C2.text = NombreC + ": " + (selectedCondicion.monto + UnityEngine.Random.Range(-2, 7)).ToString()+"%";
                    }
                    else
                    {
                        C2.text = NombreC + ": $" + (selectedCondicion.monto + UnityEngine.Random.Range(-2000, 1500)).ToString();
                    }
                    break;

                case 3:
                    if(selectedCondicion.id == 3){
                        C3.text = NombreC + ": " + (selectedCondicion.monto + UnityEngine.Random.Range(-2, 7)).ToString()+"%";
                    }
                    else
                    {
                        C3.text = NombreC + ": $" + (selectedCondicion.monto + UnityEngine.Random.Range(-2000, 1500)).ToString();
                    }
                    break;

                case 4:
                    if(selectedCondicion.id == 3){
                        C4.text = NombreC + ": " + (selectedCondicion.monto + UnityEngine.Random.Range(-2, 7)).ToString()+"%";
                    }
                    else
                    {
                        C4.text = NombreC + ": $" + (selectedCondicion.monto + UnityEngine.Random.Range(-2000, 1500)).ToString();
                    }
                    break;
            }
        }
    }
private void RandomizeCondiciones<T>(List<T> list)
{
    int n = list.Count;
    while (n > 1)
    {
        n--;
        int k = UnityEngine.Random.Range(0, n + 1);
        T value = list[k];
        list[k] = list[n];
        list[n] = value;
    }
}
}