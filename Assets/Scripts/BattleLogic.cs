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

    FightState currentFightState = FightState.InitializingEverything;

    List<Mob> playerTeam;
    List<Mob> enemyTeam;
    List<Mob> turnOrder;
    Mob currentPlayer;
    MenuListing currentPlayerMenu;

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

                break;
        }
	}

    void Init()
    {
        //Find UI
        currentUI = gameObject.GetComponent<BattleUI>();
        //Get Players
        playerTeam = GetTeam(Team.Player);
        //Get Enemies
        enemyTeam = GetTeam(Team.Enemy);
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
                    Mob tempMob = new Mob("Dude" + i);
                    outputList.Add(tempMob);
                }
                break;
            case Team.Enemy:
                for (int i = 0; i < 10; i++)
                {
                    Mob tempMob = new Mob("Badguy" + i);
                    outputList.Add(tempMob);
                }
                break;
        }
        return outputList;
    }

    void UpdateUI()
    {
        currentUI.uiPlayers = playerTeam;
        currentUI.uiCurrentPlayer = currentPlayer;
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
}
