using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum Rows
{
    Front,
    Middle,
    Back
}

public class Mob
{
    public Texture battlePicture;
    public string name;
    public int speed;
    public Rows row;
    TextureLoader currentTexLoad;

    JobManager jobManager = new JobManager();
    MoveManager moveManager = new MoveManager();
    ItemManager itemManager = new ItemManager();

    public List<Job> playerJobs = new List<Job>();
    public List<ValidItems> items = new List<ValidItems>();
    public List<ValidMoves> metaMagic = new List<ValidMoves>();

    public Mob(string inName, List<ValidItems> inItemsList, List<ValidMoves> inMetaList, ValidSprites inSprite)
    {
        currentTexLoad = GameObject.FindGameObjectWithTag("GameController").GetComponent<TextureLoader>();

        name = inName;


       //battlePicture = Resources.Load("Jelly") as Texture;

	

        metaMagic = inMetaList;
        items = inItemsList;


        int rowInt = UnityEngine.Random.Range(0,3);
        switch (rowInt)
        {
            case 0:
                row = Rows.Front;
                break;
            case 1:
                row = Rows.Middle;
                break;
            case 2:
                row = Rows.Back;
                break;
        }

        speed = UnityEngine.Random.Range(0, 1000);

    }

    public MenuListing CreateRoot()
    {
        MenuListing rootMenu = new MenuListing("root", null);
        rootMenu.childrenButtons.Add(CreateSkillsButton(rootMenu));
        rootMenu.childrenButtons.Add(CreateMetaMagic(rootMenu));
        rootMenu.childrenButtons.Add(CreateItemButton(rootMenu));
        rootMenu.childrenButtons.Add(CreateRunButton());
        rootMenu.UpdateSelected();
        return rootMenu;
    }

    MenuButton CreateSkillsButton(MenuListing inRoot)
    {
        MenuButton skillsButton = new MenuButton("Skills");
        MenuListing skillsMenu = new MenuListing("SkillsMenu", inRoot);
        skillsButton.childMenu = skillsMenu;

        Move attackMove = moveManager.GetMove(ValidMoves.Attack);
        MenuButton attackButton = new MenuButton(attackMove.name);

        foreach (Job job in playerJobs)
        {
            MenuButton classButton = new MenuButton(job.name);
            MenuListing classMenu = new MenuListing(job.name.ToString() + "Menu", skillsButton.childMenu);
            classButton.childMenu = classMenu;

            foreach (ValidMoves move in job.learnedSkills)
            {
                Move classMove = moveManager.GetMove(move);
                MenuButton moveButton = new MenuButton(classMove.name);
                moveButton.childMove = classMove;
                classMenu.childrenButtons.Add(moveButton);
            }

            if (classButton.childMenu.childrenButtons.Count>0)
                skillsMenu.childrenButtons.Add(classButton);
        }

        return skillsButton;
    }

    MenuButton CreateMetaMagic(MenuListing inRoot)
    {
        MenuButton metaMagicButton = new MenuButton("MetaMagic");
        MenuListing metaMenu = new MenuListing("MetaMagicMenu", inRoot);
        
        metaMagicButton.childMenu = metaMenu;

        foreach (ValidMoves move in metaMagic)
        {
            Move classMove = moveManager.GetMove(move);
            MenuButton moveButton = new MenuButton(classMove.name);
            moveButton.childMove = classMove;
            metaMenu.childrenButtons.Add(moveButton);
        }

        return metaMagicButton;
    }

    MenuButton CreateItemButton(MenuListing inRoot)
    {
        MenuButton itemButton = new MenuButton("Item");
        MenuListing itemMenu = new MenuListing("ItemMenu", inRoot);
        itemButton.childMenu = itemMenu;

        foreach (ValidItems item in items)
        {
            Item tempItem = itemManager.GetItem(item);
            MenuButton moveButton = new MenuButton(tempItem.name);
            moveButton.childItem = tempItem;
            itemMenu.childrenButtons.Add(moveButton);
        }

        return itemButton;
    }

    MenuButton CreateRunButton()
    {
        MenuButton runButton = new MenuButton("Run");
        runButton.childMove = moveManager.GetMove(ValidMoves.Run);

        return runButton;
    }
}

