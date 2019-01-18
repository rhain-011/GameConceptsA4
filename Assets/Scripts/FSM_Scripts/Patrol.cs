using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : NPCBaseFSM
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
    //List<Waypoint> patrolPoints;
    GameObject[] patrolPoints; // array of waypoints

    int currentPatrolIndex;
    bool isTravelling;
    bool isWaiting;
    bool patrolForward;
    float waitTimer;

    private void Awake()
    {
        patrolPoints = GameObject.FindGameObjectsWithTag("waypoint");
    }

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        

        // checks if gameobject has a NavMeshAgent attached to it
        if (agent == null)
        {
            Debug.LogError("The Nav Mesh Agent component is not attached to " + NPC.name);
        }
        else
        {
            if (patrolPoints != null && patrolPoints.Length >= 2)
            {
                currentPatrolIndex = 0;
                Setdestination();
            }
        }

    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (isTravelling && agent.remainingDistance <= 1.0f)
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

    //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    private void Setdestination()
    {
        if (patrolPoints != null)
        {
            Vector3 targetDestination = patrolPoints[currentPatrolIndex].transform.position;
            agent.SetDestination(targetDestination);
            isTravelling = true;
        }
    }


    // select a new patrol point in the list but a smmal probabability for the agent to move forward or backwards.
    private void ChangePatrolPoint()
    {
        if (UnityEngine.Random.Range(0.0f, 1.0f) <= changeDestinationProb)
        {
            patrolForward = !patrolForward;
        }

        // checks if currentpatrolindex is greater than the amount patrol points in the list
        // resets  back to zero
        if (patrolForward)
        {
            currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
        }
        else
        {
            if (--currentPatrolIndex < 0)
            {
                currentPatrolIndex = patrolPoints.Length - 1;
            }
        }
    }
}