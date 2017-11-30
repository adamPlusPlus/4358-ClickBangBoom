using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogeToRecrute : MonoBehaviour {
    public int availableRecrutes = 1;
    public bool GuiOn;
    public Dialogue dialogue;

    GameObject recrute;
    GameObject recruteHealthUI;
    // Use this for initialization
    // if this script is on an object with a collider display the Gui

    void OnTriggerEnter(Collider other)
    {
        if ((other.tag == "Player")&& (availableRecrutes > 0))
        {
            GuiOn = true;
            TriggerDialogue();
        }
    }


    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            FindObjectOfType<DialogueManager>().EndDialogue();
            GuiOn = false;

        }
    }

    //locating dialogue manager
    public void TriggerDialogue()
    {
        
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);

    }

   
    public void HireRecrutieMedic()
    {
        if ((availableRecrutes>0) && (GuiOn == true))
        {
            //yourText = GetComponent<GUIText>();
            availableRecrutes = availableRecrutes - 1;
            recrute = GameObject.FindGameObjectWithTag("Recrute");
            recrute.GetComponent<FriendlyAIMovement>().recruted = true;
            recrute.GetComponent<FriendlyAIMovement>().medic = true;
            GameObject gameOverParent = GameObject.Find("canvas_HUD");
            GameObject gameOver = gameOverParent.transform.Find("RecruteHealthUI").gameObject;
            gameOver.SetActive(true);
            //recrute.gameObject.tag = "Player";
            FindObjectOfType<DialogueManager>().EndDialogue();
            GuiOn = false;


        }
    }

    public void HireRecrutieKiller()
    {
        if ((availableRecrutes > 0) && (GuiOn == true))
        {
            //yourText = GetComponent<GUIText>();
            availableRecrutes = availableRecrutes - 1;
            recrute = GameObject.FindGameObjectWithTag("Recrute");
            recrute.GetComponent<FriendlyAIMovement>().recruted = true;
            recrute.GetComponent<FriendlyAIMovement>().medic = false;
            GameObject gameOverParent = GameObject.Find("canvas_HUD");
            GameObject gameOver = gameOverParent.transform.Find("RecruteHealthUI").gameObject;
            gameOver.SetActive(true);
            //recrute.gameObject.tag = "Player";
            FindObjectOfType<DialogueManager>().EndDialogue();
            GuiOn = false;


        }
    }
}
