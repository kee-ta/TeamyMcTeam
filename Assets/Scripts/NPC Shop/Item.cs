using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
 public enum ItemType {
        Leaf,
        Stick,
        Stone,
        Flower
    }

    public static int GetCost(ItemType itemType) {
        switch (itemType) {
        default:
        case ItemType.Leaf:     return 30;
        case ItemType.Flower:     return 10;
        case ItemType.Stone:     return 20;
        case ItemType.Stick:     return 5;
        }
    }

    public static Image GetSprite(ItemType itemType) {
        switch (itemType) {
        default: 
        case ItemType.Leaf: return GameAssets.Instance.s_HealthPotion;
        case ItemType.Flower: return GameAssets.Instance.s_Flower;
        case ItemType.Stone: return GameAssets.Instance.s_Stone;
        case ItemType.Stick: return GameAssets.Instance.s_Stick;

        }
    }
}
