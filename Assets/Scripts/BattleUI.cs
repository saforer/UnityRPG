using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BattleUI : MonoBehaviour 
{
    private BattleLogic currentLogic;

    public Texture backgroundTexture;

	public RPGmenu selectedMenuOption;

    void Start()
    {
        currentLogic = GetComponent<BattleLogic>();
    }

    void OnGUI()
    {
		Draw ();
    }

	public void SetSelected(RPGmenu inMenu)
	{
		selectedMenuOption = inMenu;
	}

	void Draw()
	{
		int depth = FindDepth(selectedMenuOption);

		while (depth>=0)
		{
			DrawBox(selectedMenuOption, depth);
			depth--;
		}
	}

	void DrawBox(RPGmenu inMenu, int inDepth)
	{
		GUI.DrawTexture(new Rect(((100*inDepth)+10), 10, 100, ((18*5)+2)), backgroundTexture);
	}

	int FindDepth(RPGmenu menuInput)
	{
		RPGmenu tempMenu = menuInput;
		int i = 0;
		while (true)
		{
			if (tempMenu.parent == null) 
				break;
			tempMenu = tempMenu.parent;
			i++;
		}

		return i;
	}
}