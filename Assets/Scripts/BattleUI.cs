using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//This class controls the actual drawing of the UI
public class BattleUI : MonoBehaviour 
{
    public Texture backgroundTexture;
    public Texture reticule;
	
	public GUIStyle rpgGUIStyle;
	public GUIStyle rpgDialogueStyle;
	
	public int buttonHeight = 24;
	public int buttonWidth = 100;

	public List<Mob> playerTeam;
	public List<Mob> enemyTeam;
	public Mob selectedMob;

	//Send selectedMenuOption from other classes to the UI, so the UI can draw it.
	public RPGmenu selectedMenuOption;
	public string recentDialogue;
	public bool drawMenu = true;

    void OnGUI()
    {
		if (drawMenu) 
		{
			HowToDrawMenu ();
			DrawDialogue ();
		}

		DrawEnemyTeam(enemyTeam);

    }

	void DrawDialogue()
	{
		
		int x = 0;
		int y = 500;
		int wid = 960;
		int hei = 100;
		Rect location = new Rect(x,y,wid,hei);
		GUI.DrawTexture(location, backgroundTexture);
		GUI.Label(location, recentDialogue, rpgDialogueStyle);
	}

	void DrawEnemyTeam(List<Mob> inEnemy)
	{
		int i = 0;
		int j = inEnemy.Count;
		foreach(Mob enemyUnit in inEnemy)
		{
			DrawEnemyUnit(enemyUnit, i, j);
			i++;
		}
	}

	void DrawEnemyUnit(Mob inEnemy, int i, int j)
	{
		int wid = 100;
		int hei = 100;

		int x = 480;
		int y = 300;

		int spacing = 150;

		x += spacing * i;

		x -= (spacing * j)/2;



		Rect location = new Rect(x,y,wid,hei);
		GUI.DrawTexture(location,inEnemy.battlePicture);

        if (selectedMob == inEnemy)
        {
            DrawTargettingReticule(wid, hei, x, y);
        }
	}

	void DrawTargettingReticule(int inWid, int inHei, int inX, int inY)
	{
        Rect location = new Rect(inX-10, inY-10, inWid+20, inHei+20);
        GUI.DrawTexture(location, reticule);
	}

	//Call this method to update what menu is open.
	public void SetSelected(RPGmenu inMenu)
	{
		selectedMenuOption = inMenu;
	}

	void HowToDrawMenu()
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