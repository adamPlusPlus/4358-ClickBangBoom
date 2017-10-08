using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Prototype ranged weapon 
public class Gun : MonoBehaviour {
    // GUN
    public float reloadTime;
    private float nextFire;
    public float destroyTime;//amount of time before bullet is destroyed (simulates weapon range)
    public float speed = 60;
    public GameObject bullet;
    private Vector3 startPosition;//bullet starts from where gun is located
    Animator anim;
    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetButtonDown("Fire1") && Time.time > nextFire)
        {
            
            //set the direction for the bullet/projectile (follows the mouse)
            startPosition = GetComponent<Transform>().position;
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = -1 * (Camera.main.transform.position.y);
            Vector3 target = Camera.main.ScreenToWorldPoint(mousePosition);
            Vector3 direction = target - startPosition;
            //fires bullet
            direction.Normalize();
            GameObject shot = Instantiate(bullet, startPosition, Quaternion.Euler(90, 0, 0));
            shot.GetComponent<Rigidbody>().velocity = -(direction) * speed;

            Destroy(shot, destroyTime);//bullet flies for destroyedTime seconds, then it goes "out of range"
            nextFire = Time.time + reloadTime;
        }
    }
}
