using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Specifically for the VatganEnemy guy

public class enemy : character {

    private IEnemyState currentState;

    public GameObject target { get; set; }
    public GameObject player;
    public int power = 10;
    public bool melee;
    public bool passive;
    public float idleTime=5;
    public float patrolTime = 10;

    public GameObject shot;//enemy ranged attack prefab

    //patrol path using waypoints:
    public GameObject[] waypoints;
    public int num = 0;

    public float minDist;

    public bool rand = false;
    //public bool go = true;


    //not sure how to control movement, just testing something:
    //public bool hitEdge=true;
    //public int move;
    
	public override void Start ()
    {
        base.Start();
        ChangeState(new IdleState());
	}
	
	void Update ()
    {
        if(GetComponent<Health>().health > 0)//need to fix this
        {
            currentState.Execute();

            LookAtTarget();
        }

    }

    public void ChangeState(IEnemyState newState)
    {
        if (currentState!=null)
        {
            currentState.Exit();
        }

        currentState = newState;

        currentState.Enter(this);
    }

    public void LookAtTarget()
    {
        if (target!=null&& Vector3.Distance(transform.position, target.transform.position) > 0.3&& GetComponent<Health>().health>=4)
        {
            transform.LookAt(target.transform);
        }
        /*
        if (target != null && GetComponent<Health>().health < 4 && GetComponent<Health>().health > 0)
        {
            transform.LookAt(2*transform.position-target.transform.position);
        }*/
    }

    public void Move()
    {
        float dist = Vector3.Distance(gameObject.transform.position, waypoints[num].transform.position);

        if (target==null)
        {
            if (dist > minDist)
            {
                gameObject.transform.LookAt(waypoints[num].transform.position);
                gameObject.transform.position += gameObject.transform.forward * speed * Time.deltaTime;
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
        else
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

   /* public void Move()// just testing
    {
        //ani.SetBool("isMoving", true);

        if (move==0&&GetComponent<Health>().health>=0)
        {
            if (hitEdge)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, transform.rotation.y-90, 0), 5 * Time.deltaTime);
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
            }
            else
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, transform.rotation.y+90, 0), 5 * Time.deltaTime);
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
            }
            
        }

    }*/

    public void ThrowAttack()
    {
        if (shot != null)
            Instantiate(shot, transform.position, transform.rotation);
        else
            return;
    }

    void OnTriggerEnter(Collider other)
    {
        currentState.OnTriggerEnter(other);
    }

    void OnTriggerStay(Collider other)
    {
        currentState.OnTriggerStay(other);
    }

    /* public override IEnumerator TakeDamage()
     {
         //health-=some dmg;
         if(!isDead)
         {
             //ani.SetTrigger("damage");
         }
         else
         {
             ani.SetTrigger("die");
             yield return null;
         }
     }

     public override bool isDead
     {
         get
         {
             return health <= 0;
         }
     }*/
}
