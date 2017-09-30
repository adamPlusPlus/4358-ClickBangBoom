using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public int power=1;

    void OnTriggerEnter2D(Collider2D target)
    {
        if(target.CompareTag("Enemy"))
        {
            target.GetComponent<Health>().damage(power);
        }
        if (!target.CompareTag("Player"))//bullet is destroyed when in contact with anything besides player
            Destroy(gameObject);
    }
}
