using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    private Vector3 velocity;
    public float timeX, timeY;//set these to about 0.15 for smooth, fast camera following
    public Transform subject;

  
    void FixedUpdate()
    {
        subject = GameObject.FindGameObjectWithTag("Player").transform;
        //float posX = Mathf.SmoothDamp(transform.position.x, subject.position.x, ref velocity.x, timeX);
        //float posZ = Mathf.SmoothDamp(transform.position.z, subject.position.z, ref velocity.z, timeY);
        
        transform.position = new Vector3(subject.position.x, 100f,subject.position.z);
    }
}