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
        MenuListing tempMenu;

        rootMenu.childrenButtons.Add(new MenuButton("Skills"));
        rootMenu.childrenButtons[0].childMenu = new MenuListing("Skills Menu",rootMenu);
        tempMenu = rootMenu.childrenButtons[0].childMenu;

        tempMenu.childrenButtons.Add(new MenuButton("Ninja"));
        tempMenu.childrenButtons[0].childMenu = new MenuListing("Ninja Menu", tempMenu);
        tempMenu = tempMenu.childrenButtons[0].childMenu;

        tempMenu.childrenButtons.Add(new MenuButton("Akujiki"));
        tempMenu.childrenButtons[0].childMove = new Move("Akujiki");
     
        rootMenu.childrenButtons.Add(new MenuButton("MetaMagic"));
        rootMenu.childrenButtons[1].childMenu = new MenuListing("MetaMagic Menu", rootMenu);
        tempMenu = rootMenu.childrenButtons[1].childMenu;
        
        rootMenu.childrenButtons.Add(new MenuButton("Magic"));
        rootMenu.childrenButtons[2].childMenu = new MenuListing("Magic Menu", rootMenu);
        tempMenu = rootMenu.childrenButtons[2].childMenu;
        
        rootMenu.childrenButtons.Add(new MenuButton("Items"));
        rootMenu.childrenButtons[3].childMenu = new MenuListing("Items Menu", rootMenu);
        tempMenu = rootMenu.childrenButtons[3].childMenu;
        
        rootMenu.childrenButtons.Add(new MenuButton("Run"));
        tempMenu = rootMenu.childrenButtons[4].childMenu;

        return rootMenu;
    }
}

