using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* This implementation of a melee weapon is rather ugly. If anyone can fix it, please do.
 * Problems:
 * I was unable to find a way to make the dagger work as a physical weapon, so this script 
 * basically treats the dagger like a projectile that doesn't move. Each stab is instantiated,
 * so it isn't attached to the player. If the player moves too fast, then he moves away from 
 * a floating dagger (until the dagger is destroyed by time).
 * 
 * For these reasons, the player cannot move faster than the dagger's destroy time, which is a huge 
 * problem.
 * 
 * This is not an adequate way to implement melee weapons. Please help improve it.
 */

public class Dagger : MonoBehaviour {

    public GameObject stab;
    private float coolDown = 0.2f;
    private float nextHit;

    // Use this for initialization
    void Start()
    {
    }


    // Update is called once per frame
    void LateUpdate()
    {
        if (Input.GetMouseButtonDown(1) && Time.time > nextHit)
        {
            GameObject stabbing = Instantiate(stab, transform.position, transform.rotation);
            Destroy(stabbing, 0.05f);
            nextHit = Time.time + coolDown;
        }
    }

}

