using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class BattleUI : MonoBehaviour {
    public List<Mob> uiPlayerTeam;
    public List<Mob> uiEnemyTeam;
    public Mob uiSelectedPlayer;
    public Mob uiSelectedEnemy;
    public MenuList uiPlayerMenu;

    void OnGUI()
    {
        if (uiPlayerMenu != null)
        {
            DrawPlayerMenu(uiPlayerMenu);
        }
    }

    void DrawPlayerMenu(MenuList inMenu)
    {
        int depth = FindDepth(inMenu);

        MenuList tempSelection = inMenu;

        while (depth >= 0)
        {
            DrawMenuBackground(tempSelection.childButtons.Count, depth);
            int i = 0;
            foreach (MenuButton button in tempSelection.childButtons)
            {
                DrawMenuButton(button, i, depth);
                i++;
            }

            tempSelection = tempSelection.parent;

            depth--;
        }
    }

    void DrawMenuBackground(int i, int j)
    {
        //Find out where the menu should be drawn, and how big it should be
        int HorizontalLocation = 10 + (100 * j);
        int BackgroundHeight = (50 * i);

        //Scope out how big the box should be
        Rect drawWhere = new Rect(HorizontalLocation, 10, 100, BackgroundHeight);

        Texture backgroundTexture = Resources.Load("MenuBox") as Texture;

        //Actually draw the background
        GUI.DrawTexture(drawWhere, backgroundTexture);
    }

    void DrawMenuButton(MenuButton inButton, int i, int j)
    {
        //Find out where the button should be drawn
        int HorizontalLocation = 10 + (100 * j);
        int VerticalLocation = 10 + (i * 50);

        //Scope out how big the button needs to be
        Rect drawWhere = new Rect(HorizontalLocation, VerticalLocation, 100, 50);

        //Actually draw the background of the button
        GUI.DrawTexture(drawWhere, inButton.currentTexture());

        //Give the button its text, the guistyle just has centered alignment
        GUI.Label(drawWhere, inButton.name);
    }

    int FindDepth(MenuList inMenu)
    {
        MenuList tempMenu = inMenu;

        int i = 0;
        while (true)
        {
            if (tempMenu.parent == null) break; 
            tempMenu = tempMenu.parent; 		
            i++;								
        }

        return i;
    }
}
