using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShopTriggerCollider : MonoBehaviour
{
    public GameObject PlayerShopCanvas;


    [SerializeField] private UI_Shop_2 uiShop;

    private IShopCustomer shopCustomer1;
    private bool canShow = false;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Entered Shop Area");
        canShow = true;
        IShopCustomer shopCustomer = collider.GetComponent<IShopCustomer>();
        shopCustomer1 = shopCustomer;
        if (shopCustomer != null)
        {
            PlayerController.instance.PromptDialogueActivate();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && canShow)
        {
            PlayerShopCanvas.SetActive(true);
            PlayerController.instance.PromptDialogueDeactivate();
        }
        if (Input.GetKeyDown(KeyCode.Q) && canShow)
        {
            PlayerController.instance.PromptDialogueDeactivate();
            gameObject.GetComponent<DialogueTrigger>().TriggerDialogue(); // Triggers dialogue that this gameObject is attached to
            PlayerController.instance.PromptActivate();
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        Debug.Log("Left Shop Area");
        canShow = false;
        IShopCustomer shopCustomer = collider.GetComponent<IShopCustomer>();
        if (shopCustomer != null)
        {
            PlayerController.instance.PromptDialogueDeactivate();
            PlayerController.instance.PromptDeactivate();
            PlayerShopCanvas.SetActive(false);
        }
    }

}
