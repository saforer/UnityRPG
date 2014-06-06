using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Mob
{
    Texture battlePicture;
    public string name;
    public int speed;


    public List<Move> moves;
    public List<Item> items;

    public Mob(string inName)
    {
        name = inName;
        battlePicture = Resources.Load("Jelly") as Texture;
        speed = UnityEngine.Random.Range(0, 1000);

    }

    public MenuListing CreateRoot()
    {
        MenuListing rootMenu = new MenuListing("root", null);
        rootMenu.AddChildButton("Wizard");
        Debug.Log(rootMenu.childrenButtons[0].name);

        return rootMenu;
    }
}

