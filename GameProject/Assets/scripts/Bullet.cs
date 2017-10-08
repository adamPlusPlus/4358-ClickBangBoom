﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public int power=1;

    void OnTriggerEnter(Collider target)
    {
        if(target.CompareTag("Enemy"))
        {
            target.GetComponent<Health>().damage(power);
            //camera shakes when bullet hits
            Camera.main.GetComponent<CameraShake>().enabled = true;
        }
        //bullet is destroyed when in contact with anything besides player, ground, or itself
        if (!target.CompareTag("Player")&&!target.CompareTag("Ground")&&!target.CompareTag("Bullet"))
            Destroy(gameObject);
    }
}