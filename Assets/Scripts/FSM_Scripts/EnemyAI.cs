using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

    Animator anim;
    public GameObject player;
    public GameObject bullet;
    public GameObject bulletSpawn;

    // spotlight
    public Light spotLight;
    public float viewDistance = 20.0f;
    public LayerMask viewMask;
    public float viewAngle;

    


    public GameObject GetPlayer()
    {
        return player;
    }

    void Fire()
    {
        GameObject b = Instantiate(bullet, bulletSpawn.transform.position, bulletSpawn.transform.rotation);
        b.GetComponent<Transform>().Translate(Vector3.forward * 10.0f * Time.deltaTime);
    }

    public void StopFiring()
    {
        CancelInvoke("Fire");
    }

    public void StartFiring()
    {
        InvokeRepeating("Fire", 0.5f, 0.5f);
    }


	// Use this for initialization
	void Start () {
  
        anim = GetComponent<Animator>();
        spotLight = transform.GetComponent<Light>();
        viewAngle = spotLight.spotAngle;
        
    }
	
	// Update is called once per frame
	void Update () {
        anim.SetFloat("distance", Vector3.Distance(transform.position, GetPlayer().transform.position));
        anim.SetBool("CanSeePlayer", CanSeePlayer());
	}


    public bool CanSeePlayer()
    {
        if (Vector3.Distance(transform.position, GetPlayer().transform.position) < viewDistance)
        {
            Vector3 dirToOpponent = (GetPlayer().transform.position - transform.position).normalized;
            float angleBetweenNPCandOpponent = Vector3.Angle(transform.forward, dirToOpponent);
            if (angleBetweenNPCandOpponent < viewAngle / 2f)
            {
                if (!Physics.Linecast(transform.position, GetPlayer().transform.position, viewMask))
                {
                    return true;
                }
            }
        }
        return false;
    }
}
