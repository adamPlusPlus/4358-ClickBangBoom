using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcPatrol : INPCState {

    private npc NPC;
    private float patrolTimer;
    private int hit = 0;

    public void Enter(npc npc)
    {
        NPC = npc;
    }

    public void Execute()
    {
        Patrol();
        NPC.Move();

        if(NPC.target.gameObject.tag=="Player")
        {
            NPC.ChangeState(new npcIdle());
        }
        //if(playerSpeak) change to interactState 
    }

    public void Exit()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet" || other.gameObject.tag == "Dagger")
        {
            hit++;
            if (hit % 2 == 0&&hit!=0)
                NPC.ChangeState(new npcFlee());
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
