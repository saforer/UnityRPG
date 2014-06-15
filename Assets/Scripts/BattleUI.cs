using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class BattleUI : MonoBehaviour {
    public List<Mob> uiPlayerTeam;
    public List<Mob> uiEnemyTeam;
    public Mob uiCurrentPlayer;
    public Mob uiSelectedPlayer;
    public Mob uiSelectedEnemy;
    public MenuList uiPlayerMenu;
    public Mob uiCurrentTarget;
    public List<Mob> uiCurrentTargettedList = new List<Mob>();
    public bool drawMenu = false;
    public string uiText;
    public string stepString;

    void OnGUI()
    {
        if (drawMenu)
            DrawPlayerMenu(uiPlayerMenu);

        if (uiCurrentPlayer != null)
            DrawReticule(uiCurrentPlayer, 0);

        if (uiCurrentTarget != null)
            DrawReticule(uiCurrentTarget, 0);

        if (uiCurrentTargettedList.Count > 0)
        {
            foreach(Mob mob in uiCurrentTargettedList)
            {
                DrawReticule(mob, 1);
            }
        }

        GUI.Label(new Rect(760, 0, 100, 40), uiText);

        GUI.Label(new Rect(760, 200, 100, 300), stepString);
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

    public void DrawReticule(Mob inUnit, int inType)
    {
        Bounds spriteBounds = inUnit.GetComponent<SpriteRenderer>().sprite.bounds;
        Vector3 centerObject = Camera.main.WorldToScreenPoint(new Vector3(inUnit.transform.position.x, inUnit.transform.position.y, 0));

        //Center is now in gui coordinates 0 0 top left
        centerObject.y = Screen.height - centerObject.y;

        Vector3 topLeft = Camera.main.WorldToScreenPoint(new Vector3(spriteBounds.min.x, spriteBounds.max.y, 0));
        Vector3 bottomRight = Camera.main.WorldToScreenPoint(new Vector3(spriteBounds.max.x, spriteBounds.min.y, 0));

        topLeft.y = Screen.height - topLeft.y;
        bottomRight.y = Screen.height - bottomRight.y;


        Rect Location = new Rect(centerObject.x - ((bottomRight.x - topLeft.x) / 2), centerObject.y + ((bottomRight.y - topLeft.y) / 2), bottomRight.x - topLeft.x, topLeft.y - bottomRight.y);

        Texture reticuleTexture = Resources.Load("Reticule") as Texture;

        GUI.DrawTexture(Location, reticuleTexture);
    }
}
