using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {
    private Queue<string> sentences;
    public Text dialogueText;

    public Animator animator;
	// Use this for initialization
	void Start () {
        sentences = new Queue<string>();	
	}
	
	public void StartDialogue(Dialogue dialogue)
    {
        //Debug.Log("Starting conversation with "+dialogue.playerName);
        animator.SetBool("IsOpen", true);
        sentences.Clear();
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

    }
    public void DisplayNextSentence ()
    {
        if (sentences.Count==0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
    }
    public void EndDialogue()
    {
        //Debug.Log("End of Conversation.");
        animator.SetBool("IsOpen", false);
    }
}
