using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class batBullet : MonoBehaviour {

    //Used for batEnemy's projectile and for Vatgan's Axe throw. Can generally be used for any enemy's forward projectile

   public  int destroyTime = 100;
   public int power = 5;
    public float speed = 1;//how fast the projectile flies

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
        destroyTime -= 1; 
        transform.Translate(new Vector3(0, 0, 0.5f*speed));
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
