using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float defaultMoveSpeed = 4.0f;
    public float moveSpeed = 4.0f;
    public Rigidbody rb;

    private Vector3 moveInput;
    private Vector3 moveVelocity;
    private Camera mainCamera; // main camera reference

    public GunController pGun;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        mainCamera = FindObjectOfType<Camera>(); // let mainCamera equals to object of type camera
        moveSpeed = defaultMoveSpeed;
	}
	
	// Update is called once per frame
	void Update () {
        // player input
        moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0.0f, Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput.normalized * moveSpeed;

        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;


        if (groundPlane.Raycast(cameraRay, out rayLength))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);
            //Debug.DrawLine(cameraRay.origin, pointToLook, Color.black); // TODO delete debug

            transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));

        }

        // gun firing
        if (Input.GetMouseButtonDown(0))
        {
            pGun.isFiring = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            pGun.isFiring = false;
        }
    }

    void FixedUpdate()
    {
        //rb.velocity = moveVelocity;
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }
}
