using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;

    public Animator animator;
    
    //Keeps track of all the sentences in our current dialogue
    private Queue<string> sentences; 

    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("IsOpen", true);
        
        nameText.text = dialogue.name;

        sentences.Clear(); // Clears all the sentences from the previous conversations

        foreach(string sentence in dialogue.sentences) // Loops through all the sentences in our dialogue and display them
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();

    }

    public void OnMouseDown()
    {
        DisplayNextSentence();
    }

    public void DisplayNextSentence() // End conversation if no more sentences left to say
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue(); // Sentences left to say
        StopAllCoroutines(); // Make sure TypeSentence is stopped 
        StartCoroutine(TypeSentence(sentence));
    }
    
    IEnumerator TypeSentence(string sentence) // Automatically type sentences 
    {
        dialogueText.text = "";

        // Loops through all the single characters in sentence
        foreach (char letter in sentence.ToCharArray()) // ToCharArray() converts string to character array
        {
            dialogueText.text += letter;
            yield return null; 
        }

    }

    void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
    }


}
