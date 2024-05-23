using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CamSwitch : MonoBehaviour
{
    public GameObject cam1;
    public GameObject cam2;
    public GameObject gun;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("1Key"))
        {
            cam1.SetActive(true);
            cam2.SetActive(false);
            gun.transform.parent = cam1.transform;
        }
        if (Input.GetButtonDown("2Key"))
        {
            cam1.SetActive(false);
            cam2.SetActive(true);
            gun.transform.parent = cam2.transform;
        }

    }
}
