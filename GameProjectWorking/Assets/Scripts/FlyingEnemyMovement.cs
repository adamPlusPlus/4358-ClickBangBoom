using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemyMovement : MonoBehaviour {

    Transform target;
    int moveSpeed = 10;
    int rotationSpeed = 5;
    Transform myTransform;
    // Use this for initialization
    void Awake()
    {
        myTransform = transform;
    }
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        //anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        float dist = Vector3.Distance(target.position, myTransform.position);
        Vector3 lookDir = target.position - myTransform.position;
        //lookDir.z=0;
        
        if (dist < 10)
        {

            myTransform.rotation = Quaternion.Slerp(myTransform.rotation, Quaternion.LookRotation(lookDir), rotationSpeed * Time.deltaTime);
            
            if (dist > 0.5)
            {
                myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;

            }
        }
    }
}
