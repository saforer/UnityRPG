using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BattleUI : MonoBehaviour 
{
    private BattleLogic currentLogic;

    public Texture backgroundTexture;

    void Start()
    {
        currentLogic = GetComponent<BattleLogic>();
    }

    void OnGUI()
    {
        DrawBackground();

        DrawMenu(currentLogic.mainMenu);
        
    }

    void DrawBackground()
    {
        GUI.DrawTexture(new Rect(10, 10, 100, ((18*5)+2)), backgroundTexture);
    }

    void DrawMenu (RPGmenu inMenu)
    {
        RPGmenu tempMenu = inMenu;
        int vert = 0;
        foreach (RPGButton button in tempMenu.children)
        {
            DrawOption(button,vert,0);
            vert++;
        }
    }

    void DrawOption(RPGButton inButton, int inVert, int inHoriz)
    {
        int h = (10 + (100 * inHoriz));
        int v = (10 + (18 * inVert));
        GUI.DrawTexture(new Rect(h, v, 100, 20), inButton.OutputTexture());
        GUI.Label(new Rect((h + 15), v, 100, 20), inButton.label);
    }

}