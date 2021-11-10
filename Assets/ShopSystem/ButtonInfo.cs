using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonInfo : MonoBehaviour
{
    public int ItemID;
    public Text PriceTxt;
    public Text QuantityTxt;
    public GameObject ShopManager;

    void Update()
    {
        PriceTxt.text = "Cost: $" + ShopManager.GetComponent<ShopManagerScript>().shopItems[2, ItemID].ToString();
        QuantityTxt.text = "x" + ShopManager.GetComponent<ShopManagerScript>().shopItems[3, ItemID].ToString();
    }
}
