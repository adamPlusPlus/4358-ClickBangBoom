using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Enemy Health Script

public class Health : MonoBehaviour {

    public int health;//how many hits before it dies
    public int defense;//how much it takes away from bullet's pierce
    public int scoreValue = 10;
    public bool underAttack = false;
    private Animator anim;
    //item drop
    public bool drop = false;
    public float dropRate = 0;//between 0 and 1
    public int size = 0;//size of the drops array
    public GameObject[] drops;
    private bool alreadyDrop=false;
    float timerUnderAttack;
    // Use this for initialization
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    public void damage(int weaponPower)//assuming weaponPower is positive
    {
        health -= weaponPower;
        underAttack = true;
        timerUnderAttack = 0f;
        if (health <= 0)
        {
            ScoreManager.score += scoreValue;
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        //not under attack if not getting any damage in certan time frame
        timerUnderAttack += Time.deltaTime;
        if (timerUnderAttack >= 10f)
        {
            underAttack = false;
        }
        if (health <= 0) //handles death
        {
            // Find and disable the Nav Mesh Agent.
            GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
            GetComponent<EnemyAttack>().enabled = false;
            GetComponent<Collider>().enabled = false;
            anim.SetTrigger("die");
            Destroy(gameObject, 5.0f);

            if(drop&&Random.value<dropRate&&!alreadyDrop)
            {
                int i = (int) Mathf.Floor(Random.value * size);
                Vector3 pos = transform.position;
                pos.y = 0.2f;
                Instantiate(drops[i], pos, Quaternion.Euler(90,0,0) );
            }
            alreadyDrop = true;
        }
    }
}
