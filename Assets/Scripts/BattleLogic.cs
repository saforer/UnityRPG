using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BattleLogic : MonoBehaviour {

    private BattleUI currentUI;

    public Texture buttonOn;
    public Texture buttonOff;
    public Texture buttonLocked;

    public RPGmenu mainMenu;

    public int currentDepth = 0;

    void Start ()
    {
        mainMenu = new RPGmenu("Main");
        List<string> tempList = new List<string> { "Skills", "MetaMagic", "Magic", "Items", "Run" };
        foreach (string temp in tempList)
        {
            mainMenu.AddChildButton(new RPGButton(temp, buttonOn, buttonOff, buttonLocked));
        }
        mainMenu.Startup();

        RPGButton tempButton = mainMenu.children[0];
        tempButton.childMenu = new RPGmenu("Skills");
        RPGmenu tempMenu = tempButton.childMenu;

        tempList = new List<string> { "Attack", "Barbarian", "Samurai", "Ninja"};
        foreach (string temp in tempList)
        {
            tempMenu.AddChildButton(new RPGButton(temp, buttonOn, buttonOff, buttonLocked));
        }

        tempMenu.Startup();

    }

    void Update()
    {
        Controls();
    } 

    void Controls()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            mainMenu.MenuUp(currentDepth);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            mainMenu.MenuDown(currentDepth);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            currentDepth++;
            mainMenu = mainMenu.Grow(currentDepth);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            currentDepth--;
            mainMenu = mainMenu.Shrink(currentDepth);
        }
    }
}
