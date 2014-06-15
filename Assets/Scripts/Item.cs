using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class Item {
    public string name;
    public ValidItem currentItem;
    public List<Target> neededTargets;

    public Item(string inName, ValidItem inItem, List<Target> inTargets)
    {
        name = inName;
        currentItem = inItem;
    }
}
