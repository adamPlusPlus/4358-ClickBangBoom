using UnityEngine;
using System.Collections;


public class EnemyAttack : MonoBehaviour
{
    public float timeBetweenAttacks = 0.5f;     // The time in seconds between each attack.
    public int attackDamage = 10;               // The amount of health taken away per attack.


    //Animator anim;                              // Reference to the animator component.
    GameObject player;
    GameObject recrute; // Reference to the player GameObject.
    PlayerHealth playerHealth;
    RecruteHealth recruteHealth;
    //EnemyHealth enemyHealth;                    // Reference to this enemy's health.
    bool playerInRange;                         // Whether player is within the trigger collider and can be attacked.
    bool recruteInRange;
    float timer;                                // Timer for counting up to the next attack.


    void Awake()
    {
        // Setting up the references.
        player = GameObject.FindGameObjectWithTag("Player");
        recrute = GameObject.FindGameObjectWithTag("Recrute");
        playerHealth = player.GetComponent<PlayerHealth>();
        recruteHealth = recrute.GetComponent<RecruteHealth>();
        //enemyHealth = GetComponent<EnemyHealth>();
        //anim = GetComponent<Animator>();
    }


    void OnTriggerEnter(Collider other)
    {
        // If the entering collider is the player...
        if (other.gameObject == player)
        {
            // ... the player is in range.
            playerInRange = true;
        }
        if  (other.gameObject == recrute)
        {
            // ... the player is in range.
            recruteInRange = true;
        }
        // if (other.tag == "Bullet")//For some reason,  bullets pierce through enemies
        // Destroy(other.gameObject);
    }


    void OnTriggerExit(Collider other)
    {
        // If the exiting collider is the player...
        if (other.gameObject == player) 
        {
            // ... the player is no longer in range.
            playerInRange = false;
        }
        if  (other.gameObject == recrute)
        {
            // ... the player is no longer in range.
            recruteInRange = false;
        }
    }


    void Update()
    {
        // Add the time since Update was last called to the timer.
        timer += Time.deltaTime;

        // If the timer exceeds the time between attacks, the player is in range and this enemy is alive...
        if (timer >= timeBetweenAttacks && playerInRange) //&& enemyHealth.currentHealth > 0)
        {
            // ... attack.
            Attack("player");
        }
        if (timer >= timeBetweenAttacks && recruteInRange) //&& enemyHealth.currentHealth > 0)
        {
            // ... attack.
            Attack("recrute");
        }
        // If the player has zero or less health...
        if (playerHealth.currentHealth <= 0)
        {
            // ... tell the animator the player is dead.
            //anim.SetTrigger("PlayerDead");

        }
    }


    void Attack(string str)
    {
        // Reset the timer.
        timer = 0f;

        // If the player has health to lose...
        if ((playerHealth.currentHealth > 0)&&(str=="player"))
        {
            // ... damage the player.
            playerHealth.TakeDamage(attackDamage);
        }
        if ((recruteHealth.currentHealth > 0)&&(str=="recrute"))
        {
            // ... damage the player.
            recruteHealth.TakeDamage(attackDamage);
        }
    }
}