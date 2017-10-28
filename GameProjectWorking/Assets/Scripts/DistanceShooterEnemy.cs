using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceShooterEnemy : MonoBehaviour {

    public Transform spawnPoint;
    public Transform bullet;
    GameObject player;
    private float reloadTime=1.0f;
    private float nextFire;
    private int fireDistance = 15;
    private int fleeDistance = 5;
    private int speed = 9;
    Animator ani;

	// Use this for initialization
	void Start () {
        ani = GetComponentInChildren<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void Update ()
    {
        float playerDistance = Vector3.Distance(this.transform.position, player.GetComponent<Transform>().position);
        if(GetComponent<Health>().health > 0)
        transform.LookAt(player.transform);

        if (playerDistance<fireDistance&&Time.time>nextFire&&(GetComponent<Health>().health > 0))
        {
            //shoot
            Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);
            nextFire = Time.time + reloadTime;
            ani.SetTrigger("attack");
        }
        if (playerDistance < fleeDistance&&(GetComponent<Health>().health > 0))
        {
            //run away
            //Vector3 moveDirection = player.position- transform.position ;// run towards player
            Vector3 moveDirection =transform.position - player.GetComponent<Transform>().position ;
            moveDirection.y = 0;
            GetComponent<CharacterController>().Move(moveDirection.normalized * speed * Time.deltaTime);
            ani.SetBool("move", true);
        }
        else
            ani.SetBool("move", false);
	}
}
