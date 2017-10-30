using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class character : MonoBehaviour {

    public Animator ani { get; set; }

    [SerializeField]
    protected float speed;

   // [SerializeField]
   // protected int health;

   // public abstract bool isDead { get; }

    public bool Attack { get; set; }
    
	public virtual void Start ()
    {
        ani = GetComponentInChildren<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /*public abstract IEnumerator TakeDamage();

    public virtual void OnTriggerEnter(Collider other)
    {
        //not sure since other health function already exists
    }*/
}
