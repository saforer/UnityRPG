using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MenuListing {
    public string name;
    public List<MenuButton> childrenButtons = new List<MenuButton>();
    public MenuListing parent;
    int currentSelection = 0;

    public MenuListing(string inName, MenuListing inParent)
    {
        name = inName;
        parent = inParent;
    }

    public void MoveUp()
    {
        if (currentSelection>0)
        {
            currentSelection--;
        }
        else
        {
            currentSelection = 0;
        }
        UpdateSelected();
    }

    public void MoveDown()
    {
        if (currentSelection < childrenButtons.Count-1)
        {
            currentSelection++;
        }
        else
        {
            currentSelection = childrenButtons.Count - 1;
        }
        UpdateSelected();
    }

    public bool CanLeft()
    {
        if (parent != null) return true;
        return false;
    }

    public MenuListing MoveLeft()
    {
        return parent;
    }
    
    public bool CanGoRight()
    {
        bool childMenuExists = false;
        bool childButtonsExist = false;
        if (childrenButtons[currentSelection].childMenu != null) childMenuExists = true;
        if (childMenuExists)
        {
            if (childrenButtons[currentSelection].childMenu.childrenButtons.Count > 0) childButtonsExist = true;
        }

        if (childButtonsExist) return true;
        return false;
    }

    public bool CanDoMove()
    {
        if (childrenButtons[currentSelection].childMove != null) return true;
        return false;
    }

    public bool CanUseItem()
    {
        if (childrenButtons[currentSelection].childItem != null) return true;
        return false;
    }

    public MenuListing MoveRight()
    {
        return childrenButtons[currentSelection].childMenu;
    }

    public Move CurrentButtonMove()
    {
        return childrenButtons[currentSelection].childMove;
    }

    public Item CurrentButtonItem()
    {
        return childrenButtons[currentSelection].childItem;
    }

    public void UpdateSelected()
    {
        foreach (MenuButton button in childrenButtons)
        {
            button.currentState = ButtonStates.Off;
        }
        childrenButtons[currentSelection].currentState = ButtonStates.On;
    }

     public override string ToString()
    {
        string output;
        output = "[Name: " + " " + name + "] ";
        int i = 0;
        foreach (MenuButton button in childrenButtons)
        {
            output += "[Button: " + button.name + " Count: " + i + "] ";
            i++;
        }

        return output;
    }
}
