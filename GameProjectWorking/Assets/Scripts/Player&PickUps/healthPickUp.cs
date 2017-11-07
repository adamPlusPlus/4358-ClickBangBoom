using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour {

    public int heal = 20;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
        {
            if(other.GetComponent<PlayerHealth>().currentHealth< other.GetComponent<PlayerHealth>().startingHealth)
            {//won't pick up if player at full health
             other.GetComponent<PlayerHealth>().currentHealth += heal;
             Destroy(gameObject);
            }

        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
