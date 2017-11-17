using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PiercingGun : MonoBehaviour {

    // GUN
    public float reloadTime;
    private float nextFire;
    public float destroyTime;//amount of time before bullet is destroyed (simulates weapon range)
    public float shotSpeed = 30f;
    public GameObject bullet;

    public int ammo = 30;
    public int power = 1;
    public int piercePower = 5;
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
        ammoCount.GetComponent<Text>().text = "Ammo: " + ammo+"\nPiercing Gun";
    }

    void shoot(Vector3 start, Vector3 target)
    {
        //fires bullet
        if (ammo > 0)
        {
            Vector3 direction = (target - start).normalized;
            GameObject shot = Instantiate(bullet, start, Quaternion.Euler(90, 0, 0));
            Camera.main.GetComponent<CameraShake>().enabled = true;
            anim.SetTrigger("fire");
            gunFire.Play();
            shot.GetComponent<PiercingBullet>().power = power;
            shot.GetComponent<PiercingBullet>().piercePower = piercePower;
            shot.GetComponent<Rigidbody>().velocity = direction * shotSpeed;
            ammo--;
            Destroy(shot, destroyTime);//bullet flies for destroyedTime seconds, then it goes "out of range"
        }
    }

    // Update is called once per frame
    void Update()
    {
        ammoCount.GetComponent<Text>().text = "Ammo: " + ammo+"\nPiercing Gun";

        if (Input.GetMouseButton(1))
        {
            if (Time.time > nextFire && Input.GetButtonDown("Fire1"))
            {

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
