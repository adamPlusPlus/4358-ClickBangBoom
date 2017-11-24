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

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerHealth = player.GetComponent<PlayerHealth>();
        //enemyHealth = GetComponent<EnemyHealth>();
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {

        if (playerHealth.currentHealth < 90)//when player in danger running faster to help
        {
            nav.speed = initialSpeed * 5;
        }
        else
        {
            nav.speed = initialSpeed;
        }
        if (recruted==true){
            nav.SetDestination(player.position);
        }
         
        if ((playerHealth.currentHealth <= 90)&& (recruted == true))
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
