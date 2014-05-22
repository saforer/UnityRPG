using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BattleLogic : MonoBehaviour {

    private BattleUI currentUI;

    public Texture buttonOn;
    public Texture buttonOff;
    public Texture buttonLocked;

    public List<RPGmenu> mainMenu = new List<RPGmenu>();

    RPGmenu currentMenu;


    void Start ()
    {
        mainMenu.Add(new RPGmenu("Main"));

        List<string> tempList = new List<string>() {"Skills","MetaMagic","Magic","Items","Run"};
        foreach (string tempString in tempList)
        { 
            mainMenu[0].AddChild(new RPGButton(tempString, buttonOn, buttonOff, buttonLocked));
        }

        currentMenu = mainMenu[0];
        mainMenu[0].Startup();
    }

    void Update()
    {
        Controls();
    } 

    void Controls()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            currentMenu.MenuUp();
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            currentMenu.MenuDown();
        }
    }
}
