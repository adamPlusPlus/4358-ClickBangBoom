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
           other.GetComponentInChildren<Gun>().ammo += increase;
        }
    }
}
