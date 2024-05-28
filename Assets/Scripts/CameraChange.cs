using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour
{
    public GameObject mainCamera1; // Declaramos un gameobject que será la cámara del jugador
    public GameObject mainCamera2;

    private Effects effects1; // Componente Effects de la cámara 1
    private Effects effects2; // Componente Effects de la cámara 2

    void Start()
    {
        if (mainCamera1 != null)
        {
            effects1 = mainCamera1.GetComponent<Effects>();
            if (effects1 != null)
            {
                effects1.enabled = false; // Desactiva el efecto al inicio
            }
        }
        else
        {
            Debug.LogError("mainCamera1 is not assigned.");
        }

        if (mainCamera2 != null)
        {
            effects2 = mainCamera2.GetComponent<Effects>();
            if (effects2 != null)
            {
                effects2.enabled = false; // Desactiva el efecto al inicio
            }
        }
        else
        {
            Debug.LogError("mainCamera2 is not assigned.");
        }
    }

    public void activateEffect() // Hacemos una función que active el efecto
    {
        if (effects1 != null && !effects1.enabled)
        {
            effects1.enabled = true; // Lo activa
        }

        if (effects2 != null && !effects2.enabled)
        {
            effects2.enabled = true; // Lo activa
        }
    }

    public void deactivateEffect() // Hacemos una función que desactive el efecto
    {
        if (effects1 != null && effects1.enabled)
        {
            effects1.enabled = false; // Lo desactiva
        }

        if (effects2 != null && effects2.enabled)
        {
            effects2.enabled = false; // Lo desactiva
        }
    }
}
