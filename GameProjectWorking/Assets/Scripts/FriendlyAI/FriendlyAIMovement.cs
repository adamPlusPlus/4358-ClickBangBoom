using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendlyAIMovement : MonoBehaviour {
    Transform player;
    private UnityEngine.AI.NavMeshAgent nav; //Reference to the nav mesh agent
    PlayerHealth playerHealth;
    private float initialSpeed  = 12;
    public bool recruted = false;
    float timer;
    public float timeBetweenHeals= 1f;
    public bool enemySighted = false;
    public bool medic = false;
    GameObject enem;


    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerHealth = player.GetComponent<PlayerHealth>();
       
        //enemyHealth = GetComponent<EnemyHealth>();
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }


    void OnTriggerEnter(Collider other)
    {
        if ((other.tag == "Enemy")&&!medic&& recruted)
        {
            enemySighted = true;
            enem = other.gameObject;
            //navigate tovards enemy and attack
            nav.SetDestination(other.gameObject.transform.position);
        }
    }


    void OnTriggerExit(Collider other)
    {
        if ((other.tag == "Enemy")&& !medic&&recruted)
        {
            // go towards player
            enemySighted = false;
            nav.SetDestination(player.position);

        }
    }

    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (enemySighted)
        {
            if (enem.GetComponent<Health>().health <=0)
            {
                enemySighted = false;
            }
            
        }
        if (playerHealth.currentHealth < 90)//when player in danger running faster to help
        {
            nav.speed = initialSpeed * 5;
        }
        else
        {
            nav.speed = initialSpeed;
        }
        if ((recruted==true)&&!enemySighted)
        {
            nav.SetDestination(player.position);
        }
         
        if ((playerHealth.currentHealth <= 90)&& (recruted == true)&&medic)
        {
            timer += Time.deltaTime;

            // If the timer exceeds the time between attacks, the player is in range and this enemy is alive...
            if (timer >= timeBetweenHeals) //&& enemyHealth.currentHealth > 0)
            {
                // ... heal.
                playerHealth.currentHealth = playerHealth.currentHealth + 1;
                timer = 0f;
            }
            
        }

    }
}
