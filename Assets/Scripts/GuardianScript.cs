using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;

public class GuardianScript : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject destination;
    public int counter = 0;
    private Vector3[] positionArray = new[] {new Vector3(-0.15f, 0.21f, 0.99f), new Vector3(14.45f, 0.21f, 6.83f), new Vector3(6.08f, 0.21f, -12.79f) };
    

    void Start()
    {
        agent.destination = destination.transform.position;
        
    }



    private void OnTriggerEnter(Collider other)
    {
        if(counter >= 3)
        {
            counter = 0;
        }
        destination.transform.position = positionArray[counter];
        counter++;

    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = destination.transform.position;
    }
}
