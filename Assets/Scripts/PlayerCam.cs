using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    public float sensX; //Sensibility in x and y
    public float sensY;

    public Transform orientation;

    public float xRotation; //Rotation for x and y
    public float yRotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; //Cursor locked in the middle
        Cursor.visible = false; //Invisible

    }

    private void Update()
    {
        //get mouse input
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        yRotation += mouseX;

        xRotation -= mouseY;

        //****This is just the way Unity handles rotations and inputs, this is the correct way to do it***

        xRotation = Mathf.Clamp(xRotation, -90f, 90f); //Evitar que la camara de jugador vea mas hacia arriba o mas hacia abajo

        //rotate cam and orientation
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0); //Este es para que la camara se mueva en x y en y
        orientation.rotation = Quaternion.Euler(0, yRotation,0); //Este es para que SOLO el jugador se mueva en y cuando se mueva la camara 
    }
}
