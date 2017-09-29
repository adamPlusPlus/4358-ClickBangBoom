using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{

    

    private Vector2 velocity;
    public float timeX, timeY;//set these to about 0.15 for smooth, fast camera following
    public GameObject subject;

    void start()
    {
        subject = GameObject.FindGameObjectWithTag("Player");
    }

    void FixedUpdate()
    {
        float posX = Mathf.SmoothDamp(transform.position.x, subject.transform.position.x, ref velocity.x, timeX);
        float posY = Mathf.SmoothDamp(transform.position.y, subject.transform.position.y, ref velocity.y, timeY);

        transform.position = new Vector3(posX, posY, transform.position.z);
    }
}