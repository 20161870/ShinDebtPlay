using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameConfirmation : MonoBehaviour
{
    [SerializeField]
    public Image Upg1Menor;
    public Image Upg2Menor;
    public Image Upg3Menor;

    public Image Upg1Mayor;
    public Image Upg2Mayor;
    public Image Upg3Mayor;

    public Image Upg1Madre;
    public Image Upg2Madre;
    public Image Upg3Madre;

    public Image Upg1Padre;
    public Image Upg2Padre;
    public Image Upg3Padre;

    public void PlayHijoMenor(){
        SceneManager.LoadScene("HijoMenor");
        Time.timeScale = 1;
    }

      public void PlayHijoMayor(){
        SceneManager.LoadScene("HijoMayor");
        Time.timeScale = 1;
    }

      public void PlayMadre(){
        SceneManager.LoadScene("Madre");
        Time.timeScale = 1;
    }

      public void PlayPadre(){
        SceneManager.LoadScene("Padre");
        Time.timeScale = 1;
    }

    public void Back(){
        SceneManager.LoadScene("MainScreen");
    }

     void Start()
    {
        InitializeSquares();
    }

    void Awake()
    {
        UpdateSquareColors();
    }

    void Update()
    {
        UpdateSquareColors();
    }

    void InitializeSquares()
    {
        // Hijo Menor
        Upg1Menor.color = Color.red;
        Upg2Menor.color = Color.red;
        Upg3Menor.color = Color.red;

        // Hijo Mayor
        Upg1Mayor.color = Color.red;
        Upg2Mayor.color = Color.red;
        Upg3Mayor.color = Color.red;

        // Madre
        Upg1Madre.color = Color.red;
        Upg2Madre.color = Color.red;
        Upg3Madre.color = Color.red;

        // Padre
        Upg1Padre.color = Color.red;
        Upg2Padre.color = Color.red;
        Upg3Padre.color = Color.red;
    }

    void UpdateSquareColors()
    {
        if (Upg1Menor != null)
        {
            Upg1Menor.color = GameManager.UpgradedCut > 0 ? Color.green : Color.red;
        }

        if (Upg2Menor != null)
        {
            Upg2Menor.color = GameManager.UpgradedTime > 0 ? Color.green : Color.red;
        }

        if (Upg3Menor != null)
        {
            Upg3Menor.color = GameManager.UpgradedSpecial ? Color.green : Color.red;
        }

        if (Upg1Mayor != null)
        {
            Upg1Mayor.color = GameManager.UpgradedCutMayor > 0 ? Color.green : Color.red;
        }

        if (Upg2Mayor != null)
        {
            Upg2Mayor.color = GameManager.UpgradedTimeMayor > 0 ? Color.green : Color.red;
        }

        if (Upg3Mayor != null)
        {
            Upg3Mayor.color = GameManager.UpgradedSpecialMayor ? Color.green : Color.red;
        }

        if (Upg1Madre != null)
        {
            Upg1Madre.color = GameManager.UpgradedCutMadre > 0 ? Color.green : Color.red;
        }

        if (Upg2Madre != null)
        {
            Upg2Madre.color = GameManager.UpgradedTimeMadre > 0 ? Color.green : Color.red;
        }

        if (Upg3Madre != null)
        {
            Upg3Madre.color = GameManager.UpgradedSpecialMadre ? Color.green : Color.red;
        }

        if (Upg1Padre != null)
        {
            Upg1Padre.color = GameManager.UpgradedCutPadre > 0 ? Color.green : Color.red;
        }

        if (Upg2Padre != null)
        {
            Upg2Padre.color = GameManager.UpgradedTimePadre > 0 ? Color.green : Color.red;
        }

        if (Upg3Padre != null)
        {
            Upg3Padre.color = GameManager.UpgradedSpecialPadre ? Color.green : Color.red;
        }
    }
}