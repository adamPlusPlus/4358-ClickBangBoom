using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySight : MonoBehaviour {
    [SerializeField]
    private enemy enemy;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
        {
            enemy.target = other.gameObject;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.tag=="Player")
        {
            enemy.target = null;
        }
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
