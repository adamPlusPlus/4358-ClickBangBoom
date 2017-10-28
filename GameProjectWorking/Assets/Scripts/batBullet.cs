using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class batBullet : MonoBehaviour {

    int destroyTime = 100;
    int power = 5;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
        destroyTime -= 1; 
        transform.Translate(new Vector3(0, 0, 0.5f));
        if (destroyTime <= 0)
            Destroy(gameObject);
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
        {
            other.GetComponent<PlayerHealth>().TakeDamage(power);
            Destroy(gameObject);
        }
    }
}
