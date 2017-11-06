using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeState : IEnemyState
{
    private enemy enemy;

    public void Enter(enemy enemy)
    {
        this.enemy = enemy;
    }

    public void Execute()
    {
        Melee();

        //Debug.Log("In Melee State");
        if (enemy.target != null && Vector3.Distance(enemy.transform.position, enemy.target.GetComponent<Transform>().position) > 5.0f)
        {
            enemy.ChangeState(new RangedState());
        }
        else if(enemy.target==null)
        {
            enemy.ChangeState(new IdleState());
        }
    }

    public void Exit()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Player"&&enemy.GetComponent<Health>().health>0)
        {
            other.GetComponent<PlayerHealth>().TakeDamage(enemy.power);
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag=="Player")
        {
            other.GetComponent<PlayerHealth>().TakeDamage(enemy.power);
        }
    }

    private void Melee()
    {
        enemy.ani.SetTrigger("attack");
    }
}
