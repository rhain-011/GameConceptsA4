using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemyAI : MonoBehaviour {


    private Rigidbody myRb;
    public float moveSpeed;

    public PlayerController target;

	// Use this for initialization
	void Start () {
        target = FindObjectOfType<PlayerController>(); // find targets, 1 target for now
        myRb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(target.transform.position);
	}

    void FixedUpdate()
    {
        myRb.velocity = (transform.forward * moveSpeed);
    }
}
