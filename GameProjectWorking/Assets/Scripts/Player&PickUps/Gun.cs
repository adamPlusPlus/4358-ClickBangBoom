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
    public GameObject damageDisplay;

    public AudioClip plinkSound, damageSound;
    public AudioSource bulletSfx;
    public int power;

    public int ammo = 30;
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

    void shoot(Vector3 target)
    {
        //fires bullet
        if (ammo > 0)
        {
            Vector3 direction = (target - transform.position).normalized;
            GameObject shot = Instantiate(bullet, transform.position, Quaternion.Euler(90, 0, 0));
            shot.GetComponent<Bullet>().power = this.power;
            shot.GetComponent<Bullet>().gun = this;

            Camera.main.GetComponent<CameraShake>().enabled = true;
            anim.SetTrigger("fire");
            gunFire.Play();
            shot.GetComponent<Rigidbody>().velocity = direction * speed + GetComponentInParent<Rigidbody>().velocity;
            ammo--;
            Destroy(shot, destroyTime);//bullet flies for destroyedTime seconds, then it goes "out of range"
        }
    }

    public void OnHit(Collider target, int damage) {
      GameObject damageNumber = Instantiate(damageDisplay, GameObject.Find("HUDCanvas").transform);
      Vector3 damageNumberPos = Camera.main.WorldToScreenPoint(target.transform.position);
      damageNumber.GetComponent<Text>().text = damage.ToString();
      damageNumber.transform.position = damageNumberPos;  
      Destroy(damageNumber, 1);

      /*if(damage == 0)
        bulletSfx.clip = plinkSound;
      else
        bulletSfx.clip = damageSound; */
      bulletSfx.Play();
    }

    // Update is called once per frame
    void Update()
    {
        ammoCount.GetComponent<Text>().text = "Ammo: " + ammo;

        if(Time.time >= nextFire) {
          if(Input.GetButton("Fire1")) {
            anim.SetBool("aim", true);
          }
          else if(Input.GetButtonUp("Fire1")) {
            anim.SetBool("aim", false);

            //set the direction for the bullet/projectile (follows the mouse)
            Vector3 target = Input.mousePosition;
            target.z = Camera.main.transform.position.y;
            target = Camera.main.ScreenToWorldPoint(target);
            shoot(target);
            nextFire = Time.time + reloadTime;
          }
        }
    }
}
