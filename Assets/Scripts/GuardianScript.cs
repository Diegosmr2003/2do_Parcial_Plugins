using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class GuardianScript : MonoBehaviour
{
    public Vector3[] puntosDeRecorrido = new Vector3[]
    {
        new Vector3(9.5f, 0.21f, 11.84f),
        new Vector3(14.68f, 0.21f, 6.86f),
        new Vector3(0.06f, 0.21f, -4.4f),
        new Vector3(6.55f, 0.21f, -13.05f),
        new Vector3(11.34f, 0.21f, -4.34f),
        new Vector3(13.11f, 0.21f, -13.05f)
    };

    private NavMeshAgent agenteNavMesh;
    private int indiceDestinoActual = 0;

    void Start()
    {
        agenteNavMesh = GetComponent<NavMeshAgent>();
        // Elige una posición aleatoria del arreglo como posición inicial
        int indicePosicionInicial = UnityEngine.Random.Range(0, puntosDeRecorrido.Length);
        transform.position = puntosDeRecorrido[indicePosicionInicial];

        // Inicia el recorrido con el primer punto de la lista
        if (puntosDeRecorrido.Length > 0)
        {
            agenteNavMesh.SetDestination(puntosDeRecorrido[indicePosicionInicial]);
            indiceDestinoActual = indicePosicionInicial;
        }
    }

    void Update()
    {
        // Verifica si el agente llegó a su destino actual
        if (!agenteNavMesh.pathPending && agenteNavMesh.remainingDistance < 0.1f)
        {
            // Avanza al siguiente destino en el recorrido
            SiguienteDestino();
        }
    }

    void SiguienteDestino()
    {
        // Selecciona aleatoriamente el próximo destino
        int nuevoIndice = UnityEngine.Random.Range(0, puntosDeRecorrido.Length);
        // Asegura que el nuevo índice no sea el mismo que el actual
        while (nuevoIndice == indiceDestinoActual)
        {
            nuevoIndice = UnityEngine.Random.Range(0, puntosDeRecorrido.Length);
        }
        // Establece el nuevo destino
        indiceDestinoActual = nuevoIndice;
        agenteNavMesh.SetDestination(puntosDeRecorrido[indiceDestinoActual]);
    }
}
