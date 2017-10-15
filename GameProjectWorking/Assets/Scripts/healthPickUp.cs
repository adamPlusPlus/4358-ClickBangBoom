using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthPickUp : MonoBehaviour {

    public int heal = 20;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
        {
            other.GetComponent<PlayerHealth>().currentHealth += heal;
            Destroy(gameObject);
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
