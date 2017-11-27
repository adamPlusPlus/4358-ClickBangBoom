using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcInteract : INPCState
{
    private npc NPC;
    private int hit = 0;

    public void Enter(npc npc)
    {
        this.NPC = npc;
        NPC.anim.SetBool("IsStill", true);
    }

    public void Execute()
    {
        LookAtTarget();
        //Interact();
        if(NPC.target==null)
        {
            NPC.ChangeState(new npcIdle());
        }
    }

    public void Exit()
    {
        NPC.anim.SetBool("IsStill", false);
    }

    public void OnTriggerEnter(Collider other)
    {
        /*if (other.gameObject.tag == "Bullet" || other.gameObject.tag == "Dagger")
        {
            hit++;
            if (hit % 2 == 0 && hit != 0)
                NPC.ChangeState(new npcFlee());
        }*/
    }

    public void LookAtTarget()
    {
        if (NPC.target != null && Vector3.Distance(NPC.transform.position, NPC.target.transform.position) > 0.5)
        {
            NPC.transform.LookAt(NPC.target.transform);
        }

    }
}
