using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShopTriggerCollider : MonoBehaviour
{
    public GameObject PlayerShopCanvas;

    private IShopCustomer shopCustomer1;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Entered Shop Area");

        IShopCustomer shopCustomer = collider.GetComponent<IShopCustomer>();
        shopCustomer1 = shopCustomer;

        if (shopCustomer != null)
        {
            PlayerController.instance.PromptActivate();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            PlayerShopCanvas.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        Debug.Log("Left Player Shop Area");

        IShopCustomer shopCustomer = collider.GetComponent<IShopCustomer>();
        if (shopCustomer != null)
        {
            PlayerController.instance.PromptDeactivate();
            PlayerShopCanvas.SetActive(false);
        }
    }

}
