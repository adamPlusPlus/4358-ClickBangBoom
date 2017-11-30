using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickUp : MonoBehaviour
{

    public int increase = 10;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        //Not very convinent nor efficient. (Will probably fix if we have enough weapons)
        if (other.tag == "Player")
        {
            if(other.transform.GetChild(0).gameObject.activeInHierarchy)
                other.GetComponentInChildren<Gun>().ammo += increase;
            else if (other.transform.GetChild(1).gameObject.activeInHierarchy)
                other.GetComponentInChildren<PiercingGun>().ammo += increase;
            else if (other.transform.GetChild(2).gameObject.activeInHierarchy)
                other.GetComponentInChildren<BombGun>().ammo += increase;
            Destroy(gameObject);
        }
    }
}
