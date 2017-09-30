using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stab : MonoBehaviour {

    private int power = 1;

    void OnCollisionEnter2D(Collision2D collision)
    {//Player can touch the weapon without triggering collisions
        if (collision.gameObject.tag == "Player")
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>());
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag != ("Player"))
        {
            other.GetComponent<Health>().damage(power);
            Destroy(gameObject);
        }
    }
}
