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

    public buttonState currentState = buttonState.Off;

    public RPGmenu childMenu;

    public RPGButton(string inLabel, Texture inOnTexture, Texture inOffTexture, Texture inLockedTexture) 
    {
        
    }
}
