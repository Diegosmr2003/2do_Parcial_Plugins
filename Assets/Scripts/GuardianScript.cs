using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GuardianScript : MonoBehaviour
{
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
            new Vector3(82.4f, 0.21f, 1.2f),
            new Vector3(11.34f, 0.21f, -10.28f),
            new Vector3(74f, 0.21f, -5.3f)
        }
    };

    public bool following = false;
    public GameObject player;
    private NavMeshAgent agenteNavMesh;
    private Vector3[] recorridoActual;
    private int indiceDestinoActual = 0;
    private RaycastHit hit;

    public float viewAngle = 180f;

    void Start()
    {
        agenteNavMesh = GetComponent<NavMeshAgent>();
        int indiceRecorrido = UnityEngine.Random.Range(0, recorridos.Length);
        recorridoActual = recorridos[indiceRecorrido];

        int indicePosicionInicial = UnityEngine.Random.Range(0, recorridoActual.Length);
        transform.position = recorridoActual[indicePosicionInicial];

        if (recorridoActual.Length > 0)
        {
            agenteNavMesh.SetDestination(recorridoActual[indicePosicionInicial]);
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

    void SiguienteDestino()
    {
        int nuevoIndice = UnityEngine.Random.Range(0, recorridoActual.Length);
        while (nuevoIndice == indiceDestinoActual)
        {
            nuevoIndice = UnityEngine.Random.Range(0, recorridoActual.Length);
        }
        indiceDestinoActual = nuevoIndice;
        agenteNavMesh.SetDestination(recorridoActual[indiceDestinoActual]);
    }

    void Chase()
    {
        agenteNavMesh.speed = 2f;
        float SightRange = 200f;
        int numRays = 10;
        float angleBetweenRays = viewAngle / numRays;

        for (int i = 0; i < numRays; i++)
        {
            float rayAngle = -viewAngle / 2 + angleBetweenRays * i;
            Vector3 rayDirection = Quaternion.Euler(0, rayAngle, 0) * transform.forward;

            if (Physics.Raycast(agenteNavMesh.transform.position, rayDirection, out hit, SightRange))
            {
                if (hit.transform.gameObject.CompareTag("JUGADOR"))
                {
                    agenteNavMesh.SetDestination(hit.transform.position);
                    following = true;
                    agenteNavMesh.speed = 4f;
                    agenteNavMesh.acceleration = 10f;
                    break;
                }
            }
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        if (Physics.BoxCast(transform.position + transform.forward, transform.localScale * 2f, transform.forward, out hit, transform.rotation, 100f))
        {
            Gizmos.DrawRay(transform.position, transform.forward * 100f);
            Gizmos.DrawWireCube(transform.position + transform.forward, transform.localScale);
        }
        else
        {
            Gizmos.DrawRay(transform.position, transform.forward * 100f);
            Gizmos.DrawWireCube(transform.position + transform.forward, transform.localScale);
        }
    }

    // Método adicional para evitar colisiones con el jugador
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("JUGADOR"))
        {
            // Detener al guardián para evitar empujar al jugador
            agenteNavMesh.isStopped = true;
            Debug.Log("Jugador capturado");
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("JUGADOR"))
        {
            // Permite que el guardián se mueva nuevamente
            agenteNavMesh.isStopped = false;
        }
    }
}
