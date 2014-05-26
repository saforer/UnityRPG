using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BattleUI : MonoBehaviour 
{
    public Texture backgroundTexture;
	
	public GUIStyle rpgGUIStyle;

	public int buttonHeight = 24;
	public int buttonWidth = 100;


	public RPGmenu selectedMenuOption;

    void OnGUI()
    {
		Draw ();
    }

	public void SetSelected(RPGmenu inMenu)
	{
		selectedMenuOption = inMenu;
	}

	void Draw()
	{
		int depth = FindDepth(selectedMenuOption);
		RPGmenu tempSelection = selectedMenuOption;

		while (depth>=0)
		{
			DrawBox (tempSelection, depth, tempSelection.buttonList.Count);

			int i = 0;
			foreach (RPGButton todraw in tempSelection.buttonList)
			{
				DrawButton(todraw, i, depth);
				i++;
			}

			tempSelection = tempSelection.parent;

			depth--;
		}
	}

	void DrawBox(RPGmenu inMenu,int inDepth, int inCount)
	{
		int HorizontalLocation = 10+(buttonWidth*inDepth);
		int BackgroundHeight = (buttonHeight*inCount);
		Rect drawWhere = new Rect(HorizontalLocation,10,buttonWidth,BackgroundHeight);
		GUI.DrawTexture(drawWhere, backgroundTexture);
	}

	void DrawButton(RPGButton inButton, int inCount,  int inDepth)
	{
		int HorizontalLocation = 10+(buttonWidth*inDepth);
		int VerticalLocation = 10 + (inCount * buttonHeight);
		Rect drawWhere = new Rect(HorizontalLocation,VerticalLocation,buttonWidth,buttonHeight);
		GUI.DrawTexture(drawWhere, inButton.UsedTexture());
		GUI.TextArea(drawWhere,inButton.label, rpgGUIStyle);
	}

	int FindDepth(RPGmenu menuInput)
	{
		RPGmenu tempMenu = menuInput;
		int i = 0;
		while (true)
		{
			if (tempMenu.parent == null) 
				break;
			tempMenu = tempMenu.parent;
			i++;
		}

		return i;
	}
}