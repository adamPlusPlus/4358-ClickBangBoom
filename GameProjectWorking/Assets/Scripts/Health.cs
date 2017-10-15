using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Enemy Health Script

public class Health : MonoBehaviour {

    public int health;//how many hits before it dies
    public int scoreValue = 10;
    private Animator anim;

    // Use this for initialization
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    public void damage(int weaponPower)//assuming weaponPower is positive
    {
        health -= weaponPower;
       // gameObject.GetComponent<Animation>().Play("testEnemyHit");//Very specific to testEnemy; comment out for others
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (health <= 0) //handles death
        {
            // Find and disable the Nav Mesh Agent.
            GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
            GetComponent<EnemyAttack>().enabled = false;
            GetComponent<Collider>().enabled = false;
            anim.SetTrigger("die");
            Destroy(gameObject, 5.0f);
            ScoreManager.score += scoreValue;
        }
    }
}
