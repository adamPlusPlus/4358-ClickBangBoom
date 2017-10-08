using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    public float speed = 5;
    private Rigidbody playerBody;

    private float horizontalMovement, verticalMovement;

    //everything here is used for character rotation
    private Vector3 mousePos;
    private Vector3 objectPos;
    private Transform target;
    private float angle;
    Animator anim;
    // Setting up the references.
    

 

    // Use this for initialization
    void Start()
    {
        playerBody = gameObject.GetComponent<Rigidbody>();
        target = gameObject.GetComponent<Transform>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //grab user input
        horizontalMovement = Input.GetAxis("Horizontal");
        verticalMovement = Input.GetAxis("Vertical");
        // Create a boolean that is true if either of the input axes is non-zero.
        bool walking = horizontalMovement != 0f || verticalMovement != 0f;
        // Tell the animator whether or not the player is walking.
        anim.SetBool("IsWalking", walking);
        //Set character rotation to follow on mouse click
        if (Input.GetMouseButton(0) || Input.GetMouseButtonDown(1))
        {
            mousePos = Input.mousePosition;
            mousePos.z = -(Camera.main.transform.position.y);
            objectPos = Camera.main.WorldToScreenPoint(target.position);
            mousePos.x = mousePos.x - objectPos.x;
            mousePos.y = mousePos.y - objectPos.y;
            angle = Mathf.Atan2(mousePos.x, mousePos.y) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(90, angle, 0));
        }
        if (Input.GetMouseButtonUp(0) || Input.GetMouseButtonUp(1))
        {
            transform.rotation = Quaternion.Euler(90,0,0);
        }
    }
    //
    void FixedUpdate()
    {
        //move using physics
        
        Vector3 move = new Vector3(horizontalMovement,0f,verticalMovement);
        
        playerBody.velocity = move * speed;
    }
}
