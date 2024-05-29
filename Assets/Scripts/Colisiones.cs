using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Colisiones : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "WinDoor") //Si el otro gameobject con el que colisiona es la puerta de salida...
        {
            SceneManager.LoadScene(5); //Carga la escena del memorama
            Cursor.lockState = CursorLockMode.None; //Desactiva la función que hace que el cursor se quede centrado en la pantalla
            Cursor.visible = true; //Hace al cursor visible
        }

        if (other.gameObject.name == "GuardianBox") //Si el otro gameobject con el que colisiona es el guardián...
        {
            SceneManager.LoadScene(3); //Carga la escena del gameover
            Cursor.lockState = CursorLockMode.None; //Desactiva la función que hace que el cursor se quede centrado en la pantalla
            Cursor.visible = true; //Hace al cursor visible
            Score.contador = 0;
        }

    }



}
