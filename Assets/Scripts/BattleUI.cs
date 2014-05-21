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
        DrawAttack();
        DrawMetaMagic();
        DrawRun();

	}

    void DrawMenuBox()
    {
        GUI.DrawTexture(new Rect(10, 10, 100, 100), menuBoxBackground);
    }

    void DrawAttack()
    {

        switch (attackMenuState)
        {
        case MenuButtonState.On:
            attackMenuTexture = menuOptionTextureOn;
            break;
        case MenuButtonState.Off:
            attackMenuTexture = menuOptionTextureOff;
            break;
        case MenuButtonState.Locked:
            attackMenuTexture = menuOptionTextureLock;
            break;
        }        

        GUI.DrawTexture(new Rect(10, 10, 100, 20), attackMenuTexture);
        GUI.Label(new Rect(45, 10, 100, 20), "Attack");
    }

    void DrawMetaMagic()
    {
        switch (metaMagicMenuState)
        {
        case MenuButtonState.On:
            metaMagicMenuTexture = menuOptionTextureOn;
            break;
        case MenuButtonState.Off:
            metaMagicMenuTexture = menuOptionTextureOff;
            break;
        case MenuButtonState.Locked:
            metaMagicMenuTexture = menuOptionTextureLock;
            break;
        }        
        
        GUI.DrawTexture(new Rect(10, 30-3, 100, 20), metaMagicMenuTexture);
        GUI.Label(new Rect(30, 30-3, 100, 20), "MetaMagic");
    }

    void DrawRun()
    {
        switch (runMenuState)
        {
        case MenuButtonState.On:
            runMenuTexture = menuOptionTextureOn;
            break;
        case MenuButtonState.Off:
            runMenuTexture = menuOptionTextureOff;
            break;
        case MenuButtonState.Locked:
            runMenuTexture = menuOptionTextureLock;
            break;
        }        
        
        GUI.DrawTexture(new Rect(10, 50-6, 100, 20), runMenuTexture);
        GUI.Label(new Rect(50, 50-6, 100, 20), "Run");
    }

}
