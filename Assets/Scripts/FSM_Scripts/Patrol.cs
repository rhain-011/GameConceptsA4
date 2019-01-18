using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : NPCBaseFSM
{

    GameObject[] waypoints; // array of waypoints
    int currentWaypoint; // waypoint going to

    private void Awake()
    {
        waypoints = GameObject.FindGameObjectsWithTag("waypoint");
    }

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        currentWaypoint = Random.Range(0, waypoints.Length); // set destination into a a random waypoint

    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // returns if theres no waypoints
        if (waypoints.Length == 0) return;

        // distance of NPC in relation to current waypoint
        if (Vector3.Distance(waypoints[currentWaypoint].transform.position, NPC.transform.position) < accuracy)
        {
            currentWaypoint++;
            if (currentWaypoint >= waypoints.Length)
            {
                currentWaypoint = 0;
            }
        }
        
        //// rotate and move towards next waypoint
        //// direction where NPC is going
        //var direction = waypoints[currentWaypoint].transform.position - NPC.transform.position; 
        //// apply a rotation to the NPC to face the desired direction
        //NPC.transform.rotation = Quaternion.Slerp(NPC.transform.rotation, Quaternion.LookRotation(direction), rotSpeed * Time.deltaTime);
        //NPC.transform.Translate(0, 0, Time.deltaTime * speed);

    }

    //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
    
}