using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHolder : MonoBehaviour //Este codigo es nada m�s para posicionar la camara en el lugar que nosotros le mandemos
{
    public Transform cameraPosition; //Hacemos un par�metro p�blico donde le daremos la posicion de la camara

    private void Update()
    {
        transform.position = cameraPosition.position; //Hacemos que la posicion del gameobject sea igual a la de la camara
    }
}
