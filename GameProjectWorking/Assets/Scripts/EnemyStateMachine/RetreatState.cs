using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetreatState : IEnemyState {

    private enemy enemy;
    private float retreatTimer;
    private float retreatDuration = 6;

    public void Enter(enemy enemy)
    {
        this.enemy = enemy;
    }

    public void Execute()
    {
        //Debug.Log("Running Away");
        enemy.ani.SetBool("IsRunning", true);
        Retreat();
    }

    public void Exit()
    {

    }

    public void OnTriggerEnter(Collider other)
    {

    }

    public void OnTriggerStay(Collider other)
    {
        
    }

    public void Retreat()
    {
        if(enemy.target!=null)
        enemy.transform.rotation = Quaternion.LookRotation(enemy.transform.position - enemy.player.GetComponent<Transform>().position);
        enemy.transform.Translate(Vector3.forward * 12.0f * Time.deltaTime);

        retreatTimer += Time.deltaTime;

        if (retreatTimer >= retreatDuration)
        {
            enemy.ani.SetBool("IsRunning", false);
            enemy.ChangeState(new IdleState());
        }
        /*Vector3 moveDirection = enemy.transform.position - enemy.player.GetComponent<Transform>().position;
       moveDirection.y = 0;
       enemy.GetComponent<CharacterController>().Move(moveDirection.normalized * 5 * Time.deltaTime);*/

    }
    
}
