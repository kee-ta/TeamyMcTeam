using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Allows use of TextMeshProUGUI
using Ink.Runtime; // Allows use of Story
using UnityEngine.EventSystems; 

public class DialogueManager2 : MonoBehaviour
{
    [Header("Dialogue UI")] // Allows access to the dialoguePanel, can hide/show depending on if dialogue is playing
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText; // Allows access to dialogue text, so that can set it according to ink file content

    [Header("Choices UI")]
    [SerializeField] private GameObject[] choices; // Allows any number of choices

    private TextMeshProUGUI[] choicesText; // Keeps track of the text for each choice

    private Story currentStory; // Keeps track of current ink file to display
    
    private static DialogueManager2 instance;

    // Keeps track of whether the dialogue is currently playing
    public bool dialogueIsPlaying { get; private set; } // Only wants outside script to be able to read the value but unable to modify

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Found more than one Dialogue Manager in the scene");
        }
        instance = this; // Initialise instance
    }

    public static DialogueManager2 GetInstance()
    {
        return instance;
    }

    private void Start()
    {
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);

        choicesText = new TextMeshProUGUI[choices.Length];
        int index = 0;
        foreach (GameObject choice in choices)
        {
            choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }

    }

    private void Update() 
    {
        if (!dialogueIsPlaying) // Only want to update if dialogue is playing, return right away if dialogue isn't playing
        {
            return;
        }

        // Handle continuing to the next line in the next line when submit is pressed
        if (InputManager.GetInstance().GetSubmitPressed())
        {
            ContinueStory();
        }

    }

    // A method that enters dialogue mode, which can call from dialogue trigger script
    public void EnterDialogueMode(TextAsset inkJSON)
    {
        currentStory = new Story(inkJSON.text); // Set current story to new story
        dialogueIsPlaying = true;
        dialoguePanel.SetActive(true);

        ContinueStory();
    }

    private IEnumerator ExitDialogueMode()
    {
        yield return new WaitForSeconds(0.2f); // Wait for 0.2 seconds before continuing
        
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = ""; // Empty string for good measure
    }

    private void ContinueStory()
    {
        if (currentStory.canContinue) // Checks if there is dialogue to be played
        {
            // Set text for the current dialogue line
            dialogueText.text = currentStory.Continue(); // Gives the next line of dialogue

            // Display choices (if any) for this dialogue line
            DisplayChoices();

        }
        else
        {
            StartCoroutine(ExitDialogueMode()); // No more lines
        }
    }

    private void DisplayChoices()
    {
        List<Choice> currentChoices = currentStory.currentChoices;

        // Defensive check to make sure our UI can support the number of choices coming in
        if (currentChoices.Count > choices.Length)
        {
            Debug.LogError("More choices were given than the UI can support. Number of choices given: " + currentChoices.Count);
        }

        // Loop through all of our choice GameObject in the UI 
        // Display choices according to the currentChoices from the ink story
        int index = 0;

        // Enable and initialise the choices up the the amount of currentChoices from the ink story
        // Put our UI and currentChoices in sync
        foreach (Choice choice in currentChoices)
        {
            choices[index].SetActive(true); // Set choice UI GameObject index to be Active
            choicesText[index].text = choice.text; // Set UI text to be equal to choiceText
            index++; // Increment index
        }

        // Hide remaining choices in our UI
        for (int i = index; i < choices.Length; i++)
        {
            choices[i].gameObject.SetActive(false);
        }
    }

    // Sets first selected choice using a Coroutine
    private IEnumerable SelectFirstChoice()
    {
        EventSystem.current.SetSelectedGameObject(null); // Set event system current GameObject to be null
        yield return new WaitForEndOfFrame(); // Wait for end of the frame
        EventSystem.current.SetSelectedGameObject(choices[0].gameObject); // Set new selected GameObject, our first choice GameObject, 
    }

    // Informs our story object that a choice is selected
    public void MakeChoice(int choiceIndex)
    {
        currentStory.ChooseChoiceIndex(choiceIndex);
    }

}
