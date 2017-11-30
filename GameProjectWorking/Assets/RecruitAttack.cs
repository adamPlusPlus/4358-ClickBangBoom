using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecruitAttack : MonoBehaviour{

    public GameObject attacker;
    private GameObject activeBomb;
    public int blastRadius;
    public int basePower;
    public int shotSpeed;
    public GameObject bullet;
    GameObject enem;
    
    bool inRange=false;


    void OnTriggerEnter(Collider other)
    {
        GameObject rec = GameObject.FindGameObjectWithTag("Recrute");
        if ((other.tag == "Enemy") && (!rec.GetComponent<FriendlyAIMovement>().medic))
        {
            
            inRange = true;
            enem = other.gameObject;
            //navigate tovards enemy and attack
            //nav.SetDestination(other.gameObject.transform.position);
        }
    }
    void OnTriggerExit(Collider other)
    {
        GameObject rec = GameObject.FindGameObjectWithTag("Recrute");
        if ((other.tag == "Enemy")&&(!rec.GetComponent<FriendlyAIMovement>().medic))
        {
            inRange = false;

        }
    }

    void Update()
    {
        if ((inRange)&&(enem.GetComponent<Health>().health>0))
        {
            Vector3 startPosition = transform.position;
            Vector3 target = enem.transform.position;
            transform.LookAt(enem.transform);
            shoot(startPosition, target);
        }
    }
    public void shoot(Vector3 start, Vector3 target)
    {
        if (!activeBomb)
        {
                
                Vector3 direction = (target - start).normalized;
            direction.y = 0;
                activeBomb = Instantiate(bullet, transform.position, transform.rotation);
                Camera.main.GetComponent<CameraShake>().enabled = true;
                //anim.SetTrigger("fire");
                Explosion explosion = activeBomb.GetComponentInChildren<Explosion>(true);
                explosion.basePower = basePower;
                explosion.blastRadius = blastRadius;
                explosion.attacker = attacker;
                activeBomb.GetComponent<Rigidbody>().velocity = direction * shotSpeed;

        }
        else
        {
            if (Vector3.Distance(activeBomb.transform.position, target)<5f)
            {
                activeBomb.GetComponent<Bomb>().Explode();
            }
            //activeBomb.GetComponent<Bomb>().Explode();
            //gunFire.Play();
            Destroy(activeBomb, 1f);
        }
        
    }
}
