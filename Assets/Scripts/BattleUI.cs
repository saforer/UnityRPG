using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BattleUI : MonoBehaviour 
{
    private BattleLogic currentLogic;

    void Start()
    {
        currentLogic = GetComponent<BattleLogic>();
    }

    void OnGUI()
    {
        List<RPGButton> toDraw = currentLogic.menuList;
        int i = 0;
        foreach (RPGButton input in toDraw)
        {
            DrawOption(input,i);
            i++;
        }
    }

    void DrawOption(RPGButton buttonIn, int i)
    {
        int h = (10 + (18 * i));
        GUI.DrawTexture(new Rect(10, h, 100, 20), buttonIn.OutputTexture());
        GUI.Label(new Rect(25, h, 100, 20), buttonIn.label);
    }
}