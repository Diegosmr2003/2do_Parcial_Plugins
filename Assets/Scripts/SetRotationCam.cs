using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetRotationCam : MonoBehaviour
{
    
    public Quaternion getRotation (){
        return transform.rotation;
    }
}
