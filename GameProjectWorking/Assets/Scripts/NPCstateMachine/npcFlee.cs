using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcFlee : INPCState
{
    private npc NPC;
    private float retreatTimer;
    private float retreatDuration = 6;

    public void Enter(npc npc)
    {
        NPC = npc;
    }

    public void Execute()
    {
        NPC.anim.SetBool("IsRunning", true);
        Retreat();
    }

    public void Exit()
    {

    }

    public void OnTriggerEnter(Collider other)
    {

    }

    public void Retreat()
    {
        if (NPC.target != null)
        {
            Vector3 dir = NPC.transform.position - NPC.player.GetComponent<Transform>().position;
            dir.y = 0;
            NPC.transform.rotation = Quaternion.LookRotation(dir);
        }
        NPC.transform.Translate(Vector3.forward * 10.0f * Time.deltaTime);

        retreatTimer += Time.deltaTime;

        if (retreatTimer >= retreatDuration)
        {
            NPC.anim.SetBool("IsRunning", false);
            NPC.ChangeState(new npcIdle());
        }

    }

}
