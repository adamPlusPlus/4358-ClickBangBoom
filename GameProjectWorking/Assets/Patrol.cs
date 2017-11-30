using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour {

    public Transform[] points;
    private int destPoint = 0;
    private UnityEngine.AI.NavMeshAgent agent;
    GameObject player;
    Health myHealth;
    EnemyAttack attack;
    private Animator anim;

    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        attack = GetComponent<EnemyAttack>();
        myHealth = GetComponent<Health>();
        // Disabling auto-braking allows for continuous movement
        // between points (ie, the agent doesn't slow down as it
        // approaches a destination point).
        agent.autoBraking = false;

        GotoNextPoint();
    }


    void GotoNextPoint()
    {
        // Returns if no points have been set up
        if (points.Length == 0)
            return;

        // Set the agent to go to the currently selected destination.
        agent.destination = points[destPoint].position;

        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        destPoint = (destPoint + 1) % points.Length;
    }


    void Update()
    {
        if ((attack.playerInRange) || (attack.recruteInRange))
        {
            //anim.SetTrigger("attack");
        }
        //run away from player to the next way point
        if ((myHealth.health <= 5)&&(myHealth.underAttack==true))
        {
            //anim.SetBool("IsRunning", true);
            agent.SetDestination(points[destPoint].position);
        }
        //go towards player if under attack
        if ((myHealth.health > 5)&&(myHealth.underAttack==true))
        {
            agent.speed = 20;
            agent.SetDestination(player.transform.position);
            
        }
        else
        {
            if ((myHealth.underAttack == false))
            {
                agent.speed = 10;
            }
            // Choose the next destination point when the agent gets
            // close to the current one.
            if (!agent.pathPending && agent.remainingDistance < 1f)
                GotoNextPoint();
            //anim.SetBool("IsRunning", false);
        }

    }
}
