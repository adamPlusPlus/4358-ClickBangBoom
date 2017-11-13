using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiercingBullet : MonoBehaviour {

    public int power = 1;
    public int piercePower = 5; //can go through enemies until their defenses add up to piercePower

    private void LateUpdate()
    {
        //Debug.Log("PiercePower= " + piercePower);
        if (piercePower <= 0)
            Destroy(gameObject);//bullet destroyed after enough enemy defense penetrates it
    }

    void OnTriggerEnter(Collider target)
    {
        if (target.CompareTag("Enemy"))
        {
            //Debug.Log("HIT");
            target.GetComponent<Health>().damage(power);
            piercePower -= target.GetComponent<Health>().defense;
        }
        //bullet is destroyed when in contact with anything besides player, ground, or itself
        if (!target.CompareTag("Player") && !target.CompareTag("Ground") && !target.CompareTag("Bullet")&&!target.CompareTag("Dagger")&&!target.CompareTag("Enemy"))
           Destroy(gameObject);
    }
    /*private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            piercePower -= other.GetComponent<Health>().defense;
        }
    }*/
}
