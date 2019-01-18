using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyPatrol : MonoBehaviour
{
    // dictates if agent waits on each waypoint
    [SerializeField]
    bool isPatrolWaiting;

    // wait time at each point
    [SerializeField]
    float totalWaitTime;

    // probabaility that the agent will change course
    [SerializeField]
    float changeDestinationProb;

    [SerializeField]
    List<Waypoint> patrolPoints;

    NavMeshAgent navMeshAgent;
    int currentPatrolIndex;
    bool isTravelling;
    bool isWaiting;
    bool patrolForward;
    float waitTimer;

    

    // Start is called before the first frame update
    void Start()
    {

        navMeshAgent = this.GetComponent<NavMeshAgent>();

        // checks if gameobject has a NavMeshAgent attached to it
        if (navMeshAgent == null)
        {
            Debug.LogError("The Nav Mesh Agent component is not attached to " + gameObject.name);
        }
        else
        {
            if(patrolPoints != null && patrolPoints.Count >= 2)
            {
                currentPatrolIndex = 0;
                Setdestination();
            }
        }
    }

    private void Setdestination()
    {
        if(waypoint != null)
        {
            Vector3 targetDestination = waypoint.transform.position;
            navMeshAgent.SetDestination(targetDestination);
        }
    }
}
