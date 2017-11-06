﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyState
{
    void Execute();
    void Enter(enemy enemy);
    void Exit();
    void OnTriggerStay(Collider other);
    void OnTriggerEnter(Collider other);
}
