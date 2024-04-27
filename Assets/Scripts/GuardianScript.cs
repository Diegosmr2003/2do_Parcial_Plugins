using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class GuardianScript : MonoBehaviour
{
    // Define los tres posibles recorridos
    public Vector3[][] recorridos = new Vector3[][]
    {
        new Vector3[]
        {
        new Vector3(9.5f, 0.21f, 11.84f),
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
    public bool following = false;
    public GameObject player;
    private NavMeshAgent agenteNavMesh;
    private Vector3[] recorridoActual;
    private int indiceDestinoActual = 0;

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
        if (following == true) {
         //   agenteNavMesh.SetDestination(player.transform.position);

        }
        float SightRange = 50f;
        RaycastHit hit;
        if(Physics.BoxCast(agenteNavMesh.transform.position, agenteNavMesh.transform.localScale*2f, agenteNavMesh.transform.forward, out hit, agenteNavMesh.transform.rotation, SightRange))
        {
            if (hit.transform.gameObject.CompareTag("JUGADOR"))
            {
                //print("YA TE VI PERRO");
                agenteNavMesh.SetDestination(hit.transform.position);
                following = true;
                agenteNavMesh.speed = 7f;
            }
        }
    }
}