using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Colisiones : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "WinDoor")
        {
            SceneManager.LoadScene(2);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        if (other.gameObject.name == "GuardianBox")
        {
            SceneManager.LoadScene(3);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

    }



}
