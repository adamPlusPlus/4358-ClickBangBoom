using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogeToRecrute : MonoBehaviour {
    public int availableRecrutes = 1;
    public bool GuiOn;
    public GUISkin dialogeForRecruting;
    public GUIText yourText;
    public string Text = "To recrute press E";
    public Rect BoxSize = new Rect(0, 0, 200, 100);
    GameObject recrute;
    // Use this for initialization
    // if this script is on an object with a collider display the Gui
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GuiOn = true;
        }
    }


    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            GuiOn = false;
        }
    }

    void OnGUI()
    {

        if (dialogeForRecruting != null)
        {
            GUI.skin = dialogeForRecruting;
        }

        if ((GuiOn == true) && (availableRecrutes>0))
        {
            // Make a group on the center of the screen
            GUI.BeginGroup(new Rect((Screen.width - BoxSize.width) / 2, (Screen.height - BoxSize.height) / 2, BoxSize.width, BoxSize.height));
            // All rectangles are now adjusted to the group. (0,0) is the topleft corner of the group.

            GUI.Label(BoxSize, Text);

            // End the group we started above. This is very important to remember!
            GUI.EndGroup();

        }


    }
    void Update()
    {
        if (Input.GetKey(KeyCode.E)&& (availableRecrutes>0))
        {
            //yourText = GetComponent<GUIText>();
            availableRecrutes = availableRecrutes - 1;
            recrute = GameObject.FindGameObjectWithTag("Recrute");
            recrute.GetComponent<FriendlyAIMovement>().recruted = true;
            GuiOn = false;

        }
    }
}
