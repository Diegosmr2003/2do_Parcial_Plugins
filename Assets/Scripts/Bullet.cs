using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    BossHealthBar bossHealthBar;

    private void Start()
    {
        bossHealthBar = FindObjectOfType<BossHealthBar>();
    }

    private void OnTriggerEnter(Collider other) //Este es ontriggerenter porque el guardian tiene un isTrigger
    {

        if (other.gameObject.name == "GuardianBox") //Si la bala colisiona con el guardian...
        {
            Destroy(other.gameObject); //Destruye al guardian
            Destroy(gameObject); //Y asi mismo destruye a la bala
            Score.contador += 100; // Se suman 10 puntos al contador del marcador. 
        }

        if (other.gameObject.name == "Xenomorph")
        {
            if(bossHealthBar.currentBossHealth > 0)
            {
                bossHealthBar.currentBossHealth -= 1000;
                Score.contador += 50;
            }
        }

    }


    private void OnCollisionEnter(Collision collision) //Este es oncollision porque las paredes, techo y piso no tienen isTrigger
    {

        if (collision.gameObject.name == "Floor" || collision.gameObject.name == "Ceiling" || collision.gameObject.name == "Wall") //Si colisiona con cualquiera de estos gameobjects...
        {
            Destroy(gameObject); //Destruye la bala
        }

    }

    private void Update()
    {
        Destroy(gameObject, 0.5f); //Si no colisiona ni con paredes, techo, piso o guardian, destruye la bala despues de 0.2 segundos
    }
}
