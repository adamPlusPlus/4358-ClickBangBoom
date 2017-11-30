using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : IEnemyState
{
    private enemy enemy;
    private float patrolTimer;
    //private float patrolDuration=10;

    public void Enter(enemy enemy)
    {
        this.enemy = enemy;
        enemy.nav.isStopped = false;
    }

    public void Execute()
    {
        //Debug.Log("In Patrol State");
        Patrol();

        enemy.Move();

        if (enemy.target != null)
        {
            if (enemy.GetComponent<Health>().health < 4)
            {
                enemy.ChangeState(new RetreatState());
            }
            else
                enemy.ChangeState(new RangedState());
        }
    }

    public void Exit()
    {
        //enemy.ani.SetBool("IsMoving", false);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet" || other.gameObject.tag == "Dagger")
        {
            enemy.target = enemy.player;
        }

        //if (other.gameObject.tag != "Player"&& other.gameObject.tag!="Bullet" && other.gameObject.tag != "Dagger") ;
        //enemy.hitEdge = !enemy.hitEdge;//TESTING purposes only
    }

    public void OnTriggerStay(Collider other)
    {

    }

    private void Patrol()
    {
        enemy.ani.SetBool("IsMoving", true);

        patrolTimer += Time.deltaTime;

        if (patrolTimer >= enemy.patrolTime)
        {
            enemy.ChangeState(new IdleState());
        }
    }
}
