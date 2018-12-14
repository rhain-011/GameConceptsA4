using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour {

    public bool isFiring;
    public float bulletSpeed;
    public ProjectileController bullet;

    public float timeBetweenShots;
    private float shotCounter;

    public Transform firePoint;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
        if (isFiring)
        {
            shotCounter -= Time.deltaTime;
            if(shotCounter <= 0.0f)
            {
                shotCounter = timeBetweenShots;
                ProjectileController newProjectile = Instantiate(bullet, firePoint.position, firePoint.rotation) as ProjectileController;
                newProjectile.speed = bulletSpeed;
            }
        }

	}
}
