using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedState : IEnemyState
{
    private enemy enemy;

    private float throwTimer;
    private float throwCoolDown = 2;
    private bool canFire=true;

    public void Enter(enemy enemy)
    {
        this.enemy = enemy;
    }

    public void Execute()
    {
        enemy.ani.SetBool("IsMoving", true);

        RangedAttack(); 

        Debug.Log("Target in Range");

        if(enemy.target!=null&&Vector3.Distance(enemy.transform.position,enemy.target.GetComponent<Transform>().position)>0.5f&&enemy.GetComponent<Health>().health>=4)
        {
            enemy.Move();
        }
        else if(enemy.GetComponent<Health>().health<4)
        {
            enemy.ChangeState(new RetreatState());
        }
        else
        {
            enemy.ChangeState(new IdleState());
        }
    }

    public void Exit()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
            enemy.target = enemy.player;
    }

    public void RangedAttack()
    {
       throwTimer += Time.deltaTime;

        if (throwTimer>=throwCoolDown)
        {
            canFire = true;
            throwTimer = 0;
        }

        if(canFire)
        {
            canFire = false;
            enemy.ani.SetTrigger("throw");
            enemy.ThrowAttack();
        }
    }
}
