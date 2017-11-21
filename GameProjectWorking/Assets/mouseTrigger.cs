using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class mouseTrigger : MonoBehaviour {

    handleCursor cursor;
    bool carrying;
    void Start(){
        cursor = GameObject.FindGameObjectWithTag("Main Camera").GetComponent<handleCursor>();
    }
	
    // Update is called once per frame
    void Update (){
        if (carrying)
        {
            cursor.SetInteractObject();
        }
	}

    void OnMouseEnter()
    {
        cursor.SetInteractFriendly();
    }

    void OnMouseExit()
    {
        cursor.SetMouse();
    }

    void OnMouseDown()
    {
        carrying = true;
    }

    void OnMouseUp()
    {
        carrying = false;
        cursor.SetMouse();
    }

}