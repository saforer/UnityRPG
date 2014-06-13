using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class MenuList {
    public string name;
    public MenuList parent;
    int selectedMenuOption = 0;
    public List<MenuButton> childButtons = new List<MenuButton>();

    public MenuList (string inName, MenuList inParent)
    {
        name = inName;
        parent = inParent;
    }

    public void MoveUp()
    {
        if (selectedMenuOption > 0)
        {
            selectedMenuOption--;
        }
        else
        {
            selectedMenuOption = 0;
        }
        UpdateSelected();
    }

    public void MoveDown()
    {
        if (selectedMenuOption < childButtons.Count-1)
        {
            selectedMenuOption++;
        }
        else
        {
            selectedMenuOption = childButtons.Count - 1;
        }
        UpdateSelected();
    }

    public bool CanLeft()
    {
        if (parent != null) return true;
        return false;
    }

    public MenuList GoLeft()
    {
        return parent;
    }

    public bool CanRight()
    {
        if (childButtons[selectedMenuOption].childMenu != null)
        {
            if (childButtons[selectedMenuOption].childMenu.childButtons.Count > 0)
                return true;
        }

        return false;
    }

    public MenuList GoRight()
    {
        return childButtons[selectedMenuOption].childMenu;
    }

    public bool CanItem()
    {
        if (childButtons[selectedMenuOption].childItem != null) return true;
        return false;
    }

    public ValidItem GetItem()
    {
        return childButtons[selectedMenuOption].childItem;
    }

    public bool CanMove()
    {
        if (childButtons[selectedMenuOption].childMove != null) return true;
        return false;
    }

    public ValidMove GetMove()
    {
        return childButtons[selectedMenuOption].childMove;
    }

    public void UpdateSelected()
    {
        foreach (MenuButton button in childButtons)
        {
            button.currentState = ButtonState.Off;
        }
        childButtons[selectedMenuOption].currentState = ButtonState.On;
    }

    public override string ToString()
    {
        string output = "[" + name + "]";
        int i = 0;
        foreach (MenuButton btn in childButtons)
        {
            output += " [" + btn.name + " " + i + "]";
            i++;
        }
        return output;
    }
}