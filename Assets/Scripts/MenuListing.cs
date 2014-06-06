using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MenuListing {
    public string name;
    public List<MenuButton> childrenButtons;
    public MenuListing parent;

    public MenuListing(string inName, MenuListing inParent)
    {
        name = inName;
        parent = inParent;
    }

    public void AddChildButton(string inText)
    {
        childrenButtons.Add(new MenuButton(inText));
    }
}
