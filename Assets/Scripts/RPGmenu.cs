using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RPGmenu 
{
	public string name;
	public RPGmenu parent;
	int selectionNumber = 0;
	public List<RPGButton> buttonList = new List<RPGButton>();
	
	public RPGmenu (string inName, RPGmenu inParent)
    {
		name = inName;
		parent = inParent;

    }
	
	public void MoveDown()
	{
		if ( buttonList.Count-1 > selectionNumber) //Does a further down option exist?
		{
			selectionNumber++;
			UpdateSelection();
		}
		else
		{
			selectionNumber = buttonList.Count-1;
			UpdateSelection();
		}
	}

	public void MoveUp()
	{
		if ( 0 < selectionNumber) //Are we at the 0th element?
		{
			selectionNumber--;
			UpdateSelection();
		}
		else
		{
			selectionNumber = 0;
			UpdateSelection();
		}
	}

	public void UpdateSelection ()
	{
		foreach (RPGButton offButtons in buttonList) //Turn off every button
		{
			offButtons.currentState = buttonState.Off;
		}

		buttonList[selectionNumber].currentState = buttonState.On; //Now turn the correct one on
	}


	/*
	 *    This exists so that the battle class instead of needing
	 *    to do mainMenu.button[0].menu.button[0].menu.button[0]
	 *    can instead just do menu.menu.menu.menu
	 *    which makes for easier to read code                    
	 */
	public RPGmenu ChildMenuAt(int i) 
	{
		return buttonList[i].childMenu; 
	}

	//This is for the "go further in the tree script"
	//If further in the tree exists, return it. If not, return the one we KNOW works.
	public RPGmenu ChildSelected()
	{
		if (buttonList[selectionNumber].childMenu.buttonList.Count > 0) 
		{
			return buttonList[selectionNumber].childMenu;
		}
		else
		{
			return this;
		}
	}
}
