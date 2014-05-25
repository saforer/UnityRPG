using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RPGmenu 
{
	public string name;
	public RPGmenu parent;
	public List<RPGmenu> children = new List<RPGmenu>();

	public RPGmenu (string inName, RPGmenu inParent)
    {
		name = inName;
		parent = inParent;
    }
}
