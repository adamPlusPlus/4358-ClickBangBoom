﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public int power=1;
    public int piercePower = 0;
    public int speed = 1;

    void Update()
    {
        transform.Translate(new Vector3(0, 0, 0.5f * speed));
    }

    void OnTriggerEnter(Collider target)
    {
        if(target.CompareTag("Enemy"))
        {
            //Debug.Log("HIT");
            target.GetComponent<Health>().damage(power);
        }
        //bullet is destroyed when in contact with anything besides player, ground, or itself
        if (!target.CompareTag("Player")&&!target.CompareTag("Ground")&&!target.CompareTag("Bullet"))
            Destroy(gameObject);
    }
}
