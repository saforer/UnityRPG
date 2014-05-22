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

    void DrawMenu (List<RPGmenu> inList)
    {
        List<RPGmenu> tempList = inList;

        int horiz = 0;
        foreach (RPGmenu menu in tempList)
        {
            int vert = 0;
            foreach (RPGButton button in menu.children)
            {
                DrawOption(button,vert,horiz);
                vert++;
            }

            horiz++;
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