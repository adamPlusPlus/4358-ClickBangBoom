using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class DoorTrigger: MonoBehaviour {
  public Door doorObject;
  private int state;             
  public float openOffset;
  public float openTime;
  public float openAmount;

  private const int
    CLOSED = 0,
    OPEN = 1,
    OPENING = 2,
    CLOSING = 3;

  public void FixedUpdate() {
    switch(state) {
    case CLOSED:          // closed
    case OPEN: break;     // open
    case OPENING:         // opening
      if(openAmount < 1.0) {
        openAmount += 1.0f / openTime * Time.fixedDeltaTime;
      }
      else {
        openAmount = 1.0f;
        state = OPEN;
      }
      UpdateDoorPosition();
      break;
    case CLOSING:         // closing
      if(openAmount > 0)
        openAmount -= 1.0f / openTime * Time.fixedDeltaTime;
      else {
        openAmount = 0;
        state = CLOSED;
      }
      UpdateDoorPosition();
      break;
    }
  }

  public void OnTriggerEnter(Collider other) {
    if(other.CompareTag("Player")) {
      if(doorObject.locked) {
        if(other.GetComponent<PlayerInventory>().keys.Contains(doorObject.lockId)) {
          other.GetComponent<PlayerInventory>().keys.Remove(doorObject.lockId);
          doorObject.locked = false;
        }
      }
      if(!doorObject.locked)
        state = OPENING;
    }
  }

  public void OnTriggerExit(Collider other) {
    if(other.CompareTag("Player"))
      state = CLOSING;
  }

  private void UpdateDoorPosition() {
    doorObject.transform.localPosition = new Vector3(openOffset * openAmount, 0, 0); 
  }
}
