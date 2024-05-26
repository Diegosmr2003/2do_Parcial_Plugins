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

    private void Start()
    {
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

        // Evitar que la cámara de jugador vea más hacia arriba o más hacia abajo
        xRotation = Mathf.Clamp(xRotation, 0, 20f);

        // Rotamos la cámara y obtenemos la orientación
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }

    public void SetRotation(Quaternion rotation)
    {
        transform.rotation = rotation;
        Vector3 eulerRotation = rotation.eulerAngles;
        xRotation = eulerRotation.x;
        yRotation = eulerRotation.y;
    }
}
