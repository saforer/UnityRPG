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

        List<RPGButton> toDraw = currentLogic.menuList;
        int i = 0;
        foreach (RPGButton input in toDraw)
        {
            DrawOption(input,i);
            i++;
        }
    }

    void DrawBackground()
    {
        GUI.DrawTexture(new Rect(10, 10, 100, ((18*5)+2)), backgroundTexture);
    }

    void DrawOption(RPGButton buttonIn, int selectionNumber)
    {
        //TEMPORARY
        int depth = 0;
        int v = (10 + (18 * selectionNumber));
        int h = (10 + (100 * depth));
        GUI.DrawTexture(new Rect(h, v, 100, 20), buttonIn.OutputTexture());
        GUI.Label(new Rect((h+15), v, 100, 20), buttonIn.label);
    }
}