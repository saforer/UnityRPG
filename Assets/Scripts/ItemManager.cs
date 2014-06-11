using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum ValidItem
{
    Pancakes,
    Yogurt_Smoothie,
    Milk,
    Covered_Brick
}

public class ItemManager {

    public Item GetItem(ValidItem inItem)
    {
        switch (inItem)
        {
            case ValidItem.Pancakes:
            default:
                return new Item("Pancakes");
        }
    }
}
