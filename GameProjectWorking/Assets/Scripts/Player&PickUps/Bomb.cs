using System;
using System.Collections.Generic;
using UnityEngine;

public class Bomb: MonoBehaviour {
  public Explosion explosion;
  public float speed;

  public void Explode() {
    explosion.gameObject.SetActive(true);
    Destroy(gameObject, explosion.blastDuration);
  }
}