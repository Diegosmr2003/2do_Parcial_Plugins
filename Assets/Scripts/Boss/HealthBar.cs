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

    public int maxHealth;
    public int currentHealth;
    private int minHealth = 0;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        healthValueText.text = currentHealth.ToString() + "/ " + maxHealth.ToString();
        healthBarSlider.value = currentHealth;
        healthBarSlider.maxValue = maxHealth;

        if(currentHealth <= minHealth)
        {
            SceneManager.LoadScene(3);
            Cursor.lockState = CursorLockMode.None; //Desactiva la función que hace que el cursor se quede centrado en la pantalla
            Cursor.visible = true; //Hace al cursor visible
        }
    }
}

