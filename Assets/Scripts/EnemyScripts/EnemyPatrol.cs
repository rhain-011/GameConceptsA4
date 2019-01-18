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
    float totalWaitTime = 2.0f;

    // probabaility that the agent will change course
    [SerializeField]
    float changeDestinationProb = 0.1f;

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


    private void Update()
    {
        if (isTravelling && navMeshAgent.remainingDistance <= 1.0f)
        {
            isTravelling = false;

            if (isPatrolWaiting)
            {
                isWaiting = true;
                waitTimer = 0.0f;
            }
            else
            {
                ChangePatrolPoint();
                Setdestination();
            }
        }


        if (isWaiting)
        {
            waitTimer += Time.deltaTime;

            if (waitTimer >= totalWaitTime)
            {
                isWaiting = false;

                ChangePatrolPoint();
                Setdestination();
            }
        }
    }

    // sets the destination of the agent to go to
    private void Setdestination()
    {
        if (patrolPoints != null)
        {
            Vector3 targetDestination = patrolPoints[currentPatrolIndex].transform.position;
            navMeshAgent.SetDestination(targetDestination);
            isTravelling = true;
        }
    }


    // select a new patrol point in the list but a smmal probabability for the agent to move forward or backwards.
    private void ChangePatrolPoint()
    {
        if(UnityEngine.Random.Range(0.0f, 1.0f) <= changeDestinationProb)
        {
            patrolForward = !patrolForward;
        }

        // checks if currentpatrolindex is greater than the amount patrol points in the list
        // resets  back to zero
        if (patrolForward)
        {
            currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Count;
        }
        else
        {
            if(--currentPatrolIndex < 0)
            {
                currentPatrolIndex = patrolPoints.Count - 1;
            }
        }
    }
}
