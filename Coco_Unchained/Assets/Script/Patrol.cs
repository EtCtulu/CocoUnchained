using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrol : MonoBehaviour
{
    
    public Transform[] moveSpots;
    public int destinationPoint=0;
    private NavMeshAgent agent;

    public float minRemainingDistance=0.5f;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        agent.autoBraking = false;
        GoToNextPoint();
    }

    // Update is called once per frame
    void Update()
    {
        if(!agent.pathPending&& agent.remainingDistance < minRemainingDistance)
        {
            GoToNextPoint();
        }
    }

    void GoToNextPoint()
    {
        if (moveSpots.Length == 0)
        {
            return;
        }
        agent.destination = moveSpots[destinationPoint].position;
        destinationPoint = (destinationPoint + 1) % moveSpots.Length;   
    }

}
