using System;
using UnityEngine;
using UnityEngine.UI;


public class BombGun: Gun {
  public GameObject attacker;
  private GameObject activeBomb;
  public float blastRadius;

  public override void shoot(Vector3 start, Vector3 target) {
    if(!activeBomb) {
      if(ammo > 0) {
        Vector3 direction = (target - start).normalized;
        activeBomb = Instantiate(bullet, transform.position, transform.rotation);
        Camera.main.GetComponent<CameraShake>().enabled = true;
        anim.SetTrigger("fire");
        Explosion explosion = activeBomb.GetComponentInChildren<Explosion>(true);
        explosion.basePower = power;
        explosion.blastRadius = blastRadius;
        explosion.attacker = attacker;
        activeBomb.GetComponent<Rigidbody>().velocity = direction * shotSpeed;
        ammo--;
      }
    }
    else {
      activeBomb.GetComponent<Bomb>().Explode();
      gunFire.Play();
    }
  }

  public override void Update() {
    if(activeBomb && Input.GetMouseButtonDown(1)) {
      UpdateAmmoText();
      activeBomb.GetComponent<Bomb>().Explode();
      gunFire.Play();
      activeBomb = null;
    }
    else {
      base.Update();
    }
  }
}
