using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour //Este codigo es exclusivamente para el cambio del efecto de camara
{
    public GameObject mainCamera1; //Declaramos un gameobject que ser� la c�mara del jugador
    public GameObject mainCamera2;

    void Start()
    {
        mainCamera1.GetComponent<Effects>(); //Obtenemos el componente de "effects", que es el que venia con Effects Pro que descargamos en clase una vez
        mainCamera2.GetComponent<Effects>();
    }

    public void activateEffect() //Hacemos una funci�n que active el efecto
    {
        if (mainCamera1.GetComponent<Effects>().enabled != true){ //Si no est� activado previamente
            mainCamera1.GetComponent<Effects>().enabled = true; //Lo activa
        }

        if (mainCamera2.GetComponent<Effects>().enabled != true)
        { 
            mainCamera2.GetComponent<Effects>().enabled = true; //Lo activa
        }
    }

    public void deactivateEffect() //Hacemos una funci�n que desactive el efecto
    {
        if (mainCamera1.GetComponent<Effects>().enabled != false){ //Si no est� desactivado previamente
            mainCamera1.GetComponent<Effects>().enabled = false; //Lo desactiva
        }

        if (mainCamera2.GetComponent<Effects>().enabled != false)
        { 
            mainCamera2.GetComponent<Effects>().enabled = false; //Lo desactiva
        }
    }
}
