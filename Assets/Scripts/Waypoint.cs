using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// Used to visulized  waypoint locations.
/// For debugging only.
/// 
/// </summary>
public class Waypoint : MonoBehaviour {

    [SerializeField]
    protected float debugDrawRadius = 1.0f;

    public virtual void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, debugDrawRadius);
    }
	
}
