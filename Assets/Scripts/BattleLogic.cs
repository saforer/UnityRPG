using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BattleLogic : MonoBehaviour {

    private BattleUI currentUI;

	int maxDepth = 4;

    public Texture buttonOn;
    public Texture buttonOff;
    public Texture buttonLocked;

	public RPGmenu mainMenu;

    public int currentDepth = 0;

    void Start ()
    {
		CreateMenu();
		PropogateMenu(mainMenu);

    }

    void Update()
    {
        Controls();
    } 

    void Controls()
    {
		if (Input.GetKeyDown (KeyCode.LeftArrow))
		{
			if (currentDepth>0)
			{
				currentDepth--;
			}
			else
			{
				currentDepth = 0;
			}
		}
		if (Input.GetKeyDown (KeyCode.RightArrow))
		{
			if (currentDepth < maxDepth)
			{
				currentDepth++;
			}
			else
			{
				currentDepth = maxDepth;
			}
		}
    }

	void CreateMenu()
	{
		mainMenu = new RPGmenu(0);


	}

	void PropogateMenu(RPGmenu inMenu)
	{
		List<string> tempStrings = new List<string>() 
		{
			"Skills",
			"MetaMagic",
			"Magic",
			"Item",
			"Run"
		};
		int i=0;
		foreach (string temp in tempStrings)
		{
			inMenu.children.Add(new RPGButton(temp,buttonOn,buttonOff,buttonLocked));
			inMenu.children[i].childMenu = new RPGmenu(1);
			i++;
		}

		tempStrings = new List<string>()
		{
			"Ninja",
			"Barbarian",
			"Samurai"
		};

		i = 0;
		inMenu.children[0].container = true;
		RPGmenu tempMenu = inMenu.children[0].childMenu;
		foreach (string temp in tempStrings)
		{
			tempMenu.children.Add(new RPGButton(temp,buttonOn,buttonOff,buttonLocked));
			tempMenu.children[i].childMenu = new RPGmenu(1);
			i++;
		}

		tempStrings = new List<string>()
		{
			"Elemental",
			"Split",
			"Air Wall",
			"Shadow Strike"
		};
		
		i = 0;
		tempMenu.children[0].container = true;
		tempMenu = tempMenu.children[0].childMenu;
		foreach (string temp in tempStrings)
		{
			tempMenu.children.Add(new RPGButton(temp,buttonOn,buttonOff,buttonLocked));
			tempMenu.children[i].childMenu = new RPGmenu(1);
			i++;
		}

		tempStrings = new List<string>()
		{
			"Fire Wall",
			"Ice Spear"
		};
		
		i = 0;
		tempMenu.children[0].container = true;
		tempMenu = tempMenu.children[0].childMenu;
		foreach (string temp in tempStrings)
		{
			tempMenu.children.Add(new RPGButton(temp,buttonOn,buttonOff,buttonLocked));
			tempMenu.children[i].childMenu = new RPGmenu(1);
			i++;
		}
	}
}