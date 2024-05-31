using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSwitch : MonoBehaviour
{
    public GameObject cam1; // Cámara en primera persona
    public GameObject cam2; // Cámara en tercera persona
    public GameObject camAux; // GameObject auxiliar
    public GameObject gun;

    private PlayerCam playerCam1;
    private PlayerCam playerCam2;

    private void Start()
    {
        if (cam1 != null)
        {
            playerCam1 = cam1.GetComponent<PlayerCam>();
        }
        else if (cam1 == null)
        {
            Debug.LogError("cam1 no está asignada.");
        }
        else if (cam2 != null)
        {
            playerCam2 = cam2.GetComponent<PlayerCam>();
        }
        else if(cam2 == null)
        {
            Debug.LogError("cam2 no está asignada.");
        }
        else if (camAux == null)
        {
            Debug.LogError("camAux no está asignada.");
        }
        else if (gun == null)
        {
            Debug.LogError("gun no está asignada.");
        }
    }

    void Update()
    {
        if (Input.GetButtonDown("1Key"))
        {
            // Guardar la rotación actual de cam2 en camAux antes de desactivar cam2
            if (cam2.activeInHierarchy && camAux != null)
            {
                Quaternion cam2Rotation = cam2.GetComponent<SetRotationCam>().getRotation();
                camAux.transform.rotation = cam2Rotation;
            }

            // Activar/desactivar cámaras
            if (cam1 != null)
            {
                cam1.SetActive(true);
                if (gun != null)
                {
                    gun.transform.parent = cam1.transform;
                }
            }

            if (cam2 != null)
            {
                cam2.SetActive(false);
            }

            // Establecer la rotación de camAux a cam1 y a la pistola
            if (playerCam1 != null && camAux != null)
            {
                playerCam1.SetRotation(camAux.transform.rotation);
                if (gun != null)
                {
                    gun.transform.rotation = cam1.transform.rotation;
                    gun.transform.position = cam1.transform.position; //Para que la pistola no se mueva de lugar como pasaba anteriormente
                }
            }
        }

        if (Input.GetButtonDown("2Key"))
        {
            // Guardar la rotación actual de cam1 en camAux antes de desactivar cam1
            if (cam1.activeInHierarchy && camAux != null)
            {
                Quaternion cam1Rotation = cam1.GetComponent<SetRotationCam>().getRotation();
                camAux.transform.rotation = cam1Rotation;
            }

            // Activar/desactivar cámaras
            if (cam1 != null)
            {
                cam1.SetActive(false);
            }

            if (cam2 != null)
            {
                cam2.SetActive(true);
                if (gun != null)
                {
                    gun.transform.parent = cam2.transform;
                }
            }

            // Establecer la rotación de camAux a cam2 y a la pistola
            if (playerCam2 != null && camAux != null)
            {
                playerCam2.SetRotation(camAux.transform.rotation);
                if (gun != null)
                {
                    gun.transform.rotation = cam2.transform.rotation;
                    gun.transform.position = cam2.transform.position;
                }
            }
        }
    }
}
