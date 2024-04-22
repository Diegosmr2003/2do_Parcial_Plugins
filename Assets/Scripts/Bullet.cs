using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.name == "Guardian")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.name == "Floor" || collision.gameObject.name == "Ceiling" || collision.gameObject.name == "Wall")
        {
            Destroy(gameObject);
        }

    }

    private void Update()
    {
        Destroy(gameObject, 0.2f);
    }
}
