using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
public class GuardianScript : MonoBehaviour
{
    // Define los tres posibles recorridos
    public Vector3[][] recorridos = new Vector3[][]
    {
        new Vector3[]
        {
        new Vector3(5.53f, 0.21f, 1.76f),
        new Vector3(14.68f, 0.21f, 6.86f),
        new Vector3(0.06f, 0.21f, -4.4f),
        new Vector3(6.55f, 0.21f, -13.05f),
        new Vector3(11.34f, 0.21f, -4.34f),
        new Vector3(13.11f, 0.21f, -13.05f)

        },

        new Vector3[]
        {
        new Vector3(33.67f, 0.21f, 7.02f),
        new Vector3(33.6f, 0.21f, -2.62f),
        new Vector3(24.84f, 0.21f, -13.93f),
        new Vector3(41.36f, 0.21f, -9.36f),
        new Vector3(45.5f, 0.21f, -8.9f)
        },

        new Vector3[]
        {
        new Vector3(88.14f, 0.21f, 6.99f),
        new Vector3(52.4f, 0.21f, 5.3f),
        new Vector3(66.4f, 0.21f, 9.4f),
        new Vector3(82.4f, 0.21f,1.2f),
        new Vector3(11.34f, 0.21f, -10.28f),
        new Vector3(74f, 0.21f, -5.3f)
        }
    };



    public bool following = false; //Indica si se está sigueindo al jugador
    public GameObject player; // Referencia al jugador
    private NavMeshAgent agenteNavMesh; //Referencia a objeto con NavMesh
    private Vector3[] recorridoActual;  // Recorridio que el guardian está siguiendo
    private int indiceDestinoActual = 0;
    RaycastHit hit; 

    public float viewAngle = 180f; //Angulo de vision del guardian

    void Start()
    {
        agenteNavMesh = GetComponent<NavMeshAgent>(); //Inicializa el NavMesh
        int indiceRecorrido = UnityEngine.Random.Range(0, recorridos.Length); //Se elije aleatoriamente un recorrido de los tres posibles
        recorridoActual = recorridos[indiceRecorrido]; //Se elije aleatoriamente el recorrido

        int indicePosicionInicial = UnityEngine.Random.Range(0, recorridoActual.Length); //Elije la posicion aleatoriamente entre las diferentes posiciones del recorrido
        transform.position = recorridoActual[indicePosicionInicial]; //Coloca al guardian en la posicion inicial

        if (recorridoActual.Length > 0)
        {
            agenteNavMesh.SetDestination(recorridoActual[indicePosicionInicial]); //Prime rdestino al cual va el guardian
        }
    }

    void Update()
    {
        if (!agenteNavMesh.pathPending && agenteNavMesh.remainingDistance < 0.1f)
        {
            SiguienteDestino();
        }

        Chase();
    }

    void SiguienteDestino() // Si ha alcanzado el destino actual, elige el siguiente
    {
        // Selecciona aleatoriamente el próximo destino
        int nuevoIndice = UnityEngine.Random.Range(0, recorridoActual.Length);

        // Asegura que el nuevo índice no sea el mismo que el actual
        while (nuevoIndice == indiceDestinoActual)
        {
            nuevoIndice = UnityEngine.Random.Range(0, recorridoActual.Length);
        }
        // Establece el nuevo destino
        indiceDestinoActual = nuevoIndice;
        agenteNavMesh.SetDestination(recorridoActual[indiceDestinoActual]);
    }

    void Chase()
    {
        agenteNavMesh.speed = 2f;

   
        float SightRange = 200f;
        int numRays = 10;
        float angleBetweenRays = viewAngle / numRays;

        for(int i = 0; i < numRays; i++)
        {
            float rayAngle = -viewAngle / 2 + angleBetweenRays * i; // Ángulo del rayo
            Vector3 rayDirection = Quaternion.Euler(0, rayAngle, 0) * transform.forward; // Dirección del rayo

            // Si el rayo golpea algo
            if (Physics.Raycast(agenteNavMesh.transform.position, rayDirection, out hit, SightRange))
            {
                //Si se golpea a un objeto con el tag de "JUGADOR"
                if (hit.transform.gameObject.CompareTag("JUGADOR"))
                {
                    // Establece el destino como la posición del jugador y aumenta la velocidad y aceleración
                    agenteNavMesh.SetDestination(hit.transform.position);
                    following = true;
                    agenteNavMesh.speed = 7f;
                    agenteNavMesh.acceleration = 70f;
                    break;
                }
            }
        }
        
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        //Check if there has been a hit yet
        if (Physics.BoxCast(transform.position + transform.forward, transform.localScale * 2f, transform.forward, out hit, transform.rotation, 100f))
        {
            //Draw a Ray forward from GameObject toward the hit
            Gizmos.DrawRay(transform.position, transform.forward * 100f);
            //Draw a cube that extends to where the hit exists
            Gizmos.DrawWireCube(transform.position + transform.forward, transform.localScale);
        }
        //If there hasn't been a hit yet, draw the ray at the maximum distance
        else
        {
            //Draw a Ray forward from GameObject toward the maximum distance
            Gizmos.DrawRay(transform.position, transform.forward * 100f);
            //Draw a cube at the maximum distance
            Gizmos.DrawWireCube(transform.position + transform.forward, transform.localScale);
        }
    }

}