using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timer;    // Declaramos una variable p�blica de tipo TextMeshProUGUI
    private float tiempoTranscurrido = 0;
    private bool isGameRunning = true;    // Esta variable se utiliza para controlar si el juego est� en ejecuci�n o no.


    // Update is called once per frame
    void Update()
    {
        if (isGameRunning)    // Si el juego est� en ejecuci�n.
        {
            tiempoTranscurrido += Time.deltaTime;    // Incrementamos tiempoTranscurrido por el tiempo que ha pasado desde el �ltimo frame.
            timer.text = Mathf.FloorToInt(tiempoTranscurrido).ToString();    // Convertimos tiempoTranscurrido a un entero y luego a una cadena, y lo asignamos al texto del timer.
        }
        
    }

    public void GameFinished()    // M�todo que se llama en GameController cuando el juego ha terminado.
    {
        isGameRunning = false;    // Marcamos que el juego ya no est� en ejecuci�n.
    }
}
