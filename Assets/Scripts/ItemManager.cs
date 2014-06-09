using UnityEngine;
using System.Collections;

public enum ValidItems
{
    //Solid
    Pancakes,
    Waffles,

    //Liquid
    Vodka,
    Milk,

    //Mix
    Yogurt_Smoothie,
    Covered_Brick
}

public class ItemManager {
    public Item GetItem(ValidItems inItem)
    {
        return new Item(inItem.ToString());
    }
}
