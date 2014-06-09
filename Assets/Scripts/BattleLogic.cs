using UnityEngine;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public enum FightState
{
    InitializingEverything,
    FindingPlayerOrder,
    SettingUpPlayerMenu,
    PlayerMenu,
    SettingUpTargettingWindow,
    Targetting,
    EnemyTurn,
    ActionTurn
}

public class BattleLogic : MonoBehaviour {
    BattleUI currentUI;
    Controls currentButtons;

    FightState currentFightState = FightState.InitializingEverything;

    List<Mob> playerTeam;
    List<Mob> enemyTeam;
    List<Mob> turnOrder;
    Mob currentPlayer;
    Mob currentEnemy;
    MenuListing currentPlayerMenu;

    MobManager mobManager = new MobManager();
    JobManager jobManager = new JobManager();
    MoveManager moveManager = new MoveManager();
    ItemManager itemManager = new ItemManager();

	void Update () {
	    switch (currentFightState)
        {
            case FightState.InitializingEverything:
                Init();
                break;
            case FightState.FindingPlayerOrder:
                FindPlayerOrder();
                break;
            case FightState.SettingUpPlayerMenu:
                PlayerMenuSetup();
                break;
            case FightState.PlayerMenu:
                PlayerMenuLoop();
                break;
            case FightState.SettingUpTargettingWindow:
                SettingUpTarget();
                break;
        }
	}

    void Init()
    {
        //Find UI
        currentUI = gameObject.GetComponent<BattleUI>();
        //Find Controls
        currentButtons = gameObject.GetComponent<Controls>();
        //Get Players
        playerTeam = GetTeam(Team.Player);
        //Get Enemies
        enemyTeam = GetTeam(Team.Enemy);

        //Make sure enemies don't have empty rows

        //Send players&enemies to UI
        UpdateUI();



        currentFightState = FightState.FindingPlayerOrder;
    }

    List<Mob> GetTeam(Team whichTeam)
    {
        List<Mob> outputList = new List<Mob>();
        switch (whichTeam)
        {
            case Team.Player:
                for (int i = 0; i < 10; i++)
                {
                    Mob tempMob = mobManager.GetMob(ValidMob.player);
                    outputList.Add(tempMob);
                }
                break;
            case Team.Enemy:
                for (int i = 0; i < 10; i++)
                {
                    Mob tempMob = mobManager.GetMob(ValidMob.jelly);
                    outputList.Add(tempMob);
                }
                break;
        }

        outputList = FixRows(outputList);

        return outputList;
    }

    List<Mob> FixRows(List<Mob> inputList)
    {
        List<Mob> outputList = inputList;        
        bool frontEmpty;        
        List<Mob> frontRow;        
        bool middleEmpty;        
        List<Mob> middleRow;        
        bool backEmpty;        
        List<Mob> backRow;
        bool redo = true;

        while (redo)
        {

            frontEmpty = false;
            frontRow = new List<Mob>();
            middleEmpty = false;
            middleRow = new List<Mob>();
            backEmpty = false;
            backRow = new List<Mob>();

            foreach (Mob mob in outputList)
            {
                if (mob.row == Rows.Front) frontRow.Add(mob);
                if (mob.row == Rows.Middle) middleRow.Add(mob);
                if (mob.row == Rows.Back) backRow.Add(mob);
            }


            if (frontRow.Count == 0) frontEmpty = true;
            if (middleRow.Count == 0) middleEmpty = true;
            if (backRow.Count == 0) backEmpty = true;

            if (!frontEmpty)
            {
                if (!middleEmpty)
                    redo = false;
            }

            if (frontEmpty)
            {
                if (middleEmpty)
                {
                    foreach (Mob mob in backRow) mob.row = Rows.Front;
                }
                else
                {
                    foreach (Mob mob in middleRow) mob.row = Rows.Front;
                }
            }

            if (middleEmpty)
            {
                if (backEmpty)
                {
                    redo = false;
                }
                else
                {
                    foreach (Mob mob in backRow) mob.row = Rows.Middle;
                }
            }
        }

        return outputList;
    }

    void UpdateUI()
    {
        currentUI.uiPlayers = playerTeam;
        currentUI.uiCurrentPlayer = currentPlayer;
        currentUI.uiCurrentEnemy = currentEnemy;
        currentUI.uiEnemies = enemyTeam;
    }

    void FindPlayerOrder()
    {
        turnOrder = playerTeam.OrderByDescending(player => player.speed).ToList();
        currentPlayer = turnOrder[0];
        UpdateUI();
        currentFightState = FightState.SettingUpPlayerMenu;
    }

    void PlayerMenuSetup()
    {
        currentPlayerMenu = currentPlayer.CreateRoot();
        currentUI.uiCurrentPlayerMenu = currentPlayerMenu;
        currentUI.PlayerMenuDrawing = true;
        currentFightState = FightState.PlayerMenu;
    }

    void PlayerMenuLoop()
    {
        if (currentButtons.UpArrow)
        {
            currentPlayerMenu.MoveUp();
            currentUI.uiCurrentPlayerMenu = currentPlayerMenu;
        }
        if (currentButtons.DownArrow)
        {
            currentPlayerMenu.MoveDown();
            currentUI.uiCurrentPlayerMenu = currentPlayerMenu;
        }
        if (currentButtons.Z)
        {
            if (currentPlayerMenu.CanGoRight())
            {
                currentPlayerMenu = currentPlayerMenu.MoveRight();
                currentPlayerMenu.UpdateSelected();
                currentUI.uiCurrentPlayerMenu = currentPlayerMenu;
            }
            else if (currentPlayerMenu.CanDoMove())
            {
                DoMove(currentPlayerMenu.CurrentButtonMove());
            }
            else if (currentPlayerMenu.CanUseItem())
            {
                UseItem(currentPlayerMenu.CurrentButtonItem());
            }
        }
        if (currentButtons.X && currentPlayerMenu.CanLeft())
        {
            currentPlayerMenu = currentPlayerMenu.MoveLeft();
            currentUI.uiCurrentPlayerMenu = currentPlayerMenu;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("------------PlayerTeam----------");
            foreach (Mob mob in playerTeam)
            {
                Debug.Log(mob.row);
            }
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("------------EnemyTeam----------");
            foreach (Mob mob in enemyTeam)
            {
                Debug.Log(mob.row);
            }
        }
    }

    void DoMove(Move inMove)
    {
        currentUI.SetTextBox("I don't know how to do " + inMove.name);
    }

    void UseItem(Item inItem)
    {
        currentUI.SetTextBox("I don't know how to use " + inItem.name);
    }

    void SettingUpTarget()
    {

    }
}
