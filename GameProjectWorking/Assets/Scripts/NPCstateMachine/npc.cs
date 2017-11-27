using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npc : MonoBehaviour {

    private INPCState currentState;

    public int speed = 5;
    public float idleTime = 5;
    public float patrolTime = 10;
    //patrol path using waypoints:
    public GameObject[] waypoints;
    public int num = -1;//by default, there is no movement
    public float minDist;
    public bool rand = false;

    public GameObject target;
    public GameObject player;
    public Animator anim;

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
        ChangeState(new npcIdle());
    }

    private void Update()
    {
        currentState.Execute();
    }

    public void Move()
    {
        if (num == -1)//no movement
        {
            return;
        }
        float dist = Vector3.Distance(gameObject.transform.position, waypoints[num].transform.position);

        if (dist > minDist)
        {
            Vector3 targetLocation = waypoints[num].transform.position;
            //targetLocation.y = 0;
            gameObject.transform.LookAt(targetLocation);

            Vector3 moveDirection = Vector3.forward;
            moveDirection.y = 0;
            transform.Translate(moveDirection * speed * Time.deltaTime);
            // gameObject.transform.position += gameObject.transform.forward * speed * Time.deltaTime;
        }
        else
        {
            if (!rand)
            {
                if (num + 1 == waypoints.Length)
                {
                    num = 0;
                }
                else
                {
                    num++;
                }
            }
            else
            {
                num = Random.Range(0, waypoints.Length);
            }
        }
    }

    public void ChangeState(INPCState newState)
    {
        if (currentState != null)
        {
            currentState.Exit();
        }

        currentState = newState;

        currentState.Enter(this);
    }

    void OnTriggerEnter(Collider other)
    {
        currentState.OnTriggerEnter(other);
    }
}
