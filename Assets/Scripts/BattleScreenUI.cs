using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BattleScreenUI : MonoBehaviour {

    public Camera currentCamera;
    public List<GameObject> uiPlayerTeam;
    public List<GameObject> uiEnemyTeam;
    public GameObject uiCurrentPlayer;
    public GameObject uiCurrentEnemy;
    public MenuListing uiCurrentMenu;
    public string uiString;
    public bool playerMenuDrawing = false;

    void OnGUI()
    {
        if (uiCurrentMenu != null)
            DrawMenu(uiCurrentMenu);
        if (uiCurrentPlayer != null)
        {
            DrawReticule(uiCurrentPlayer);
        }
    }

    void DrawMenu(MenuListing inMenu)
    {
        int depth = FindDepth(inMenu);

        MenuListing tempMenu = inMenu;

        while (depth>=0)
        {
            DrawMenuBackground(tempMenu.childrenButtons.Count,depth);
            int i = 0;
            foreach (MenuButton button in tempMenu.childrenButtons)
            {
                DrawMenuButton(button, i, depth);
                i++;
            }

            tempMenu = tempMenu.parent;
            depth--;
        }

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

    int FindDepth(MenuListing inMenu)
    {
        int i = 0;
        while (true)
        {
            if (inMenu.parent == null) break;
            inMenu = inMenu.parent;
            i++;
        }

        return i;
    }

    void DrawReticule(GameObject inUnit)
    {
        Bounds spriteBounds = inUnit.GetComponent<SpriteRenderer>().sprite.bounds;
        Vector3 centerObject = Camera.main.WorldToScreenPoint(new Vector3(inUnit.transform.position.x, inUnit.transform.position.y, 0));

        //Center is now in gui coordinates 0 0 top left
        centerObject.y = Screen.height - centerObject.y;

        Vector3 topLeft = Camera.main.WorldToScreenPoint(new Vector3(spriteBounds.min.x, spriteBounds.max.y, 0));
        Vector3 bottomRight = Camera.main.WorldToScreenPoint(new Vector3(spriteBounds.max.x, spriteBounds.min.y, 0));

        topLeft.y = Screen.height - topLeft.y;
        bottomRight.y = Screen.height - bottomRight.y;


        Rect Location = new Rect(centerObject.x - ((bottomRight.x - topLeft.x)/2), centerObject.y + ((bottomRight.y - topLeft.y)/2), bottomRight.x - topLeft.x, topLeft.y - bottomRight.y);
        //Location = new Rect(0, 0, 100, 100);
        GUI.DrawTexture(Location, Resources.Load("Reticule") as Texture);
    }
}