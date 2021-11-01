using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
 public enum ItemType {
        HealthPotion,
    }

    public static int GetCost(ItemType itemType) {
        switch (itemType) {
        default:
        case ItemType.HealthPotion:     return 30;
        }
    }

    public static Sprite GetSprite(ItemType itemType) {
        switch (itemType) {
        default:
        case ItemType.HealthPotion: return GameAssets.Instance.s_HealthPotion;

        }
    }
}
