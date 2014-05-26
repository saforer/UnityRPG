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
		if ( buttonList.Count-1 > selectionNumber)
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
		if ( 0 < selectionNumber)
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
		foreach (RPGButton offButtons in buttonList)
		{
			offButtons.currentState = buttonState.Off;
		}

		buttonList[selectionNumber].currentState = buttonState.On;
	}

	public RPGmenu ChildMenuAt(int i)
	{
		return buttonList[i].childMenu;
	}

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
