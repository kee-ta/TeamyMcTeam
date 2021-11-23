using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopTriggerCollider1 : MonoBehaviour {

    [SerializeField] private UI_Shop_1 uiShop;
    private IShopCustomer shopCustomer1;
    private bool canShow = false;
    private void OnTriggerEnter2D(Collider2D collider) {
        Debug.Log("Entered Shop Area");
        canShow = true;
        IShopCustomer shopCustomer = collider.GetComponent<IShopCustomer>();
        shopCustomer1 = shopCustomer;
        if (shopCustomer != null) {
            PlayerController.instance.PromptActivate();
        }
    }

    private void Update(){
        if(Input.GetKeyDown(KeyCode.C) && canShow){
            uiShop.Show(shopCustomer1);
            PlayerController.instance.PromptDeactivate();
            
        }
    }

    private void OnTriggerExit2D(Collider2D collider) {
        Debug.Log("Left Shop Area");
        canShow = false;
        IShopCustomer shopCustomer = collider.GetComponent<IShopCustomer>();
        if (shopCustomer != null) {
            PlayerController.instance.PromptDeactivate();
            uiShop.Hide();
        }
    }

}

