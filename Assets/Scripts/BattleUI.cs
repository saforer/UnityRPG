using UnityEngine;
using System.Collections;

public enum MenuOptions 
{
	Skills,
	MetaMagic,
    Magic,
    Items,
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
    
    
    
	// Use this for initialization
	void Start () 
    {

        skillsMenuState = MenuButtonState.On;
        metaMagicMenuState = MenuButtonState.Off;
        magicMenuState = MenuButtonState.Off;
        itemMenuState = MenuButtonState.Off;
        runMenuState = MenuButtonState.Off;
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

	void OnGUI () 
    {
        DrawMenuBox();

        DrawOption(0, MenuOptions.Skills,skillsMenuState);
        DrawOption(1, MenuOptions.MetaMagic, metaMagicMenuState);
        DrawOption(2, MenuOptions.Magic, magicMenuState);
        DrawOption(3, MenuOptions.Items, itemMenuState);
        DrawOption(4, MenuOptions.Run, runMenuState);



	}

    void DrawMenuBox()
    {
        GUI.DrawTexture(new Rect(10, 10, 100, (18*5)), menuBoxBackground);
    }

    void DrawOption(int selectionNumber,MenuOptions selectedOption,MenuButtonState inputState)
    {
        int h = (10 + (18 * selectionNumber));
        GUI.DrawTexture(new Rect(10, h, 100, 20), StateToTexture(inputState));
        GUI.Label(new Rect(25, h, 100, 20), selectedOption.ToString());
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