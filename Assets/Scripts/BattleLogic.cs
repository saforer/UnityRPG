using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BattleLogic : MonoBehaviour {

    private BattleUI currentUI;

    public Texture buttonOn;
    public Texture buttonOff;
    public Texture buttonLocked;

	public RPGmenu currentMenu;

    public int currentDepth = 0;

    void Start ()
    {
		currentUI = gameObject.GetComponent<BattleUI>();

		CreateMenu();

    }

    void Update()
    {
        Controls();
    } 

    void Controls()
    {

    }

	void CreateMenu()
	{
		currentMenu = new RPGmenu("MainMenu", null);

		List<string> optionsString = new List<string>() {"SkillsMenu","MetaMagicMenu","MagicMenu","ItemsMenu","RunMenu"};

		PropogateMenu(currentMenu, optionsString);

        optionsString = new List<string>() { "Barbarian", "Ninja", "Samurai", "Gladiator" };

        PropogateMenu(currentMenu.children[0], optionsString);

        optionsString = new List<string>() { "Yell", "Smash", "Surge", "Rip" };

        PropogateMenu(currentMenu.children[0].children[0], optionsString);

		currentUI.SetSelected(currentMenu.children[0].children[0]);
	}

	void PropogateMenu(RPGmenu parentMenu, List<string> tempNamesList)
	{
		foreach (string tempNames in tempNamesList)
		{
			RPGmenu tempMenu = new RPGmenu(tempNames,parentMenu);
			parentMenu.children.Add(tempMenu);
		}
	}
}