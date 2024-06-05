using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class XenomorphController : MonoBehaviour
{
    public bool following = false;
    public GameObject player;
    private RaycastHit hit;
    public float viewAngleHorizontal = 90f; // Ángulo de visión horizontal.
    public float viewAngleVertical = 10f; // Ángulo de visión vertical.
    public float maxDistance = 80f; // La distancia máxima de visión.
    public float attackDistance = 10f;


    private Vector3 initialPosition; // La posición inicial del enemigo.
    private NavMeshAgent navMeshAgent; // El NavMeshAgent del enemigo.

    public Animator animator; 

    private void Start()
    {
        animator = GetComponent<Animator>(); // Obtiene el animator del enemigo 
        navMeshAgent = GetComponent<NavMeshAgent>(); // Obtiene el NavMeshAgent del enemigo.
        initialPosition = transform.position; // Guarda la posición inicial del enemigo.
        animator.SetTrigger("Idle"); // Activa la animación Idle
    }

    private void Update()
    {
        Chase(); // Llama al método 
    }

    void Chase() 
    {
        navMeshAgent.speed = 30f; // Velocidad del boss.
        int numRaysHorizontal = 100; // Número de rayos horizontales.
        int numRaysVertical = 20; // Número de rayos verticales.
        float angleBetweenRaysHorizontal = viewAngleHorizontal / numRaysHorizontal; // Ángulo entre rayos de forma horizontal.
        float angleBetweenRaysVertical = viewAngleVertical / numRaysVertical; // Ángulo entre rayos de forma vertical.

        for (int i = 0; i < numRaysHorizontal; i++) // Loop que hace los rayos horizontale
        {
            for (int j = 0; j < numRaysVertical; j++) // Loop que hace los rayos verticales 
            {
                float rayAngleHorizontal = -viewAngleHorizontal / 2 + angleBetweenRaysHorizontal * i; // Ángulo entre rayos de forma horizontal.
                float rayAngleVertical = -viewAngleVertical / 2 + angleBetweenRaysVertical * j; // Ángulo entre rayos de forma vertical.
                Vector3 rayDirection = Quaternion.Euler(rayAngleVertical, rayAngleHorizontal, 0) * transform.forward; // Le da dirección a la visión del boss. 

                float distance = maxDistance; // Todos los rayos tienen la misma longitud.

                if (Physics.Raycast(navMeshAgent.transform.position, rayDirection, out hit, distance)) // Si el boss activa su rango de visión...
                {
                    if (hit.transform.gameObject.CompareTag("JUGADOR")) // Si el raycast choca con el jugador...
                    {
                        navMeshAgent.SetDestination(hit.transform.position);
                        following = true; // Activa la variable 
                        navMeshAgent.speed = 30f; // La velocidad del boss
                        navMeshAgent.acceleration = 10f; // La aceleración del boss

                        // Si el jugador está dentro del rango de ataque, activa la animación de ataque.
                        if (Vector3.Distance(transform.position, player.transform.position) <= attackDistance)
                        {
                            animator.SetTrigger("Attack"); // Se activa la animación de atacar.
                        }
                        else // Si no, activa la animación "BossRun".
                        {
                            animator.SetTrigger("BossRun"); // Se activa la animación de correr.
                        }

                        return; // Salimos de la función tan pronto como encontramos al jugador.
                    }
                }
            }
        }

        // Si el jugador no está en el rango de visión, el enemigo regresa a su posición inicial.
        if (following && Vector3.Distance(transform.position, player.transform.position) > maxDistance)
        {
            navMeshAgent.SetDestination(initialPosition); // El boss se dirige a su posición inicial.
            following = false; // Se cambia de valor a la variable.
            animator.SetTrigger("BossRun"); // Se activa la animación de correr. 
        }

        // Si el enemigo ha llegado a su posición inicial, activa la animación "Idle".
        if (Vector3.Distance(transform.position, initialPosition) <= 0.5f)
        {
            animator.SetTrigger("Idle"); // Se activa la animación Idle
        }
    }

    /*void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        int numRaysHorizontal = 100; // Número de rayos horizontales.
        int numRaysVertical = 20; // Número de rayos verticales.
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