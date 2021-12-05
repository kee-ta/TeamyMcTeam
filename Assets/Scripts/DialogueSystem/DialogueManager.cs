using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public AudioSource TypeSound;

    public Text nameText;
    public Text dialogueText;

    public Animator animator;

    public GameObject Character;
    
    // A variable that keeps track of all the sentences in our current dialogue
    private Queue<string> sentences;


    void Start()
    {
        TypeSound = GetComponent<AudioSource>();
        sentences = new Queue<string>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            DisplayNextSentence(); 
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("IsOpen", true);

        nameText.text = dialogue.name;

        // Still needs to load in all the sentences
        sentences.Clear(); // First, clear all the sentences that were there from the previous conversation

        // Goes through all of the strings in our dialogue.sentences[] 
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence); // Adds sentence to queue
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            sentences.Clear();
            DisplayNextSentence(); // Display next sentence only when spacebar is pressed
        }

        else if (Input.GetKeyDown(KeyCode.C))
        {
            EndDialogue(); // End dialogue when C is pressed
        }

    }
    
    public void DisplayNextSentence()
    {
        // Check if there are more sentences in the queue
        if (sentences.Count == 0) // Reach the end of the queue
        {
            EndDialogue();
            return;
        }

        // if we still have sentences left to say, wants to get the next sentences in the queue
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        TypeSound.Play(); // Plays sound at the start

        dialogueText.text = "";

        // Loops through all the characters in our sentence
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return -100; // Speed of the typing effect
        }

        TypeSound.Stop(); // Stops the sound when the text stop animating
        
    }

    void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
    }

}
