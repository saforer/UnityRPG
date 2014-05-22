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

        DrawMenu(currentLogic.totalList);
        
    }

    void DrawBackground()
    {
        GUI.DrawTexture(new Rect(10, 10, 100, ((18*5)+2)), backgroundTexture);
    }

    void DrawMenu(List<List<RPGButton>> listToDraw)
    {
        List<List<RPGButton>> tempMaster = listToDraw;
        int i = 0;
        foreach (List<RPGButton> sublist in tempMaster)
        {
            DrawSubMenu(sublist, i);
            i++;
        }
    }

    void DrawSubMenu (List<RPGButton> inSublist, int depth)
    {
        int j = 0;
        foreach (RPGButton btn in inSublist)
        {
            DrawOption(btn, depth, j);
            j++;
        }
    }

    void DrawOption (RPGButton buttonIn,int inDepth, int optionNumber)
    {
        int v = (10 + (18 * optionNumber));
        int h = (10 + (100 * inDepth));
        GUI.DrawTexture(new Rect(h, v, 100, 20), buttonIn.OutputTexture());
        GUI.Label(new Rect((h+15), v, 100, 20), buttonIn.label);
    }
}