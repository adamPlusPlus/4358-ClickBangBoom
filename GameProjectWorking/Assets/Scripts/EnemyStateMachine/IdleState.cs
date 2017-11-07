using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IEnemyState
{
    private enemy enemy;

    private float idleTimer;
    private float idleDuration=5;//stay in idle state for 5 sec

    public void Enter(enemy enemy)
    {
        this.enemy = enemy;
        enemy.ani.SetBool("IsMoving", false);
    }

    public void Execute()
    {
        //Debug.Log("In Idle State");
        Idle();

        if(enemy.target!=null)
        {
            enemy.ChangeState(new PatrolState());
        }
    }

    public void Exit()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Bullet")
        {
            enemy.target = enemy.player; 
        }
    }

    private void Idle()
    {
        //enemy.ani.SetBool("IsIdle", true);

        idleTimer += Time.deltaTime;

        if(idleTimer>=idleDuration)
        {
            enemy.ChangeState(new PatrolState());
        }
    }
}
