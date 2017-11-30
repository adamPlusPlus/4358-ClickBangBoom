using System;
using System.Collections.Generic;
using UnityEngine;

public class Door: MonoBehaviour {
  public bool locked;
  public int lockId;

  /*
  public void OnCollisionEnter(Collision collision) {
    if(locked && collision.collider.CompareTag("Player")) {
      if(inventory.keys.Contains(lockId)) {
        inventory.keys.Remove(lockId);
        locked = false;
      }
    }
  }*/
}