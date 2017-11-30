using System;
using UnityEngine;

public class Explosion: MonoBehaviour {
  public float blastRadius;
  public float blastDuration;
  private float alpha;

  public int basePower;

  public GameObject attacker;
  public bool hurtAttacker;  // Set if this explosion should hurt the attacker
  public bool hurtEnemies;  // Set if this explosion should hurt other enemies
  public bool hurtPlayer;  // Set if this explosion should hurt the player
  public bool hurtRecrutes;  // Set if this explosion should hurt "recrutes"

  public int GetBlastPowerAtPoint(Vector3 position) {
    float distance = (position - transform.position).magnitude;
    if(distance > blastRadius) distance = blastRadius;
    //float decayFactor = Mathf.Pow(1 - distance / blastRadius, 2);
    float decayFactor = blastRadius / (distance * (basePower-1) + blastRadius);
    float fDamage = basePower * decayFactor;
    return Mathf.RoundToInt(fDamage);
  }

  public void Awake() {
    alpha = 1.0f;
    transform.localScale = Vector3.one * blastRadius;
    Destroy(gameObject, blastDuration);
  }

  public void Update() {
    alpha -= 1.0f / blastDuration * Time.deltaTime;
    if(alpha < 0) alpha = 0;
    GetComponent<MeshRenderer>().material.color = new Color(1, 1, 1, alpha);
  }

  public void OnTriggerEnter(Collider other) {
    if(!hurtAttacker && attacker == other.gameObject) return;
    int damage = GetBlastPowerAtPoint(other.transform.position);

    if(hurtPlayer && other.CompareTag("Player")) {
      other.GetComponent<PlayerHealth>().TakeDamage(damage);
      Push(other);
    }
    else if(hurtEnemies && other.CompareTag("Enemy")) {
      other.GetComponent<Health>().damage(damage);
      Push(other); 
    }
    else if(hurtRecrutes && other.CompareTag("Recrute")) {
      other.GetComponent<RecruteHealth>().TakeDamage(damage);
      Push(other);
    }
  }
  
  public void Push(Collider other) {
     other.GetComponent<Rigidbody>().AddExplosionForce(basePower * 500, transform.position, blastRadius);
  }
}