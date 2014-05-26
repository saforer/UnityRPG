using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BattleLogic : MonoBehaviour {

    private BattleUI currentUI;

	public RPGmenu currentMenu;

	public Texture buttonOff;
	public Texture buttonOn;
	public Texture buttonLocked;

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
		if (Input.GetKeyDown (KeyCode.DownArrow))
		{
			currentMenu.MoveDown();
		}
		if (Input.GetKeyDown (KeyCode.UpArrow))
		{
			currentMenu.MoveUp();
		}
		if (Input.GetKeyDown (KeyCode.RightArrow))
		{
			currentMenu = currentMenu.ChildSelected();
			currentMenu.UpdateSelection();
			currentUI.SetSelected(currentMenu);
		}
		if (Input.GetKeyDown (KeyCode.LeftArrow))
		{
			if (currentMenu.parent != null)
			{
				currentMenu = currentMenu.parent;
			}
			currentUI.SetSelected(currentMenu);
		}
    }

	void CreateMenu()
	{
		currentMenu = new RPGmenu("MainMenu", null);

		List<string> optionsString;

		optionsString = new List<string>() {"Skills","MetaMagic","Magic","Items","Run"};

		currentUI.SetSelected(currentMenu);

		PropogateMenu(currentMenu, optionsString);

		optionsString = new List<string>() {"Barbarian","Knight"};

		PropogateMenu(currentMenu.ChildMenuAt(0), optionsString);

		optionsString = new List<string>() {"Smash","Rip"};
		
		PropogateMenu(currentMenu.ChildMenuAt(0).ChildMenuAt(0), optionsString);

		optionsString = new List<string>() {"Bodyguard","Tower Defense"};
		
		PropogateMenu(currentMenu.ChildMenuAt(0).ChildMenuAt(1), optionsString);

		optionsString = new List<string>() {"Analyze Enemy", "Validate", "Self Perfection", "Alter Enemy"};
		
		PropogateMenu(currentMenu.ChildMenuAt(1), optionsString);

		optionsString = new List<string>() {"Magician","Cleric"};
		
		PropogateMenu(currentMenu.ChildMenuAt(2), optionsString);

		optionsString = new List<string>() {"Fire Wall","Ice Dagger"};
		
		PropogateMenu(currentMenu.ChildMenuAt(2).ChildMenuAt(0), optionsString);

		optionsString = new List<string>() {"Radiant Glow","Heal Aura"};
		
		PropogateMenu(currentMenu.ChildMenuAt(2).ChildMenuAt(1), optionsString);

		optionsString = new List<string>() {"Pancakes", "Fried Eggplant", "Milk", "Vodka", "Iced Tea", "Soda"};

		PropogateMenu(currentMenu.ChildMenuAt(3),optionsString);


	}

	void PropogateMenu(RPGmenu parentMenu, List<string> tempNamesList)
	{
		foreach (string tempString in tempNamesList)
		{
			parentMenu.buttonList.Add(new RPGButton(tempString,parentMenu, buttonOn, buttonOff, buttonLocked));
		}

		currentMenu.buttonList[0].currentState = buttonState.On;
	}
}