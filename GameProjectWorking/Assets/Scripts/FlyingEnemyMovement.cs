using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FlyingEnemyMovement : MonoBehaviour {

    Transform target;
    int MoveSpeed = 15;
    int MinDist = 30;
    private Vector3 startPosition;
    private Animator anim;
    // Use this for initialization
    void Start()
    {
        //position wgere we will return after player run far enough
        startPosition = transform.position;
        //finding player
        target = GameObject.FindGameObjectWithTag("Player").transform;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
       
        if (this.GetComponent<Health>().health > 0) {
            Vector3 targetPostition = new Vector3(target.position.x,
                                           target.position.y - 90,
                                           target.position.z);
            transform.LookAt(targetPostition);

            if (Vector3.Distance(transform.position, target.position) < MinDist)
            {
                anim.SetBool("IsFlying", true);
                transform.position = Vector3.MoveTowards(transform.position, target.position, MoveSpeed * Time.deltaTime);

            } else
            {

                //going back to the nest
                Vector3 initialPosition = new Vector3(startPosition.x,
                                           startPosition.y - 90,
                                           startPosition.z);
                transform.LookAt(initialPosition);
                transform.position = Vector3.MoveTowards(transform.position, startPosition, (MoveSpeed + 2) * Time.deltaTime);
                anim.SetBool("IsFlying", false);
            }

        }
      

    }
}
 

