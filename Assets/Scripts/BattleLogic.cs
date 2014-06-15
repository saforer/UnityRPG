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
    List<Mob> enemyTurnOrder;
    

    int currentPlayerInt = 0;

    MenuList currentMenu;

    List<Target> moveTargets;
    List<Mob> validTargets = new List<Mob>();
    List<Mob> mobTargetable;

    int currentTargetSet = 0;
    int currentTargettedMob = 0;

    List<BattleStep> playerActionList;
    List<BattleStep> enemyActionList;
    List<BattleStep> finalActionList;

    bool usingMove = false;
    ValidMove moveToUse;
    ValidItem itemToUse;

    public BattleState currentState = BattleState.Init;



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

        playerActionList = new List<BattleStep>();

        currentState = BattleState.SetupMenu;
    }

    void UpdateUI()
    {
        currentUI.uiPlayerTeam = playerTeam;
        currentUI.uiEnemyTeam = enemyTeam;
        currentUI.uiCurrentPlayer = playerTurnOrder[currentPlayerInt];
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
        currentUI.uiText = currentState.ToString();
    }

    void MenuSetup()
    {
        currentUI.uiCurrentTarget = null;
        currentMenu = playerTurnOrder[currentPlayerInt].CreatePlayerRoot();
        currentUI.uiPlayerMenu = currentMenu;
        currentUI.drawMenu = true;
        

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
                moveToUse = currentMenu.GetMove();
                GetMoveCount(currentMenu.GetMove());
            }
            else if (currentMenu.CanItem())
            {
                
                itemToUse = currentMenu.GetItem();
                GetItemCount(currentMenu.GetItem());
            }
        }

        if (Input.GetKeyDown(KeyCode.X) && currentMenu.CanLeft())
        {
            currentMenu = currentMenu.GoLeft();
            UpdateUI();
        }
    }

    void GetMoveCount(ValidMove inMove)
    {
        MoveMgr movemgr = new MoveMgr();
        moveTargets = movemgr.GetMove(inMove).neededTargets;
        usingMove = true;

        currentState = BattleState.SetupTarget;
    }

    void GetItemCount(ValidItem inItem)
    {
        ItemMgr itemmgr = new ItemMgr();
        moveTargets = itemmgr.GetItem(inItem).neededTargets;
        usingMove = false;

        currentState = BattleState.SetupTarget;
    }

    void TargetSetup()
    {
        validTargets = new List<Mob>();
        currentUI.drawMenu = false;
        currentTargettedMob = 0;
        

        mobTargetable = new List<Mob>();

        if ((moveTargets[currentTargetSet].teamTargetted == ValidTeam.Player) || (moveTargets[currentTargetSet].teamTargetted == ValidTeam.All))
        {
            foreach (Mob player in playerTeam)
            {
                mobTargetable.Add(player);
            }
        }

        if ((moveTargets[currentTargetSet].teamTargetted == ValidTeam.Enemy) || (moveTargets[currentTargetSet].teamTargetted == ValidTeam.All))
        {
            foreach (Mob enemy in enemyTeam)
            {
                mobTargetable.Add(enemy);
            }
        }

        currentUI.uiCurrentTarget = mobTargetable[currentTargettedMob];
        currentState = BattleState.Target;
    }

    void Target()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (currentTargettedMob > 0)
            {
                currentTargettedMob--;
                
            }
            else
            {
                currentTargettedMob = 0;
            }
            currentUI.uiCurrentTarget = mobTargetable[currentTargettedMob];
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (currentTargettedMob < mobTargetable.Count-1)
            {
                currentTargettedMob++;
            }
            else
            {
                currentTargettedMob = mobTargetable.Count-1;
            }
            currentUI.uiCurrentTarget = mobTargetable[currentTargettedMob];
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (validTargets.Contains(mobTargetable[currentTargettedMob]))
            {
                validTargets.Remove(mobTargetable[currentTargettedMob]);
            }
            else
            {
                validTargets.Add(mobTargetable[currentTargettedMob]);
            }
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            currentUI.uiCurrentTarget = null;

            currentState = BattleState.SetupMenu;
        }
        if (moveTargets[currentTargetSet].numberTargetted == validTargets.Count)
        {
            if (moveTargets.Count-1 > currentTargetSet)
            {
                currentTargetSet++;
            }
            else 
            {
                if (usingMove) playerActionList.Add(new BattleStep(playerTurnOrder[currentPlayerInt], validTargets, moveToUse));
                if (!usingMove) playerActionList.Add(new BattleStep(playerTurnOrder[currentPlayerInt], validTargets, itemToUse));

                currentUI.stepString = "-------";

                foreach(BattleStep step in playerActionList)
                {
                    currentUI.stepString += step.ToString();
                }

                currentState = BattleState.EndPlayerStep;
            }
        }
    }

    void EndPlayer()
    {
        validTargets = new List<Mob>();
        mobTargetable = new List<Mob>();
        
        if (playerTurnOrder.Count-1 == currentPlayerInt)
        {
            currentState = BattleState.EnemyStep;
        }
        else
        {
            currentPlayerInt++;
            UpdateUI();
            currentState = BattleState.SetupMenu;
        }
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


        for (int i = 0; i < 5; i++)
        {
            switch (teamIn)
            {
                case ValidTeam.Enemy:
                    switch (Random.Range(0, 2))
                    {
                        default:
                        case 0:
                            toMake = ValidMob.Jelly;
                            break;
                        case 1:
                            toMake = ValidMob.Skeleton;
                            break;
                    }
                    break;
                default:
                case ValidTeam.Player:
                    toMake = ValidMob.Player;
                    break;
            }

            tempMobject = Instantiate(Resources.Load("GameObject/Mobject"), Vector3.zero, Quaternion.identity) as GameObject;
            mobmgr.CreateMob(tempMobject, toMake);
            tempList.Add(tempMobject.GetComponent<Mob>());
        }

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
        float spacing = 1.2f;

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
    Enemy,
    All
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