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
        Debug.Log("Depth: " + depth);
        
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
}
