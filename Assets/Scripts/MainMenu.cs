using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
   public void PlayGame()
    {
        SceneManager.LoadScene(1); //Cargamos la escena del laberinto
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit(); //Cerramos la app (esto es más que nada para un build, en nuestro caso solo se mostrará el mensaje en la consola de "Quit" simulando el cierre de la app)
    }

    public void Back2Main()
    {
        SceneManager.LoadScene(0); //Carga la escena del menu principal
    }

    public void ToMemoryGame()
    {
        SceneManager.LoadScene(2); //Carga la escena del memorama
    }
}
