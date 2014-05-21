using UnityEngine;
using System.Collections;

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
    
    public Texture menuOptionTextureOff;
    public Texture menuOptionTextureOn;
    public Texture menuOptionTextureLock;

    public bool drawSub = false;

    [HideInInspector]
    public MenuButtonState skillsMenuState;
    [HideInInspector]
    public MenuButtonState metaMagicMenuState;
    [HideInInspector]
    public MenuButtonState magicMenuState;
    [HideInInspector]
    public MenuButtonState itemMenuState;
    [HideInInspector]
    public MenuButtonState runMenuState;
    [HideInInspector]
    public MenuButtonState option1State;
    [HideInInspector]
    public MenuButtonState option2State;
    [HideInInspector]
    public MenuButtonState option3State;
    [HideInInspector]
    public MenuButtonState option4State;
    [HideInInspector]
    public MenuButtonState option5State;
    [HideInInspector]
    public MenuButtonState option6State;

	// Use this for initialization
	void Start () 
    {
        skillsMenuState = MenuButtonState.On;
        metaMagicMenuState = MenuButtonState.Off;
        magicMenuState = MenuButtonState.Off;
        itemMenuState = MenuButtonState.Off;
        runMenuState = MenuButtonState.Off;
        option1State = MenuButtonState.Off;
        option2State = MenuButtonState.Off;
        option3State = MenuButtonState.Off;
	}
	
	void OnGUI () 
    {
        //background
        DrawMenuBox();

        //Main Menu
        DrawOption(MenuType.Main, 0, MenuOptions.Skills,skillsMenuState);
        DrawOption(MenuType.Main, 1, MenuOptions.MetaMagic, metaMagicMenuState);
        DrawOption(MenuType.Main, 2, MenuOptions.Magic, magicMenuState);
        DrawOption(MenuType.Main, 3, MenuOptions.Items, itemMenuState);
        DrawOption(MenuType.Main, 4, MenuOptions.Run, runMenuState);

        //Sub Menu
        if (drawSub)
        {
            DrawOption(MenuType.Sub, 0, MenuOptions.Attack, option1State);
            DrawOption(MenuType.Sub, 1, MenuOptions.Parry, option2State);
            DrawOption(MenuType.Sub, 2, MenuOptions.Feint, option3State);
        }
	}

    void DrawMenuBox()
    {
        GUI.DrawTexture(new Rect(10, 10, 100, (18*5)), menuBoxBackground);
    }

    void DrawOption(MenuType type, int selectionNumber,MenuOptions selectedOption,MenuButtonState inputState)
    {
        switch (type)
        {
            case MenuType.Main:
                int h = (10 + (18 * selectionNumber));
                GUI.DrawTexture(new Rect(10, h, 100, 20), StateToTexture(inputState));
                GUI.Label(new Rect(25, h, 100, 20), selectedOption.ToString());
                break;
            case MenuType.Sub:
                int i = (10 + (18 * selectionNumber));
                GUI.DrawTexture(new Rect(110, i, 100, 20), StateToTexture(inputState));
                GUI.Label(new Rect((110+25), i, 100, 20), selectedOption.ToString());
                break;
        }
        
    }

    Texture StateToTexture(MenuButtonState state)
    {
        Texture outputTexture = null;

        switch (state)
        {
            case MenuButtonState.On:
                outputTexture = menuOptionTextureOn;
                break;
            case MenuButtonState.Off:
                outputTexture = menuOptionTextureOff;
                break;
            case MenuButtonState.Locked:
                outputTexture = menuOptionTextureLock;
                break;
        }

        return outputTexture;
    }
}