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
    public GameObject cam1;
    Quaternion newRotation;

    private void Start()
    {
        newRotation = cam1.GetComponent<SetRotationCam>().getRotation();
        transform.rotation = newRotation;
        Cursor.lockState = CursorLockMode.Locked; //Cursor locked in the middle
        Cursor.visible = false; //Invisible

    }

    private void Update()
    {
        //Obtener el input del mouse
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        yRotation += mouseX;

        xRotation -= mouseY;

        //****Esta es simplemente la forma en que Unity maneja las rotaciones y los inputs, esta es la forma correcta de hacerlo***

        xRotation = Mathf.Clamp(xRotation, -90f, 90f); //Evitar que la camara de jugador vea mas hacia arriba o mas hacia abajo

        //Rotamos la camara y obtenemos la orientacion
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0); //Este es para que la camara se mueva en x y en y
        orientation.rotation = Quaternion.Euler(0, yRotation,0); //Este es para que SOLO el jugador se mueva en y cuando se mueva la camara 
    }
}
