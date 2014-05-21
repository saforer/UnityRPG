using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum MenuOptions 
{
	Skills,
	MetaMagic,
    Magic,
    Items,
	Run,
    Attack,
    Feint,
    Parry
}

public enum MenuType
{
    Main,
    Sub
}

public enum MenuButtonState
{
    On,
    Off,
    Locked
}

public class BattleUI : MonoBehaviour 
{

    public Texture menuBoxBackground;

    public Texture menuButtonOn;
    public Texture menuButtonOff;
    public Texture menuButtonLock;

    public bool drawSub = false;

    List<RPGButton> mainOptions = new List<RPGButton>();

	void Start () 
    {
        
        MenuButtonState temp = MenuButtonState.Off;
        mainOptions.Add(new RPGButton( menuButtonOn, menuButtonOff, menuButtonLock, "Attack"));

	}
	
	void OnGUI () 
    {
        //background
        DrawMenuBox();

        //Main Menu
        int i = 0;
        foreach (RPGButton input in mainOptions)
        {
            DrawOption(input, i);
        }

	}

    void DrawMenuBox()
    {
        GUI.DrawTexture(new Rect(10, 10, 100, (18*5)), menuBoxBackground);
    }

    void DrawOption(RPGButton buttonIn, int selectionNumber)
    {
        int h = (10 + (18 * selectionNumber));
        
        Texture usedTexture = null;

        switch (buttonIn.currentState)
        {
            case MenuButtonState.Off:
                usedTexture = buttonIn.textureOff;
                break;
            case MenuButtonState.On:
                usedTexture = buttonIn.textureOn;
                break;
            case MenuButtonState.Locked:
                usedTexture = buttonIn.textureLock;
                break;
        }

        GUI.DrawTexture(new Rect(10, h, 100, 20), usedTexture);
        GUI.Label(new Rect(25, h, 100, 20), buttonIn.buttonName);
    }

    
}