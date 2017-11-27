using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface INPCState{

    void Execute();
    void Enter(npc npc);
    void Exit();
    //void OnTriggerStay(Collider other);
    void OnTriggerEnter(Collider other);
}
