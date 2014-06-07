using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MenuListing {
    public string name;
    public List<MenuButton> childrenButtons = new List<MenuButton>();
    public MenuListing parent;

    public MenuListing(string inName, MenuListing inParent)
    {
        name = inName;
        parent = inParent;
    }
}
