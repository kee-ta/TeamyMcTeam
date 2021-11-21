using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopTriggerCollider2 : MonoBehaviour {

    [SerializeField] private UI_Shop_2 uiShop;

    private void SetUpShop(){
        
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        Debug.Log("Entered Shop Area");
        IShopCustomer shopCustomer = collider.GetComponent<IShopCustomer>();
        if (shopCustomer != null) {
            Debug.Log("Showing Shop");
            uiShop.Show(shopCustomer);
            SetUpShop();
        }
    }

    private void OnTriggerExit2D(Collider2D collider) {
         Debug.Log("Left Shop Area");
        IShopCustomer shopCustomer = collider.GetComponent<IShopCustomer>();
        if (shopCustomer != null) {
            uiShop.Hide();
        }
    }

}
