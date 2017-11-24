using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour {
    public Dialogue dialogue;
    public bool GuiOn;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") 
        {
            GuiOn = true;
            TriggerDialogue();
        }
    }



    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            FindObjectOfType<TutorialManager>().EndDialogue();
            GuiOn = false;

        }
    }

    //open dialogue
    public void TriggerDialogue()
    {
        FindObjectOfType<TutorialManager>().StartDialogue(dialogue);

    }
    // Update is called once per frame
    void Update () {
		
	}
}
