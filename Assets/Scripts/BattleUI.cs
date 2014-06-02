using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//This class controls the actual drawing of the UI
public class BattleUI : MonoBehaviour 
{
    public Texture backgroundTexture;
	
	public GUIStyle rpgGUIStyle;
	
	public int buttonHeight = 24;
	public int buttonWidth = 100;

	public Mob enemy;

	//Send selectedMenuOption from other classes to the UI, so the UI can draw it.
	public RPGmenu selectedMenuOption;
	public string recentDialogue;

    void OnGUI()
    {
		Draw ();
		DrawEnemy(enemy);
		DrawDialogue();
    }

	void DrawDialogue()
	{
		Rect location = new Rect(0,200,500,100);
		GUI.TextField(location, recentDialogue);
	}

	void DrawEnemy(Mob inEnemy)
	{
		Rect location = new Rect(250,150,100,100);
		GUI.DrawTexture(location,enemy.battlePicture);
	}

	//Call this method to update what menu is open.
	public void SetSelected(RPGmenu inMenu)
	{
		selectedMenuOption = inMenu;
	}

	void Draw()
	{

		//Find how deep in the tree we are
		int depth = FindDepth(selectedMenuOption);

		//Make a temporary menu for us to mess with and alter later
		RPGmenu tempSelection = selectedMenuOption;

		//Since we know the depth, Draw trees from the furthest out to the root
		while (depth>=0)
		{
			//Draw the background box
			DrawBox (tempSelection, depth, tempSelection.buttonList.Count);

			int i = 0;
			foreach (RPGButton todraw in tempSelection.buttonList)
			{
				//Draw each individual button
				DrawButton(todraw, i, depth);
				i++;
			}

			//Now do the same, but for higher up the tree
			tempSelection = tempSelection.parent;

			depth--;
		}
	}

	void DrawBox(RPGmenu inMenu,int inDepth, int inCount)
	{
		//Find out where the menu should be drawn, and how big it should be
		int HorizontalLocation = 10+(buttonWidth*inDepth);
		int BackgroundHeight = (buttonHeight*inCount);

		//Scope out how big the box should be
		Rect drawWhere = new Rect(HorizontalLocation,10,buttonWidth,BackgroundHeight);

		//Actually draw the background
		GUI.DrawTexture(drawWhere, backgroundTexture);
	}

	void DrawButton(RPGButton inButton, int inCount,  int inDepth)
	{
		//Find out where the button should be drawn
		int HorizontalLocation = 10+(buttonWidth * inDepth);
		int VerticalLocation = 10 + (inCount * buttonHeight);

		//Scope out how big the button needs to be
		Rect drawWhere = new Rect(HorizontalLocation,VerticalLocation,buttonWidth,buttonHeight);

		//Actually draw the background of the button
		GUI.DrawTexture(drawWhere, inButton.UsedTexture());

		//Give the button its text, the guistyle just has centered alignment
		GUI.Label(drawWhere,inButton.label, rpgGUIStyle);
	}

	int FindDepth(RPGmenu menuInput)
	{
		RPGmenu tempMenu = menuInput;

		int i = 0;
		while (true)
		{
			if (tempMenu.parent == null) break; //If the menu has no parent, it's the root. We're done counting
			tempMenu = tempMenu.parent; 		//If the menu does have a parent, then go to it
			i++;								//After adding more to depth var
		}

		return i;
	}
}