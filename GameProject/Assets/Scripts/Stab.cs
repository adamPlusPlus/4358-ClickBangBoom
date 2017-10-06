using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stab : MonoBehaviour {

    private int power = 1;

    void OnCollisionEnter(Collision collision)
    {//Player can touch the weapon without triggering collisions
        if (collision.gameObject.tag == "Player")
            Physics.IgnoreCollision(collision.gameObject.GetComponent<Collider>(), gameObject.GetComponent<Collider>());
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag ==("Enemy"))
        {
            other.GetComponent<Health>().damage(power);
            Destroy(gameObject);
        }
    }
}
