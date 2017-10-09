using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This is a very simple health script. Damage relies on number of hits (so everything related to damage/attack power uses int).

public class Health : MonoBehaviour {

    public int health;//how many hits before it dies
    public int scoreValue = 10;

    public void damage(int weaponPower)//assuming weaponPower is positive
    {
        health -= weaponPower;
        gameObject.GetComponent<Animation>().Play("testEnemyHit");//Very specific to testEnemy; comment out for others
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (health <= 0) //handles death
        {
            // Find and disable the Nav Mesh Agent.
            GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
            Destroy(gameObject);
            ScoreManager.score += scoreValue;
        }
    }
}
