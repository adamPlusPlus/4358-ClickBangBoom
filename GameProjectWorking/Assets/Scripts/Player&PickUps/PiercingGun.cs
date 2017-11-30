using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PiercingGun : Gun {
  public int piercePower;

  public override void ConfigureShot(GameObject shot) {
    shot.GetComponent<PiercingBullet>().power = power;
    shot.GetComponent<PiercingBullet>().piercePower = piercePower;
  }
}
