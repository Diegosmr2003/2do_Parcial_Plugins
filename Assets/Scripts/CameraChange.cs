using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour
{
    public GameObject mainCamera;

    void Start()
    {
        mainCamera.GetComponent<Effects>();
    }

    public void activateEffect()
    {
        if (mainCamera.GetComponent<Effects>().enabled != true){
            mainCamera.GetComponent<Effects>().enabled = true;
        }
        
    }

    public void deactivateEffect()
    {
        if (mainCamera.GetComponent<Effects>().enabled != false){
            mainCamera.GetComponent<Effects>().enabled = false;
        }
    }
}
