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
    public float speed = 60;
    public GameObject bullet;
    private Vector3 startPosition;//bullet starts from where gun is located
    public int ammo = 30;
    public Text ammoCount;
    Animator anim;
    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        ammoCount.GetComponent<Text>().text = "Ammo: " + ammo;
    }

    // Update is called once per frame
    void Update()
    {
        ammoCount.GetComponent<Text>().text = "Ammo: " + ammo;

        if (Input.GetMouseButton(1))
        {
            //set the direction for the bullet/projectile (follows the mouse)
            startPosition = GetComponent<Transform>().position;
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = -1 * (Camera.main.transform.position.y);
            Vector3 target = Camera.main.ScreenToWorldPoint(mousePosition);
            Vector3 direction = target - startPosition;
            if (Input.GetButtonDown("Fire1") && Time.time > nextFire)
            {
                //fires bullet
                direction.Normalize();
                if (ammo > 0)
                {
                    GameObject shot = Instantiate(bullet, startPosition, Quaternion.Euler(90, 0, 0));
                    Camera.main.GetComponent<CameraShake>().enabled = true;
                    shot.GetComponent<Rigidbody>().velocity = -(direction) * speed;
                    ammo--;
                    Destroy(shot, destroyTime);//bullet flies for destroyedTime seconds, then it goes "out of range"
                    nextFire = Time.time + reloadTime;
                }
            }
        }
    }
}
