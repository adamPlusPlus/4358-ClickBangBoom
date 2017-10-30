using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

//Prototype ranged weapon 
public class Gun : MonoBehaviour
{
    // GUN
    public float reloadTime;
    private float nextFire;
    public float destroyTime;//amount of time before bullet is destroyed (simulates weapon range)
    public float speed = 30f;
    public GameObject bullet;

    public int ammo = 30;
    public Text ammoCount;

    private Vector3 startPosition;//bullet starts from where gun is located
    private Vector3 direction;
    Animator anim;

    private Light gunLight;
    private AudioSource gunFire;
    // Use this for initialization
    void Start()
    {
        anim = GetComponentInParent<Animator>();
        gunLight = GetComponent<Light>();
        gunFire = GetComponent<AudioSource>();
        ammoCount.GetComponent<Text>().text = "Ammo: " + ammo;
    }

    void shoot()
    {
        //fires bullet
        if (ammo > 0)
        {
            GameObject shot = Instantiate(bullet, startPosition, Quaternion.Euler(90, 0, 0));
            Camera.main.GetComponent<CameraShake>().enabled = true;
            anim.SetTrigger("fire");
            gunFire.Play();
            shot.GetComponent<Rigidbody>().velocity = (direction).normalized * speed;
            ammo--;
            Destroy(shot, destroyTime);//bullet flies for destroyedTime seconds, then it goes "out of range"
        }
    }

    // Update is called once per frame
    void Update()
    {
        ammoCount.GetComponent<Text>().text = "Ammo: " + ammo;


        /*if (Input.GetMouseButton(1))
        {
            //set the direction for the bullet/projectile (follows the mouse)
            startPosition = GetComponent<Transform>().position;
            Vector3 mousePosition = Input.mousePosition;
           // mousePosition.z = -transform.position.y;
            mousePosition.z = 1 * (Camera.main.transform.position.y);
            Vector3 target = Camera.main.ScreenToWorldPoint(mousePosition);
            direction = (target - startPosition).normalized;

            if (Input.GetButtonDown("Fire1") && Time.time > nextFire)
             {
                 shoot();
                 nextFire = Time.time + reloadTime;
             }
        }*/

        if (Input.GetButton("Fire1") && Time.time > nextFire)
            anim.SetBool("aim", true);
        if (Input.GetButtonUp("Fire1") && Time.time > nextFire)
        {

            anim.SetBool("aim", false);

            startPosition = GetComponent<Transform>().position;
            Vector3 mousePosition = Input.mousePosition;
            // mousePosition.z = -transform.position.y;
            mousePosition.z = 1 * (Camera.main.transform.position.y);
            Vector3 target = Camera.main.ScreenToWorldPoint(mousePosition);
            direction = (target - startPosition).normalized;

            shoot();
            nextFire = Time.time + reloadTime;
        }
    }
}
