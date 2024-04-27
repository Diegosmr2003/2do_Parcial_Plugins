using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour
{
    public GameObject camera;

    public void activateEffect()
    {
        camera.GetComponent<Effects>().enabled = true;
    }

    public void deactivateEffect()
    {
        camera.GetComponent<Effects>().enabled = false;
    }
}
