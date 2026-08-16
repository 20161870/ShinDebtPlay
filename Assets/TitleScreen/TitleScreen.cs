using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    // Start is called before the first frame update
    public void Play()
    {
        SceneManager.LoadScene("Introduction");
    }

    public void QuitGame(){
        Debug.Log("Saliendo");
        Application.Quit();
    }


}
