using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Shop_3 : MonoBehaviour
{
    private Transform container;
    private Transform shopItemTemplate;
    private IShopCustomer shopCustomer;
    public bool sellLeaf= true, sellStone= true, sellFlower= true, sellStick = true;
    private int sellPositionIndex = 0;
    
    public Vector2Int LeafPrice;
    public Vector2Int FlowerPrice;
    public Vector2Int StonePrice;
    public Vector2Int StickPrice;
    private int itemPrice;
    public Sprite leafSprite;
    public Sprite flowerSprite;
    public Sprite stoneSprite;
    public Sprite stickSprite;
    private void Awake() {
        container = transform.Find("container");
        shopItemTemplate = container.Find("shopItemTemplate");
        shopItemTemplate.gameObject.SetActive(false);
    }

    private int GetRandomPrice(Vector2Int priceRange){
        int price= Random.Range(priceRange.x, priceRange.y);
        itemPrice = price;
        return price;
    }

    private void Start() {
        if(sellLeaf){
        CreateItemButton(Item.ItemType.Leaf, leafSprite, "Buy", GetRandomPrice(LeafPrice), 0);
        sellPositionIndex++;
        }
        if(sellStone){
        CreateItemButton(Item.ItemType.Stone, stoneSprite, "Buy", GetRandomPrice(StonePrice), sellPositionIndex);
        sellPositionIndex++;
        }
        if(sellStick){
        CreateItemButton(Item.ItemType.Stick, stickSprite, "Buy", GetRandomPrice(StickPrice), sellPositionIndex);
        sellPositionIndex++;
        }
        if(sellFlower){
        CreateItemButton(Item.ItemType.Flower, flowerSprite, "Buy", GetRandomPrice(FlowerPrice), sellPositionIndex);
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
        if (shopCustomer.TrySpendGoldAmount(itemPrice)){
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
