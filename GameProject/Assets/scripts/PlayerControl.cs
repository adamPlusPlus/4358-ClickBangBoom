using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

    public float speed;
    private Rigidbody2D playerBody;

    private float horizontalMovement, verticalMovement;

    // Use this for initialization
    void Start ()
    {
        playerBody = gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
	//read user input
        horizontalMovement = Input.GetAxis("Horizontal");
        verticalMovement = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        //move using physics
        Vector2 move = new Vector2(horizontalMovement, verticalMovement);
        playerBody.velocity = move * speed;
    }
}
