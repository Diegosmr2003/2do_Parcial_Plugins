using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class HealthBar : MonoBehaviour
{
    public Slider healthBarSlider; // Referencia al componente Slider de la barra de vida en el UI.
    public TextMeshProUGUI healthValueText; // Referencia al componente TextMeshProUGUI para mostrar la vida como un número.

    public int maxHealth; // Vida máxima del jugador 
    public int currentHealth; // Vida actual del jugador
    private int minHealth = 0; // Mínimo de vida del jugador es 0

    private void Start()
    {
        currentHealth = maxHealth; // Iguala la vida actual del jugador con la vida máxima disponible
    }

    private void Update()
    {
        healthValueText.text = currentHealth.ToString() + "/ " + maxHealth.ToString(); // Lo muestra en el canvas 
        healthBarSlider.value = currentHealth; // Actualiza la vida actual 
        healthBarSlider.maxValue = maxHealth; // Iguala el máximo de vida en el slider al valor de vida máxima 

        if(currentHealth <= minHealth)
        {
            SceneManager.LoadScene(3); // Cambia de escena con índice 3
            Cursor.lockState = CursorLockMode.None; //Desactiva la función que hace que el cursor se quede centrado en la pantalla
            Cursor.visible = true; //Hace al cursor visible
        }
    }
}

