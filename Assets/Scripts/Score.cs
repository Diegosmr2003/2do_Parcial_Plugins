using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI marcador;
    public static int contador;

    // Update is called once per frame
    void Update()
    {
        // Se muestra en pantalla el puntaje por medio de la variable contador.
        marcador.text = "Score: " + contador;
    }
}
