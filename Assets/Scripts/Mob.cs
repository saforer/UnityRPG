using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Mob : MonoBehaviour {
    SpriteRenderer thisRenderer;

    //Mob Variables
    public ValidMob typeOfMob;
    public Sprite mobSprite;
    public int speed = 500;


    public List<Job> playerJobs = new List<Job>();
    public List<ValidItem> items = new List<ValidItem>();
    public List<ValidMove> metaMagic = new List<ValidMove>();

    public void IsMob(ValidMob inMobType)
    {
        typeOfMob = inMobType;

        //Get the sprite renderer for this game object.
        thisRenderer = gameObject.GetComponent<SpriteRenderer>();

        MobManager mobManager = new MobManager();

        //Name
        name = mobManager.GetMobName(inMobType);

        //Jobs
        playerJobs = mobManager.GetJobs(inMobType);

        //Items
        items = mobManager.GetItems(inMobType);

        //MetaMagic
        metaMagic = mobManager.GetMetaMagic(inMobType);

        //Sprite
        mobSprite = mobManager.GetPicture(typeOfMob);

        //Set the picture from the mob manager
        thisRenderer.sprite = mobSprite;
    }

    public Job AddJob(ValidJobs inJob, List<ValidMove> inMoves)
    {
        JobManager jobManager = new JobManager();
        Job tempJob = jobManager.LoadJob(inJob);

        foreach (ValidMove moves in inMoves)
        {
            tempJob.learnedSkills.Add(moves);
        }

        return tempJob;
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

        MoveManager moveManager = new MoveManager();
        Move attackMove = moveManager.GetMove(ValidMove.Attack);
        MenuButton attackButton = new MenuButton(attackMove.name);

        foreach (Job job in playerJobs)
        {
            MenuButton classButton = new MenuButton(job.name);
            MenuListing classMenu = new MenuListing(job.name.ToString() + "Menu", skillsButton.childMenu);
            classButton.childMenu = classMenu;

            foreach (ValidMove move in job.learnedSkills)
            {
                ValidMove classMove = move;
                MenuButton moveButton = new MenuButton(classMove);
                moveButton.childMove = classMove;
                classMenu.childrenButtons.Add(moveButton);
            }

            if (classButton.childMenu.childrenButtons.Count > 0)
                skillsMenu.childrenButtons.Add(classButton);
        }

        return skillsButton;
    }

    MenuButton CreateMetaMagic(MenuListing inRoot)
    {
        MenuButton metaMagicButton = new MenuButton("MetaMagic");
        MenuListing metaMenu = new MenuListing("MetaMagicMenu", inRoot);

        metaMagicButton.childMenu = metaMenu;

        foreach (ValidMove move in metaMagic)
        {
            MoveManager moveManager = new MoveManager();
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

        foreach (ValidItem item in items)
        {
            ItemManager itemManager = new ItemManager();
            Item tempItem = itemManager.GetItem(item);
            MenuButton moveButton = new MenuButton(tempItem.name);
            moveButton.childItem = tempItem;
            itemMenu.childrenButtons.Add(moveButton);
        }

        return itemButton;
    }

    MenuButton CreateRunButton()
    {
        MoveManager moveManager = new MoveManager();
        MenuButton runButton = new MenuButton("Run");
        runButton.childMove = moveManager.GetMove(ValidMove.Run);

        return runButton;
    }
}