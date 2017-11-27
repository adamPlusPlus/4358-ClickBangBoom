using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcPatrol : INPCState {

    private npc NPC;
    private float patrolTimer;

    public void Enter(npc npc)
    {
        NPC = npc;
    }

    public void Execute()
    {
        Patrol();
        NPC.Move();

        //if(playerSpeak) change to interactState 
    }

    public void Exit()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet" || other.gameObject.tag == "Dagger")
        {
            //flee
        }
    }

    private void Patrol()
    {
        NPC.anim.SetBool("IsMoving", true);

        patrolTimer += Time.deltaTime;

        if (patrolTimer >= NPC.patrolTime)
        {
            NPC.ChangeState(new npcIdle());
        }
    }
}
