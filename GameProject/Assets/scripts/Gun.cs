using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

    public float reloadTime;
    private float nextFire;
    public float destroyTime;//amount of time before bullet is destroyed (simulates weapon range)
    public float speed;
    public GameObject bullet;
    private Vector2 startPosition;//bullet starts from where gun is located

    // Use this for initialization
    void Start ()
    {
       
	}
	
	// Update is called once per frame
	void Update ()
    {
       
        if (Input.GetButtonDown("Fire1")&&Time.time> nextFire)
        {
            //set the direction for the bullet/projectile (follows the mouse)
            startPosition = GetComponent<Transform>().position;
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = -1*(Camera.main.transform.position.z);
            Vector2 target = Camera.main.ScreenToWorldPoint(mousePosition);
            Vector2 direction = target - startPosition;
            direction.Normalize();
            //fires bullet
            GameObject shot=Instantiate(bullet, startPosition, Quaternion.identity);
            shot.GetComponent<Rigidbody2D>().velocity = direction * speed;

            Destroy(shot, destroyTime);//bullet flies for destroyedTime seconds, then it goes "out of range"
            nextFire = Time.time + reloadTime;
        }
	}
}
