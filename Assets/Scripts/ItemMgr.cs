using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class ItemMgr {
    public Item GetItem(ValidItem inItem)
    {
        List<Target> outTargets = new List<Target>();
        switch (inItem)
        {
            default:
            case ValidItem.Milk:
                outTargets.Add(new Target(1, ValidTeam.Player));
                return new Item("Milk", inItem, outTargets);
            case ValidItem.Pancakes:
                outTargets.Add(new Target(1, ValidTeam.Player));
                return new Item("Pancakes", inItem, outTargets);
            case ValidItem.Yogurt_Smoothie:
                outTargets.Add(new Target(1, ValidTeam.Player));
                return new Item("Yogurt Smoothie", inItem, outTargets);
            case ValidItem.Covered_Brick:
                outTargets.Add(new Target(1, ValidTeam.Player));
                outTargets.Add(new Target(1, ValidTeam.Enemy));
                return new Item("Chocolate Covered Brick", inItem, outTargets);
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
