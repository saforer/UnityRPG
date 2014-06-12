using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public enum Team
{
    Player,
    Enemy
}

public enum TurnStates
{
    Startup,
    SetupMove,
    SetupTarget,
    Move,
    Target,
    CheckTurnEnd,
    EnemyTurn,
    Action
}

public class BattleScreenLogic : MonoBehaviour {

    List<GameObject> enemyTeam;
    List<GameObject> playerTeam;
    List<GameObject> playerTurnOrder = new List<GameObject>();
    MenuListing currentMenu;
    BattleScreenUI currentUI;
    TurnStates currentState = TurnStates.Startup;
    int selectedEnemy = -1;
    int selectedMenuOption = 0;
    int selectedPlayerTurn = 0;



    void Update()
    {
        switch (currentState)
        {
            default:
            case TurnStates.Startup:
                Init();
                break;
            case TurnStates.SetupMove:
                SetupMove();
                break;
            case TurnStates.Move:
                SelectMove();
                break;
            case TurnStates.SetupTarget:
                SetupTarget();
                break;
            case TurnStates.Target:
                Target();
                break;
            case TurnStates.CheckTurnEnd:
                FinishTurn();
                break;
            case TurnStates.EnemyTurn:
                EnemyTurn();
                break;
            case TurnStates.Action:
                ActionPhase();
                break;
        }
    }

    void Init()
    {
        //Get UI
        currentUI = gameObject.GetComponent<BattleScreenUI>();

        //Get Enemies
        enemyTeam = GetEnemies();

        //Get Players
        playerTeam = GetPlayers();

        //Move objects to correct position
        MoveUnits(enemyTeam, Team.Enemy);
        MoveUnits(playerTeam, Team.Player);

        //Tell UI about players and enemies
        currentUI.uiPlayerTeam = playerTeam;
        currentUI.uiEnemyTeam = enemyTeam;

        //Find Fastest Player in the list
        playerTurnOrder = playerTeam.OrderByDescending(player => player.GetComponent<Mob>().speed).ToList();

        //End Init
        currentState = TurnStates.SetupMove;
    }

    List<GameObject> GetEnemies()
    {
        List<GameObject> output = new List<GameObject>();
        for (int i = 0; i<5; i++)
        {
            GameObject player = (GameObject)Resources.Load("GameObject/Mobject");
            GameObject tempMob = (GameObject)Instantiate(player, new Vector3(0, 0, 0), Quaternion.identity);
            tempMob.GetComponent<Mob>().IsMob(ValidMob.Skeleton);
            output.Add(tempMob);
        }
        return output;
    }

    List<GameObject> GetPlayers()
    {
        List<GameObject> output = new List<GameObject>();
        for (int i = 0; i < 5; i++)
        {
            GameObject player = (GameObject)Resources.Load("GameObject/Mobject");
            GameObject tempMob = (GameObject)Instantiate(player, new Vector3(0, 0, 0), Quaternion.identity);
            tempMob.GetComponent<Mob>().IsMob(ValidMob.Player);
            output.Add(tempMob);
        }
        return output;
    }

    void MoveUnits(List<GameObject> inUnitList, Team k)
    {
        int i = 0;
        int j = inUnitList.Count;
        foreach (GameObject mob in inUnitList)
        {
            MoveUnit(mob, i, j, k);
            i++;
        }
    }

    void MoveUnit(GameObject inMob, int i, int j, Team k)
    {
        Vector3 tempPosition = Vector3.zero;
        float tempWidth = inMob.GetComponent<SpriteRenderer>().sprite.rect.width / 50;
        float spacing = 1f;

        tempPosition.x += (i * spacing);
        tempPosition.x -= (j * spacing) / 2;

        switch (k)
        {
            case Team.Enemy:
            default:
                //Move enemies up to their own row
                tempPosition.y += 2;
                break;
            case Team.Player:
                //Move players down to their own row
                tempPosition.y += -2;
                break;
        }

        
        //Push the new position to the mob
        inMob.transform.position = tempPosition;
    }

    void SetupMove()
    {
        GameObject currentPlayer = playerTurnOrder[selectedPlayerTurn];

        MenuListing rootMenu = currentPlayer.GetComponent<Mob>().CreateRoot();

        currentMenu = rootMenu;
        currentUI.uiCurrentPlayer = currentPlayer;
        currentUI.uiCurrentMenu = currentMenu;

        currentState = TurnStates.Move;
    }

    void SelectMove()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("------------PlayerTeam----------");
            foreach (GameObject gobject in playerTeam)
            {
                Debug.Log(gobject.GetComponent<Mob>().name);
            }
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("------------EnemyTeam----------");
            foreach (GameObject gobject in enemyTeam)
            {
                Debug.Log(gobject.GetComponent<Mob>().name);
            }
        }


        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            currentMenu.MoveUp();
            currentUI.uiCurrentMenu = currentMenu;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            currentMenu.MoveDown();
            currentUI.uiCurrentMenu = currentMenu;
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (currentMenu.CanGoRight())
            {
                currentMenu = currentMenu.MoveRight();
                currentMenu.UpdateSelected();
                currentUI.uiCurrentMenu = currentMenu;
            }
            else if (currentMenu.CanDoMove())
            {
                DoMove(currentMenu.CurrentButtonMove());
            }
            else if (currentMenu.CanUseItem())
            {
                UseItem(currentMenu.CurrentButtonItem());
            }
        }
        if (Input.GetKeyDown(KeyCode.X) && currentMenu.CanLeft())
        {
            currentMenu = currentMenu.MoveLeft();
            currentUI.uiCurrentMenu = currentMenu;
        }
    }

    void DoMove(ValidMove inMove)
    {

    }

    void UseItem(ValidItem inItem)
    {

    }

    void SetupTarget()
    {

    }

    void Target()
    {

    }

    void FinishTurn()
    {

    }

    void EnemyTurn()
    {

    }

    void ActionPhase()
    {

    }
}
