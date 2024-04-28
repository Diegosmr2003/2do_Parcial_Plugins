using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static int enemiesNearPlayer = 0;
    CameraChange cameraFX;

    private void Start()
    {
        cameraFX = GetComponent<CameraChange>();
    }

    private void Update()
    {
        if (enemiesNearPlayer > 0)
        {
            cameraFX.activateEffect();
        }
        else
        {
            cameraFX.deactivateEffect();
        }
    }
}
