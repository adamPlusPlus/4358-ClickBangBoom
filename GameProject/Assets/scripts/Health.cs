using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This is a very simple health script. Damage is not based on any formula; it just relies on number of hits.

public class Health : MonoBehaviour {

    public int health;//how many hits before it dies

    public void damage(int weaponPower)//assuming weaponPower is positive
    {
        health -= weaponPower;
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (health <= 0)//handles death
            Destroy(gameObject);
	}
}
