using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Moves : MonoBehaviour
{
    public TextMeshProUGUI moves;
    public GameController gameController;
    
    void Update()
    {
        moves.text = gameController.countGuesses.ToString();
    }
}