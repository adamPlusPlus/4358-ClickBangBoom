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
    public float shotSpeed = 30f;
    public GameObject bullet;

    public int ammo = 30;
    public int power = 1;
    public Text ammoCount;

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

    void shoot(Vector3 start, Vector3 target)
    {
        //fires bullet
        if (ammo > 0) {
            Vector3 direction = (target - start).normalized;
            GameObject shot = Instantiate(bullet, start, Quaternion.Euler(90, 0, 0));
            Camera.main.GetComponent<CameraShake>().enabled = true;
            anim.SetTrigger("fire");
            gunFire.Play();
            /*if(shot.GetComponent<Bullet>())
              shot.GetComponent<Bullet>().power = power;*/
            shot.GetComponent<Rigidbody>().velocity = direction * shotSpeed;
            ammo--;
            Destroy(shot, destroyTime);//bullet flies for destroyedTime seconds, then it goes "out of range"
        }
    }

    // Update is called once per frame
    void Update()
    {
        ammoCount.GetComponent<Text>().text = "Ammo: " + ammo;

        if(Time.time > nextFire) {
          if(Input.GetButton("Fire1"))
            anim.SetBool("aim", true);
          else if(Input.GetButtonUp("Fire1")) {
            anim.SetBool("aim", false);
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = Camera.main.transform.position.y;

            Vector3 startPosition = transform.position;
            Vector3 target = Camera.main.ScreenToWorldPoint(mousePosition);
            shoot(startPosition, target);
            nextFire = Time.time + reloadTime;
          }
        }
        
        
    }
}
