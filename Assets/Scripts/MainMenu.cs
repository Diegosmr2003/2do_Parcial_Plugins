using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
   public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void Back2Main()
    {
        SceneManager.LoadScene(0);
    }

    public void ToMemoryGame()
    {
        SceneManager.LoadScene(2);
    }
}
