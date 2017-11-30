using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

//Prototype ranged weapon 
public class Gun : MonoBehaviour
{
    // GUN
    public float reloadTime;
    protected float nextFire;
    public float destroyTime;//amount of time before bullet is destroyed (simulates weapon range)
    public float shotSpeed = 30f;
    public GameObject bullet;

    public int ammo = 30;
    public int power = 1;
    public Text ammoCount;

    protected Animator anim;
    public string weaponName;

    protected Light gunLight;
    protected AudioSource gunFire;
    public LineRenderer gunLine;

    // Use this for initialization
    public virtual void Start()
    {
        anim = GetComponentInParent<Animator>();
        gunLight = GetComponent<Light>();
        gunLine = GetComponent<LineRenderer>();
        gunFire = GetComponent<AudioSource>();

        gunLine.enabled = false;
        UpdateAmmoText();
    }

    public void UpdateAmmoText() {
        ammoCount.GetComponent<Text>().text = "Ammo: " + ammo+"\n"+weaponName;
    }

    public virtual void ConfigureShot(GameObject shot) {
      shot.GetComponent<Bullet>().power = power;
    }


    public virtual void shoot(Vector3 start, Vector3 target)
    {
        //fires bullet
        if (ammo > 0) {
            Vector3 direction = (target - start).normalized;
            GameObject shot = Instantiate(bullet, transform.position, transform.rotation);
            //GameObject shot = Instantiate(bullet, start, Quaternion.Euler(90, 0, 0));
            Camera.main.GetComponent<CameraShake>().enabled = true;
            anim.SetTrigger("fire");
            gunFire.Play();
            ConfigureShot(shot);
            // shot.GetComponent<Rigidbody>().velocity = direction * shotSpeed;
            ammo--;
            Destroy(shot, destroyTime);//bullet flies for destroyedTime seconds, then it goes "out of range"
        }
    }

    // Update is called once per frame
    public virtual void Update()
    {
        UpdateAmmoText();
        if(Input.GetMouseButton(1)) {

            GetComponentInParent<PlayerControl>().anim.SetBool("aim", true);
            gunLine.enabled = true;

          if(Time.time > nextFire && Input.GetButtonDown("Fire1")) {

            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = Camera.main.transform.position.y;

            Vector3 startPosition = transform.position;
            Vector3 target = Camera.main.ScreenToWorldPoint(mousePosition);
            shoot(startPosition, target);
            nextFire = Time.time + reloadTime;
          }
        }
        if(Input.GetMouseButtonUp(1))
        {
            GetComponentInParent<PlayerControl>().anim.SetBool("aim", false);
            gunLine.enabled = false;
        }
        
        
    }
}
