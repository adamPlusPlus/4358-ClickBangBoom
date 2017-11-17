using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponControl : MonoBehaviour {

    public GameObject[] weapons;
   //private GameObject currentWeapon;
    public int howMany;
    private int weaponNumber = 0;//start with weapons[0]

	// Use this for initialization
	void Start () {

        //currentWeapon = weapons[0];
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Get Input From The Mouse Wheel
        // if mouse wheel gives a positive value add 1 to WeaponNumber
        // if it gives a negative value decrease WeaponNumber with 1
       
            if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            weaponNumber = (weaponNumber + 1)% howMany ;

            //Debug.Log("weaponNum: " + weaponNumber);
        }
           
            if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            weaponNumber = (weaponNumber - 1)% howMany;
            if (weaponNumber < 0)//not sure if this is the right logic
                weaponNumber *= -1;

            //Debug.Log("weaponNum: " + weaponNumber);
        }
        // currentWeapon = weapons[weaponNumber];

        //activate the current weapon, disable the rest

        for (int i=0;i<howMany;i++)
        {
            if(i!=weaponNumber)
            {
                weapons[i].SetActive(false);
            }
        }

        weapons[weaponNumber].SetActive(true);
    }
   
}
