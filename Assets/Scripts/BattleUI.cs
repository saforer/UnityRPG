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
        

        DrawMenu(currentLogic.mainMenu, currentLogic.currentDepth);
        
    }

    void DrawMenu (RPGmenu inMenu, int inDepth)
    {
		RPGmenu tempMenu = inMenu;

		for (int i = 0; i <= inDepth; i++)
		{
			DrawBackground(i);
			int j = 0;
			foreach (RPGButton button in tempMenu.children)
			{
				DrawOption(button,j,i);
				j++;
			}
			tempMenu = tempMenu.OneDeeper();
		}

    }

	void DrawBackground(int inDepth)
	{
		GUI.DrawTexture(new Rect(((100*inDepth)+10), 10, 100, ((18*5)+2)), backgroundTexture);
	}

    void DrawOption(RPGButton inButton, int inVert, int inHoriz)
    {
        int h = (10 + (100 * inHoriz));
        int v = (10 + (18 * inVert));
        GUI.DrawTexture(new Rect(h, v, 100, 20), inButton.OutputTexture());
        GUI.Label(new Rect((h + 15), v, 100, 20), inButton.label);
    }

}