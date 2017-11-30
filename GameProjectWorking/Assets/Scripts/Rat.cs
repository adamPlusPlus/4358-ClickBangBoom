using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rat : MonoBehaviour {

    public int speed = 5;
    public GameObject player;
    bool run = false;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {

        GetComponentInChildren<Animator>().SetBool("IsRunning", false);

		if(GetComponent<Health>().underAttack)
        {
            StartCoroutine(Run());
        }
	}

    IEnumerator Run()
    {
        Debug.Log("in coroutine");
        yield return new WaitForSeconds(0.1f);

        GetComponentInChildren<Animator>().SetBool("IsRunning", true);
        float timePassed = 0;

        Vector3 dir = transform.position - player.GetComponent<Transform>().position;
        dir.y = 0;
        transform.rotation = Quaternion.LookRotation(dir);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        while (timePassed < 3)
        {
            // Code to go left here
            timePassed += Time.deltaTime;

            yield return null;
        }
    }



}
