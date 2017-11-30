using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//  Highlight player on minimap with blinking light
//  highlight objective on minimap with blinking light

public class MiniMap : MonoBehaviour {
    

    void Start(){
		
    }
	
    // Update is called once per frame
    void Update (){
        if(Input.GetKeyDown(KeyCode.M))
        {
            GetComponent<RawImage>().enabled = !GetComponent<RawImage>().enabled;
        }
	}
}