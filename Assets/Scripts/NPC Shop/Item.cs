using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
 public enum ItemType {
        HealthPotion,
        Stick,
        Stone,
        Flower
    }

    public static int GetCost(ItemType itemType) {
        switch (itemType) {
        default:
        case ItemType.HealthPotion:     return 30;
        case ItemType.Flower:     return 10;
        case ItemType.Stone:     return 20;
        case ItemType.Stick:     return 5;
        }
    }

    public static Sprite GetSprite(ItemType itemType) {
        switch (itemType) {
        default: 
        case ItemType.HealthPotion: return GameAssets.Instance.s_HealthPotion;
        case ItemType.Flower: return GameAssets.Instance.s_Flower;
        case ItemType.Stone: return GameAssets.Instance.s_Stone;
        case ItemType.Stick: return GameAssets.Instance.s_Stick;

        }
    }
}
