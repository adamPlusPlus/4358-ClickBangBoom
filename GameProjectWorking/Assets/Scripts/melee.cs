using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class melee : MonoBehaviour {

    public int power = 1;

    void Start()
    {
        gameObject.GetComponent<Collider>().enabled = false;
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0) && !Input.GetMouseButton(1))
        {
            gameObject.GetComponent<Collider>().enabled = true;
        }
        if(Input.GetMouseButtonUp(0))
        {
            gameObject.GetComponent<Collider>().enabled = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {//Player can touch the weapon without triggering collisions
        if (collision.gameObject.tag == "Player")
            Physics.IgnoreCollision(collision.gameObject.GetComponent<Collider>(), gameObject.GetComponent<Collider>());
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == ("Enemy"))
        {
            other.GetComponent<Health>().damage(power);
        }
    }
}
