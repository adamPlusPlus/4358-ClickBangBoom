using System;
using UnityEngine;

public class DelayedBomb: Bomb {
  public float blastDelay;
  private float blastTime;

  public void Awake() {
    blastTime = Time.time + blastDelay;
  }

  public void Update() {
    if(Time.time >= blastTime)
      Explode();
  }
}
