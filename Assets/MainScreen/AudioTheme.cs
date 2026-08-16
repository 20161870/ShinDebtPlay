using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTheme : MonoBehaviour
{
    [Header("Music")]
    [SerializeField] AudioSource BGMusic;

private void Awake(){
    DontDestroyOnLoad(gameObject);
}
    private void Start(){
        BGMusic.Play();
    }


}
