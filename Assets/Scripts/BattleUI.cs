using UnityEngine;
using System.Collections;

public enum MenuOptions 
{
	Attack,
	MetaMagic,
	Run
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

    private Texture attackMenuTexture;
    private Texture metaMagicMenuTexture;
    private Texture runMenuTexture;

    [HideInInspector]
    public MenuButtonState attackMenuState;
    [HideInInspector]
    public MenuButtonState metaMagicMenuState;
    [HideInInspector]
    public MenuButtonState runMenuState;
    
	// Use this for initialization
	void Start () 
    {
        attackMenuTexture = menuOptionTextureOff;
        metaMagicMenuTexture = menuOptionTextureOff;
        runMenuTexture = menuOptionTextureOff;

        attackMenuState = MenuButtonState.On;
        metaMagicMenuState = MenuButtonState.Off;
        runMenuState = MenuButtonState.Off;
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

	void OnGUI () 
    {
        DrawMenuBox();

        DrawOption(0,MenuOptions.Attack,attackMenuState);
        DrawOption(1, MenuOptions.MetaMagic, metaMagicMenuState);
        DrawOption(2, MenuOptions.Run, runMenuState);



	}

    void DrawMenuBox()
    {
        GUI.DrawTexture(new Rect(10, 10, 100, 100), menuBoxBackground);
    }

    void DrawOption(int selectionNumber,MenuOptions selectedOption,MenuButtonState inputState)
    {
        int h = (10 + (18 * selectionNumber));
        GUI.DrawTexture(new Rect(10, h, 100, 20), StateToTexture(inputState));
        GUI.Label(new Rect(45, h, 100, 20), StateToText(selectedOption));
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

    string StateToText(MenuOptions option)
    {
        string output = "";

        switch (option)
        {
            case MenuOptions.Attack:
                output = "Attack";
                break;
            case MenuOptions.MetaMagic:
                output = "MetaMagic";
                break;
            case MenuOptions.Run:
                output = "Run";
                break;
        }

        return output;
    }

}