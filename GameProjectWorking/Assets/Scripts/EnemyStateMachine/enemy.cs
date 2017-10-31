using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : character {

    private IEnemyState currentState;

    public GameObject target { get; set; }
    public GameObject player;

    public GameObject shot;//enemy ranged attack prefab

    //not sure how to control movement, just testing something:
    public bool hitEdge=true;
    public int move;
    
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

    public void Move()// just testing
    {
        //ani.SetBool("isMoving", true);

        if (move==0&&GetComponent<Health>().health>=0)
        {
            if (hitEdge)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 90, 0), 5 * Time.deltaTime);
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
            }
            else
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, -90, 0), 5 * Time.deltaTime);
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
            }
            
        }

    }
    
    public void ThrowAttack()
    {
        Instantiate(shot,transform.position,transform.rotation);
    }

    void OnTriggerEnter(Collider other)
    {
        currentState.OnTriggerEnter(other);
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
