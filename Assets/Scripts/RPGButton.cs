using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum buttonState
{
    On,
    Off,
    Locked
}

public class RPGButton {

    public string label;

    Texture buttonOn;
    Texture buttonOff;
    Texture buttonLocked;

    public bool container;

    public buttonState currentState = buttonState.Off;

    public RPGmenu childMenu;

    public RPGButton(string inLabel, Texture inOnTexture, Texture inOffTexture, Texture inLockedTexture) 
    {
        label = inLabel;
        buttonOn = inOnTexture;
        buttonOff = inOffTexture;
        buttonLocked = inLockedTexture;
    }

    public Texture OutputTexture ()
    {
        Texture output = null;
        switch (currentState)
        {
            case buttonState.On:
                output = buttonOn;
                break;
            case buttonState.Off:
                output = buttonOff;
                break;
            case buttonState.Locked:
                output = buttonLocked;
                break;
        }

        return output;
    }
}
