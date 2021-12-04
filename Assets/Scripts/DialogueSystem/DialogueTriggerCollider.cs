using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerCollider : MonoBehaviour
{
    // Set this to the textbox you want to activate when a collision is dectected
    public GameObject TextBox;
    // Make sure to attach this script to a game object with a collider!
    private Collider2D getCollider;

    private void Start()
    {
        getCollider = GetComponent<Collider2D>();
    }

    private GameObject UIdialogue;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                gameObject.GetComponent<DialogueTrigger>().TriggerDialogue(); // Triggers dialogue that this gameObject is attached to
            }
        }        
        
    }
}
