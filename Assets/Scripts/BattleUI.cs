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

    [HideInInspector]
    string uiString = "Can't actually DO moves yet, but try to select them anyway. Z X Up and Down are controls";

    public bool PlayerMenuDrawing = false;


    void OnGUI()
    {
        WhatToDraw();
    }

    void WhatToDraw()
    {
        //Draw Allies
        DrawTeamPlayer(uiPlayers);
        //Draw Enemies
        DrawTeamEnemy(uiEnemies);

        if (PlayerMenuDrawing)
        {
            //Draw Player Menu
            DrawPlayerMenu(uiCurrentPlayerMenu);
        }
        //Draw Dialogue Box
        DrawTextBox(uiString);
        //Draw Targetting Reticule
        //Draw Targetted Enemies
    }

    void DrawTeamPlayer(List<Mob> inPlayers)
    {
        int i = 0;
        int j = inPlayers.Count;
        foreach (Mob mob in inPlayers)
        {
            DrawPlayerUnit(mob, i, j);
            i++;
        }
    }

    void DrawPlayerUnit(Mob inMob, int i, int j)
    {
        int wid = 50;
        int hei = 50;
        int x = 480;
        int y = 430;
        int spacing = 50;

        int rowInt;
        switch (inMob.row)
        {
            case Rows.Front:
                rowInt = 0;
                break;
            case Rows.Middle:
                rowInt = 1;
                break;
            default:
                rowInt = 2;
                break;
        }

        x += spacing * i;

        x -= (spacing * j) / 2;

        y += rowInt * 50;

        Rect Location = new Rect(x, y, wid, hei);

        if (inMob == uiCurrentPlayer)
        {
            DrawSelectionBox(Location);
        }

        GUI.DrawTexture(Location, Resources.Load("Thief/Player") as Texture);
        

    }

    void DrawSelectionBox(Rect inLocation)
    {
        Rect outLocation = inLocation;
        const int grow = 10;
        outLocation.width  += grow;
        outLocation.height += grow;
        outLocation.x -= grow / 2;
        outLocation.y -= grow / 2;
        Texture reticule = Resources.Load("MenuButtonOff") as Texture;
        GUI.DrawTexture(outLocation, reticule);
    }

    void DrawTeamEnemy(List<Mob> inEnemy)
    {   
        int i = 0;
        int j = inEnemy.Count;

        foreach (Mob mob in inEnemy)
        {
            DrawEnemyUnit(mob, i, j);
            i++;
        }

        
    }

    void DrawEnemyUnit(Mob inMob, int i, int j)
    {
        int wid = 75;
        int hei = wid;
        int x = 480;
        int y = 150;

        int spacing = wid;

        

        x += spacing * i;

        x -= (spacing * j) / 2;

        int rowInt;
        switch (inMob.row)
        {
            case Rows.Front:
                rowInt = 0;
                break;
            case Rows.Middle:
                rowInt = 1;
                break;
            default:
                rowInt = 2;
                break;
        }

        y -= rowInt * 50;
        y += rowInt * 20;
        wid -= rowInt * 10;
        hei = wid;



        Rect Location = new Rect(x, y, wid, hei);
        if (inMob == uiCurrentEnemy)
            DrawSelectionBox(Location);

        GUI.DrawTexture(Location, inMob.battlePicture);
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

    void DrawTextBox(string inString)
    {
        GUI.Label(new Rect(450 - 150, 300 - 25, 300, 50), inString);
    }

    public void SetTextBox(string inString)
    {
        uiString = inString;
    }
}
