using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcIdle : INPCState
{
    private npc NPC;
    private float idleTimer;

    public void Enter(npc npc)
    {
        this.NPC = npc;
        NPC.anim.SetBool("IsMoving", false);
    }

    public void Execute()
    {
        Idle();

        //if(playerSpeak) change to dialoguestate or something...
    }

    public void Exit()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet" || other.gameObject.tag == "Dagger")
        {
            //go to flee state
        }
    }

    private void Idle()
    {
        idleTimer += Time.deltaTime;

        if (idleTimer >= NPC.idleTime && NPC.num != -1)
        {
            NPC.ChangeState(new npcPatrol());
        }
    }
}
