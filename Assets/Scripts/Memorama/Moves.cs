using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Moves : MonoBehaviour
{
    public TextMeshProUGUI moves;    // Declaramos una variable p�blica de tipo TextMeshProUGUI.
    public GameController gameController;    // Declaramos una variable p�blica de tipo GameController.

    void Update()
    {
        moves.text = gameController.countGuesses.ToString();    // Asignamos el n�mero de intentos del GameController a la propiedad text del TextMeshProUGUI moves.
    }
}