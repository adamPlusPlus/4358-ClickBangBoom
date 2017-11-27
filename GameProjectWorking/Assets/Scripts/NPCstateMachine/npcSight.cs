using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcSight : MonoBehaviour {
    [SerializeField]
    private npc NPC;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            NPC.target = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            NPC.target = null;
        }
    }

}
