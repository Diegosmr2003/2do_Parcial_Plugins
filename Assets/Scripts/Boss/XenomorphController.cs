using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class XenomorphController : MonoBehaviour
{
    public bool following = false;
    public GameObject player;
    private RaycastHit hit;
    public float viewAngleHorizontal = 90f; // �ngulo de visi�n horizontal.
    public float viewAngleVertical = 10f; // �ngulo de visi�n vertical.
    public float maxDistance = 80f; // La distancia m�xima de visi�n.
    public float attackDistance = 10f;


    private Vector3 initialPosition; // La posici�n inicial del enemigo.
    private NavMeshAgent navMeshAgent; // El NavMeshAgent del enemigo.

    public Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>(); // Obtiene el NavMeshAgent del enemigo.
        initialPosition = transform.position; // Guarda la posici�n inicial del enemigo.
        animator.SetTrigger("Idle");
    }

    private void Update()
    {
        Chase();
    }

    void Chase()
    {
        navMeshAgent.speed = 30f;
        int numRaysHorizontal = 100; // N�mero de rayos horizontales.
        int numRaysVertical = 20; // N�mero de rayos verticales.
        float angleBetweenRaysHorizontal = viewAngleHorizontal / numRaysHorizontal;
        float angleBetweenRaysVertical = viewAngleVertical / numRaysVertical;

        for (int i = 0; i < numRaysHorizontal; i++)
        {
            for (int j = 0; j < numRaysVertical; j++)
            {
                float rayAngleHorizontal = -viewAngleHorizontal / 2 + angleBetweenRaysHorizontal * i;
                float rayAngleVertical = -viewAngleVertical / 2 + angleBetweenRaysVertical * j;
                Vector3 rayDirection = Quaternion.Euler(rayAngleVertical, rayAngleHorizontal, 0) * transform.forward;

                float distance = maxDistance; // Todos los rayos tienen la misma longitud.

                if (Physics.Raycast(navMeshAgent.transform.position, rayDirection, out hit, distance))
                {
                    if (hit.transform.gameObject.CompareTag("JUGADOR"))
                    {
                        navMeshAgent.SetDestination(hit.transform.position);
                        following = true;
                        navMeshAgent.speed = 30f;
                        navMeshAgent.acceleration = 10f;

                        // Si el jugador est� dentro del rango de ataque, activa la animaci�n de ataque.
                        if (Vector3.Distance(transform.position, player.transform.position) <= attackDistance)
                        {
                            animator.SetTrigger("Attack");
                        }
                        else // Si no, activa la animaci�n "BossRun".
                        {
                            animator.SetTrigger("BossRun");
                        }

                        return; // Salimos de la funci�n tan pronto como encontramos al jugador.
                    }
                }
            }
        }

        // Si el jugador no est� en el rango de visi�n, el enemigo regresa a su posici�n inicial.
        if (following && Vector3.Distance(transform.position, player.transform.position) > maxDistance)
        {
            navMeshAgent.SetDestination(initialPosition);
            following = false;
            animator.SetTrigger("BossRun");
        }

        // Si el enemigo ha llegado a su posici�n inicial, activa la animaci�n "Idle".
        if (Vector3.Distance(transform.position, initialPosition) <= 0.5f)
        {
            animator.SetTrigger("Idle");
        }
    }

    /*void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        int numRaysHorizontal = 100; // N�mero de rayos horizontales.
        int numRaysVertical = 20; // N�mero de rayos verticales.
        float angleBetweenRaysHorizontal = viewAngleHorizontal / numRaysHorizontal;
        float angleBetweenRaysVertical = viewAngleVertical / numRaysVertical;

        for (int i = 0; i < numRaysHorizontal; i++)
        {
            for (int j = 0; j < numRaysVertical; j++)
            {
                float rayAngleHorizontal = -viewAngleHorizontal / 2 + angleBetweenRaysHorizontal * i;
                float rayAngleVertical = -viewAngleVertical / 2 + angleBetweenRaysVertical * j;
                Vector3 rayDirection = Quaternion.Euler(rayAngleVertical, rayAngleHorizontal, 0) * transform.forward;

                float distance = maxDistance; // Todos los rayos tienen la misma longitud.

                Gizmos.DrawRay(navMeshAgent.transform.position, rayDirection * distance);
            }
        }
    }*/
}