using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour //Este codigo es exclusivamente para el cambio del efecto de camara
{
    public GameObject mainCamera; //Declaramos un gameobject que será la cámara del jugador

    void Start()
    {
        mainCamera.GetComponent<Effects>(); //Obtenemos el componente de "effects", que es el que venia con Effects Pro que descargamos en clase una vez
    }

    public void activateEffect() //Hacemos una función que active el efecto
    {
        if (mainCamera.GetComponent<Effects>().enabled != true){ //Si no está activado previamente
            mainCamera.GetComponent<Effects>().enabled = true; //Lo activa
        }
        
    }

    public void deactivateEffect() //Hacemos una función que desactive el efecto
    {
        if (mainCamera.GetComponent<Effects>().enabled != false){ //Si no está desactivado previamente
            mainCamera.GetComponent<Effects>().enabled = false; //Lo desactiva
        }
    }
}
