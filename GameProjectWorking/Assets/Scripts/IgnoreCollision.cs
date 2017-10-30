using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//In case you want player/enemy to ignore something

public class IgnoreCollision : MonoBehaviour {

    [SerializeField]
    private Collider other;

    private void Awake()
    {
        Physics.IgnoreCollision(GetComponent<Collider>(), other, true);
    }
}
