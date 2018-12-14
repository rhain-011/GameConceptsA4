using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// Used to visulized  PowerUp locations.
/// For debugging only.
/// 
/// </summary>

public class PowerupSpawnPoint : MonoBehaviour {

    [SerializeField]
    protected float debugDrawRadius = 1.0f;

    public virtual void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, debugDrawRadius);
    }
}
