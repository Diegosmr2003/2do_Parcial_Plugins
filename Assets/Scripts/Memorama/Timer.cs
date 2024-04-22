using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timer;
    private float tiempoTranscurrido = 0;

    private bool isGameRunning = true;

    // Update is called once per frame
    void Update()
    {
        if (isGameRunning)
        {
            tiempoTranscurrido += Time.deltaTime;
            timer.text = Mathf.FloorToInt(tiempoTranscurrido).ToString();
        }
        
    }

    public void GameFinished()
    {
        isGameRunning = false;
    }
}
