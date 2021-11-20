using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Shop : MonoBehaviour
{
    private Transform container;
    private Transform shopItemTemplate;
    private IShopCustomer shopCustomer;
    public bool sellLeaf= true, sellStone= true, sellFlower= true, sellStick = true;
    private int sellPositionIndex = 0;

    private void Awake() {
        container = transform.Find("container");
        shopItemTemplate = container.Find("shopItemTemplate");
        shopItemTemplate.gameObject.SetActive(false);
    }

    private void Start() {
        if(sellLeaf){
        CreateItemButton(Item.ItemType.Leaf, Item.GetSprite(Item.ItemType.Leaf), "Leaf", Item.GetCost(Item.ItemType.Leaf), 0);
        sellPositionIndex++;
        }
        if(sellStone){
        CreateItemButton(Item.ItemType.Stone, Item.GetSprite(Item.ItemType.Stone), "Stone", Item.GetCost(Item.ItemType.Stone), sellPositionIndex);
        sellPositionIndex++;
        }
        if(sellStick){
        CreateItemButton(Item.ItemType.Stick, Item.GetSprite(Item.ItemType.Stick), "Stick", Item.GetCost(Item.ItemType.Stick), sellPositionIndex);
        sellPositionIndex++;
        }
        if(sellFlower){
        CreateItemButton(Item.ItemType.Flower, Item.GetSprite(Item.ItemType.Flower), "Flower", Item.GetCost(Item.ItemType.Flower), sellPositionIndex);
        sellPositionIndex++;
        }
        Hide();
    }


    private void CreateItemButton(Item.ItemType itemType, Sprite itemSprite, string itemName, int itemCost, int positionIndex) {
        Transform shopItemTransform = Instantiate(shopItemTemplate, container);
        shopItemTransform.gameObject.SetActive(true);
        RectTransform shopItemRectTransform = shopItemTransform.GetComponent<RectTransform>();

        float shopItemHeight = 250f;
        shopItemRectTransform.anchoredPosition = new Vector2(0, -shopItemHeight * positionIndex);

        shopItemTransform.Find("nameText").GetComponent<TextMeshProUGUI>().SetText(itemName);
        shopItemTransform.Find("costText").GetComponent<TextMeshProUGUI>().SetText(itemCost.ToString());
        shopItemTransform.Find("itemImage").GetComponent<Image>().sprite = itemSprite;
        shopItemTransform.GetComponent<Button_UI>().ClickFunc = () => { TryBuyItem(itemType); };
    }

    private void TryBuyItem(Item.ItemType itemType){
        if (shopCustomer.TrySpendGoldAmount(Item.GetCost(itemType))) {
            // Can afford cost
            shopCustomer.BoughtItem(itemType);
        } else {
            //Tooltip_Warning.ShowTooltip_Static("Cannot afford " + Item.GetCost(itemType) + "!");
        }
    }

    public void Show(IShopCustomer shopCustomer) {
        this.shopCustomer = shopCustomer;
        gameObject.SetActive(true);
    }

    public void Hide() {
        gameObject.SetActive(false);
    }

}
