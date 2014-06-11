using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum ButtonStates
{
    On,
    Off,
    Lock
}

public class MenuButton
{

    public MenuListing childMenu;
    public Move childMove;
    public Item childItem;

    public ButtonStates currentState = ButtonStates.Off;


    public string name;
    public Texture offTexture;
    public Texture onTexture;
    public Texture lockTexture;

    public MenuButton(string inLabel)
    {
        name = inLabel;
        onTexture = Resources.Load("MenuButtonOn") as Texture;
        offTexture = Resources.Load("MenuButtonOff") as Texture;
        lockTexture = Resources.Load("MenuButtonLock") as Texture;
    }

    public Texture CurrentTexture()
    {
        switch (currentState)
        {
            case ButtonStates.On:
                return onTexture;
            case ButtonStates.Off:
                return offTexture;
            case ButtonStates.Lock:
                return lockTexture;
            default:
                Debug.Log("Fix CurrentTexture()");
                return offTexture;
        }
    }

    public bool IsContainer()
    {
        if (childMenu.childrenButtons.Count > 0) return true;

        return false;
    }
}