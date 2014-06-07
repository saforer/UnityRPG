using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum Team
{
    Player,
    Enemy
}

public class BattleUI : MonoBehaviour
{

    public List<Mob> uiPlayers;
    public List<Mob> uiEnemies;
    public Mob uiCurrentPlayer;
    public Mob uiCurrentEnemy;
    public MenuListing uiCurrentPlayerMenu;

    

    public bool PlayerMenuDrawing = false;


    void OnGUI()
    {
        WhatToDraw();
    }

    void WhatToDraw()
    {
        //Draw Allies
        //Draw Enemies

        if (PlayerMenuDrawing)
        {
            //Draw Player Menu
            DrawPlayerMenu(uiCurrentPlayerMenu);
        }
        //Draw Dialogue Box        
        //Draw Targetting Reticule
        //Draw Targetted Enemies
    }

    void DrawPlayerMenu(MenuListing inRootMenu)
    {

        int depth = FindDepth(inRootMenu);
        MenuListing tempSelection = inRootMenu;
        
        while (depth>=0)
        {
            DrawMenuBackground(tempSelection.childrenButtons.Count, depth);
            int i = 0;
            foreach (MenuButton button in tempSelection.childrenButtons)
            {
                DrawMenuButton(button, i, depth);
                i++;
            }

            tempSelection = tempSelection.parent;

            depth--;
        }
    }


    int FindDepth(MenuListing menuInput)
    {
        MenuListing tempMenu = menuInput;

        int i = 0;
        while (true)
        {
            if (tempMenu.parent == null) break; //If the menu has no parent, it's the root. We're done counting
            tempMenu = tempMenu.parent; 		//If the menu does have a parent, then go to it
            i++;								//After adding more to depth var
        }

        return i;
    }

    void DrawMenuBackground(int inCount, int inDepth)
    {
        //Find out where the menu should be drawn, and how big it should be
        int HorizontalLocation = 10 + (100 * inDepth);
        int BackgroundHeight = (50 * inCount);

        //Scope out how big the box should be
        Rect drawWhere = new Rect(HorizontalLocation, 10, 100, BackgroundHeight);

        Texture backgroundTexture = Resources.Load("MenuBox") as Texture;

        //Actually draw the background
        GUI.DrawTexture(drawWhere, backgroundTexture);
    }

    void DrawMenuButton(MenuButton inButton, int buttonNumber, int buttonDepth)
    {
        //Find out where the button should be drawn
        int HorizontalLocation = 10 + (100 * buttonDepth);
        int VerticalLocation = 10 + (buttonNumber * 50);

        //Scope out how big the button needs to be
        Rect drawWhere = new Rect(HorizontalLocation, VerticalLocation, 100, 50);

        //Actually draw the background of the button
        GUI.DrawTexture(drawWhere, inButton.CurrentTexture());

        //Give the button its text, the guistyle just has centered alignment
        GUI.Label(drawWhere, inButton.name);
    }
}
