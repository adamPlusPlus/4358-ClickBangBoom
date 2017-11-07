using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public int power=1;
    public Gun gun;

    public void Start() {
    }

    void OnTriggerEnter(Collider target)
    {
        if(target.CompareTag("Enemy"))
        {
            //Debug.Log("HIT");
            Health targetHealth = target.GetComponent<Health>();
            int damage = targetHealth.damage(power);
            gun.OnHit(target, damage);
            
        }
        if(target.CompareTag("Wall")) {
          Destroy(gameObject);
        }
        //bullet is destroyed when in contact with anything besides player, ground, or itself
        /*else if (!(target.CompareTag("Player") || target.CompareTag("Ground") || target.CompareTag("Bullet"))) {
            Destroy(gameObject);
        } */
    }
}
