using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Colisiones : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        print("Colision");
        if (other.gameObject.name == "WinDoor")
        {
            SceneManager.LoadScene(2);
        }
        
    }



}
