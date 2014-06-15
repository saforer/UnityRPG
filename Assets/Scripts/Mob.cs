using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class Mob : MonoBehaviour {
    public string mobName;
    public Sprite picture;
    public int speed;
    public List<Job> playerJob = new List<Job>();
    public List<ValidMove> metaMoveList;
    public List<ValidItem> itemList;


    public void SetSprite()
    {
        //Set Sprite in renderer
        gameObject.GetComponent<SpriteRenderer>().sprite = picture;
    }

    public MenuList CreatePlayerRoot()
    {
        MenuList rootMenu = new MenuList("RootMenu", null);
        rootMenu.childButtons.Add(CreateSkillsButton(rootMenu));
        rootMenu.childButtons.Add(CreateMetaButton(rootMenu));
        rootMenu.childButtons.Add(CreateItemButton(rootMenu));
        rootMenu.childButtons.Add(CreateRunButton());
        rootMenu.UpdateSelected();
        return rootMenu;
    }

    public MenuButton CreateSkillsButton(MenuList inRoot)
    {
        MenuButton skillsButton = new MenuButton("Skills", new MenuList("Skills Menu", inRoot));
        MenuList skillsMenu = skillsButton.childMenu;

        MenuButton atkButton = new MenuButton(ValidMove.Attack);
        skillsMenu.childButtons.Add(atkButton);

        foreach (Job job in playerJob)
        {
            MenuButton classButton = new MenuButton(job.name, new MenuList(job.name + " Menu", skillsMenu));
            foreach (ValidMove move in job.learnedMove)
            {
                classButton.childMenu.childButtons.Add(new MenuButton(move));
            }

            if (classButton.childMenu.childButtons.Count > 0)
                skillsMenu.childButtons.Add(classButton);
        }

        return skillsButton;
    }

    public MenuButton CreateMetaButton(MenuList inRoot)
    {
        MenuButton metaButton = new MenuButton("MetaMagic", new MenuList("Meta Menu", inRoot));
        MenuList metaMenu = metaButton.childMenu;
        foreach(ValidMove meta in metaMoveList)
        {
            metaMenu.childButtons.Add(new MenuButton(meta));
        }

        return metaButton;
    }

    public MenuButton CreateItemButton(MenuList inRoot)
    {
        MenuButton itemButton = new MenuButton("Item", new MenuList("Item Menu", inRoot));
        MenuList itemMenu = itemButton.childMenu;
        foreach(ValidItem item in itemList)
        {
            itemMenu.childButtons.Add(new MenuButton(item));
        }

        return itemButton;
    }

    public MenuButton CreateRunButton()
    {
        return new MenuButton(ValidMove.Run);
    }

    public BattleStep ThinkOfTurnToDo(Mob caster, List<Mob> inPlayer, List<Mob> inEnemy)
    {
        ValidMove moveToUse = ValidMove.Attack;

        List<ValidMove> moveCanUse = new List<ValidMove>();

        //Get a list of all the moves possible to be done
        moveCanUse.Add(ValidMove.Attack);

        foreach (Job job in playerJob)
        {
            foreach (ValidMove move in job.learnedMove)
            {
                moveCanUse.Add(move);
            }
        }

        //All the metamagic that can be done
        foreach (ValidMove move in metaMoveList)
        {
            moveCanUse.Add(move);
        }

        moveToUse = moveCanUse[Random.Range(0, moveCanUse.Count)];

        List<Mob> outTarget = new List<Mob>();
        MoveMgr movemgr = new MoveMgr();

        List<Target> targetList = movemgr.GetMove(moveToUse).neededTargets;

        foreach (Target target in targetList)
        {
            switch (target.teamTargetted)
            {
                default:
                case ValidTeam.Player:
                    outTarget.AddRange(inPlayer);
                    break;
                case ValidTeam.Enemy:
                    outTarget.AddRange(inEnemy);
                    break;
                case ValidTeam.All:
                    outTarget.AddRange(inEnemy);
                    outTarget.AddRange(inPlayer);
                    break;
            }
        }

        while (outTarget.Count > targetList[0].numberTargetted)
        {
            outTarget.RemoveAt(Random.Range(0, outTarget.Count));
        }

        return new BattleStep(caster, outTarget, moveToUse);
    }
}