using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class BattleLogic : MonoBehaviour {
    MobMgr mobmgr;
    BattleUI currentUI;
    
    //Teams to work with
    List<Mob> playerTeam;
    List<Mob> enemyTeam;
    List<Mob> playerTurnOrder;

    int currentPlayerInt = 0;


    MenuList currentMenu;

    BattleState currentState = BattleState.Init;



    void Start()
    {
        //setup mob manager
        mobmgr = new MobMgr();
        //set current UI
        currentUI = GameObject.FindGameObjectWithTag("GameController").GetComponent<BattleUI>();

        //Make teams
        playerTeam = GetTeam(ValidTeam.Player);
        enemyTeam = GetTeam(ValidTeam.Enemy);

        //Move teams to correct area
        MoveTeam(playerTeam, ValidTeam.Player);
        MoveTeam(enemyTeam, ValidTeam.Enemy);

        //Find player turn order
        playerTurnOrder = playerTeam.OrderByDescending(player => player.speed).ToList();

        UpdateUI();

        currentState = BattleState.SetupMenu;
    }

    void UpdateUI()
    {
        currentUI.uiPlayerTeam = playerTeam;
        currentUI.uiEnemyTeam = enemyTeam;
        currentUI.uiSelectedPlayer = playerTurnOrder[currentPlayerInt];
        currentUI.uiPlayerMenu = currentMenu;
    }

    void Update()
    {
        switch (currentState)
        {
            case BattleState.Init:
                break;
            case BattleState.SetupMenu:
                MenuSetup();
                break;
            case BattleState.Menu:
                Menu();
                break;
            case BattleState.SetupTarget:
                TargetSetup();
                break;
            case BattleState.Target:
                Target();
                break;
            case BattleState.EndPlayerStep:
                EndPlayer();
                break;
            case BattleState.EnemyStep:
                EnemyTurn();
                break;
            case BattleState.ActionStep:
                Action();
                break;
        }
    }

    void MenuSetup()
    {
        currentMenu = playerTurnOrder[currentPlayerInt].CreatePlayerRoot();
        currentUI.uiPlayerMenu = currentMenu;
        

        currentState = BattleState.Menu;
    }

    void Menu()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            currentMenu.MoveUp();
            UpdateUI();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            currentMenu.MoveDown();
            UpdateUI();
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (currentMenu.CanRight())
            {
                currentMenu = currentMenu.GoRight();
                currentMenu.UpdateSelected();
                UpdateUI();
            }
            else if (currentMenu.CanMove())
            {
                DoMove(currentMenu.GetMove());
            }
            else if (currentMenu.CanItem())
            {
                UseItem(currentMenu.GetItem());
            }
        }

        if (Input.GetKeyDown(KeyCode.X) && currentMenu.CanLeft())
        {
            currentMenu = currentMenu.GoLeft();
            UpdateUI();
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("------------PlayerTeam----------");
            foreach (Mob mob in playerTeam)
            {
                Debug.Log(mob.name);
            }
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("------------EnemyTeam----------");
            foreach (Mob mob in enemyTeam)
            {
                Debug.Log(mob.name);
            }
        }
    }

    void DoMove(ValidMove inMove)
    {
        Debug.Log(inMove);
    }

    void UseItem(ValidItem inItem)
    {
        Debug.Log(inItem);
    }

    void TargetSetup()
    {


        currentState = BattleState.SetupTarget;
    }

    void Target()
    {

    }

    void EndPlayer()
    {

    }

    void EnemyTurn()
    {

    }

    void Action()
    {

    }

    List<Mob> GetTeam(ValidTeam teamIn)
    {
        List<Mob> tempList = new List<Mob>();
        GameObject tempMobject;
        ValidMob toMake;
        switch (teamIn)
        {
            case ValidTeam.Enemy:
                toMake = ValidMob.Jelly;
                break;
            default:
            case ValidTeam.Player:
                toMake = ValidMob.Player;
                break;
        }

        tempMobject = Instantiate(Resources.Load("GameObject/Mobject"), Vector3.zero, Quaternion.identity) as GameObject;
        mobmgr.CreateMob(tempMobject, toMake);
        tempList.Add(tempMobject.GetComponent<Mob>());

        return tempList;
    }

    void MoveTeam (List<Mob> inTeam, ValidTeam teamType)
    {
        int i = 0;
        int j = inTeam.Count();
        foreach (Mob mob in inTeam)
        {
            MoveUnit(mob, i, j, teamType);
            i++;
        }
    }

    void MoveUnit(Mob inMob, int i, int j, ValidTeam inTeam)
    {
        Vector3 tempPos = Vector3.zero;
        float spacing = .9f;

        tempPos.x += (i * spacing);
        tempPos.x -= (j * spacing) / 2;

        switch (inTeam)
        {
            default:
            case ValidTeam.Player:
                tempPos.y -= 2;
                break;
            case ValidTeam.Enemy:
                tempPos.y += 2;
                break;
        }

        inMob.transform.position = tempPos;
    }
}

public enum ValidTeam
{
    Player,
    Enemy
}

public enum BattleState
{
    Init,
    SetupMenu,
    Menu,
    SetupTarget,
    Target,
    EndPlayerStep,
    EnemyStep,
    ActionStep
}