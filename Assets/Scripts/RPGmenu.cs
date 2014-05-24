using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RPGmenu 
{
	public int depth = 0;

    public int selectedOption = 0;

	public bool more = false;

    public List<RPGButton> children = new List<RPGButton>();

    public RPGmenu (int inDepth)
    {
		depth = inDepth;
    }

	public RPGmenu OneDeeper ()
	{
		RPGmenu tempMenu = children[selectedOption].childMenu;
		return tempMenu;
	}

	public int GrowTo (int depthToReach)
	{
		if (depthToReach == depth)
		{
			return depthToReach;
		}
		else
		{
			//Is there a lower level
			if (children[selectedOption].container)
			{
				return children[selectedOption].childMenu.GrowTo(depthToReach);
			}
			else
			{
				return depth;
			}
		}
	}
}
