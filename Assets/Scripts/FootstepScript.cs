using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class footsteps : MonoBehaviour //Debido a que los sonidos de los pasos van a ser loopeables, se tiene que hacer una función aparte que se encargue de eso
{
    public AudioSource footstepsSound, sprintSound; //Le pasamos los audiosources para los pasos y el sprint

    void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)) //Obtenemos las 4 teclas disponibles para el jugador y checamos si se presionan
        {
            if (Input.GetKey(KeyCode.LeftShift)) //Si el jugador presiona shift para correr
            {
                footstepsSound.enabled = false; //Desactivamos el sonido de los pasos
                sprintSound.enabled = true; //Activamos el sonido del sprint
            }
            else
            {
                footstepsSound.enabled = true; //Activamos el sonido de los pasos
                sprintSound.enabled = false; //Desactivamos el sonido del sprint
            }
        }
        else //Si no presiona nada
        {
            footstepsSound.enabled = false; //Desactivamos los pasos
            sprintSound.enabled = false; //Desactivamos el sprint
        }
    }
}