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

	public Texture buttonOff;
	public Texture buttonOn;
	public Texture buttonLocked;

	public string label;

    public RPGButton(string inLabel, RPGmenu inParent, Texture inOn, Texture inOff, Texture inLock) 
    {
		label = inLabel;
		buttonOn = inOn;
		buttonOff = inOff;
		buttonLocked = inLock;
		childMenu = new RPGmenu(inLabel, inParent);
    }

	public Texture UsedTexture()
	{
		switch (currentState)
		{
		case buttonState.On:
			return buttonOn;
		case buttonState.Off:
			return buttonOff;
		default:
			return buttonLocked;
		}
	}
}
