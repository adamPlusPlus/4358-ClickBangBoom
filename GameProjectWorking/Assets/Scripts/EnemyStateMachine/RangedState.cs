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
        RangedAttack(); 

        Debug.Log("Target in Range");

        if(enemy.target!=null)
        {
            enemy.Move();
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

    }

    public void RangedAttack()
    {
        throwTimer += Time.deltaTime;
        enemy.ani.SetBool("IsMoving", true);

        if (throwTimer>=throwCoolDown)
        {
            canFire = true;
            throwTimer = 0;
        }

        if(canFire)
        {
            canFire = false;
            enemy.ani.SetBool("IsMoving", false);
            enemy.ani.SetTrigger("throw");
            enemy.ThrowAttack();
        }
    }
}
