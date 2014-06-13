using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class ItemMgr {
    public Item GetItem(ValidItem inItem)
    {
        switch (inItem)
        {
            default:
            case ValidItem.Milk:
                return new Item("Milk");
            case ValidItem.Pancakes:
                return new Item("Pancakes");
            case ValidItem.Yogurt_Smoothie:
                return new Item("Yogurt Smoothie");
            case ValidItem.Covered_Brick:
                return new Item("Brick covered in chocolate");
        }
    }
}

public enum ValidItem
{
    Pancakes,
    Yogurt_Smoothie,
    Milk,
    Covered_Brick
}
