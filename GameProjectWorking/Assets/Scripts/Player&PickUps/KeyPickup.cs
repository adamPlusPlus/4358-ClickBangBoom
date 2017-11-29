using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class KeyPickup: MonoBehaviour {
  public int lockId;

  public void OnTriggerEnter(Collider other) {
    if(other.tag=="Player") {
      other.GetComponent<PlayerInventory>().keys.Add(lockId);
      Destroy(gameObject);
    }
  }
}
