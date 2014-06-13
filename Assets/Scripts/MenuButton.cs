using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class MenuButton {
    public ButtonState currentState = ButtonState.Off;
    public string name;
    public MenuList childMenu;
    public ValidMove childMove;
    public ValidItem childItem;

    public MenuButton(string inLabel, MenuList inMenu)
    {
        name = inLabel;
        childMenu = inMenu;
    }

    public MenuButton(ValidMove inMove)
    {
        MoveMgr movemgr = new MoveMgr();
        name = movemgr.GetMove(inMove).name;
        childMove = inMove;
    }

    public MenuButton(ValidItem inItem)
    {
        ItemMgr itemmgr = new ItemMgr();
        name = itemmgr.GetItem(inItem).name;
        childItem = inItem;
    }

    public Texture currentTexture()
    {
        switch (currentState)
        {
            default:
            case ButtonState.Off:
                return Resources.Load("MenuButtonOff") as Texture;
            case ButtonState.On:
                return Resources.Load("MenuButtonOn") as Texture;
        }

    }
}

public enum ButtonState
{
    On,
    Off
}