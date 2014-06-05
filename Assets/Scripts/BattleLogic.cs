using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum rpgBattleState
{
	playerTurn,
	enemyTurn,
	acting
}

public enum playerTurnStates
{
	selectingMove,
	steppingToTarget,
	targetting,
	isTurnOver,
	steppingToMove
}

public class BattleLogic : MonoBehaviour {

    private BattleUI currentUI;
	public RPGmenu currentMenu;

    //TODO: NOT NEEDED ANYMORE SINCE I KNOW ABOUT FINDING RESOURCES
	public Texture buttonOff;
	public Texture buttonOn;
	public Texture buttonLocked;



	List<Mob> playerTeam = new List<Mob>();
	List<Mob> enemyTeam = new List<Mob>();

    public int selectedMobInt;
	public Mob selectedMob;
    public int selectedPlayerInt;
	public Mob selectedPlayer;

	public rpgBattleState currentBattleState = rpgBattleState.playerTurn;
	public playerTurnStates currentPlayerState = playerTurnStates.selectingMove;

    List<int> targetList;

    void Start ()
    {
		currentUI = gameObject.GetComponent<BattleUI>();

        selectedPlayerInt = 0;
        UpdateSelectedPlayer(selectedPlayerInt);
        selectedMobInt = -1;
        UpdateSelectedMob(selectedMobInt);

		FillPlayerList();
		FillEnemyList();

		CreateMenu();
    }

	void FillPlayerList()
	{
        for (int i = 0; i < 10; i++)
        {
            Mob tempPlayer = MobManager.GetMob(Mobs.Player);
            if (i % 2 == 0)
                tempPlayer.row = 1;
            if (i % 3 == 0)
                tempPlayer.row = 2;
            playerTeam.Add(tempPlayer);
        }

		currentUI.playerTeam = playerTeam;
	}

	void FillEnemyList()
	{
		for (int i = 0; i < 9; i++) 
		{
			Mob tempEnemy = MobManager.GetMob (Mobs.Jelly);
			enemyTeam.Add (tempEnemy);
		}
		currentUI.enemyTeam = enemyTeam;
	}

    void Update()
    {
		switch (currentBattleState) 
		{
		case rpgBattleState.playerTurn:
			PlayerTurn();
			break;
		}
    } 

    void PlayerTurn()
    {
		switch (currentPlayerState)
		{
            case playerTurnStates.steppingToMove:
                SetupMenuControls();
                break;
		    case playerTurnStates.selectingMove:
			    MenuControls();
			    break;
            case playerTurnStates.steppingToTarget:
                SetupTargetControls();
                break;
            case playerTurnStates.targetting:
                TargetControls();
                break;
            case playerTurnStates.isTurnOver:
                IsTurnOverCheck();
                break;
		}
    }

    void SetupMenuControls()
    {
        currentUI.drawMenu = true;
        CreateMenu();
        currentPlayerState = playerTurnStates.selectingMove;
    }

    void MenuControls()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            currentMenu.MoveDown();
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            currentMenu.MoveUp();
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            foreach (Mob tempMob in playerTeam)
            {
                Debug.Log(tempMob.ToString());
            }
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            foreach (Mob tempMob in enemyTeam)
            {
                Debug.Log(tempMob.ToString());
            }
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (currentMenu.DoesChildExist())
            {
                currentMenu = currentMenu.ChildSelected();
                currentMenu.UpdateSelection();
                currentUI.SetSelected(currentMenu);
            }
            else
            {

                currentPlayerState = playerTurnStates.steppingToTarget;
            }
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (currentMenu.parent != null)
            {
                currentMenu = currentMenu.parent;
            }
            currentUI.SetSelected(currentMenu);
        }
    }

    void SetupTargetControls()
    {
        currentUI.drawMenu = false;
        selectedMobInt = 0;
        UpdateSelectedMob(selectedMobInt);
        targetList = new List<int>();
        currentPlayerState = playerTurnStates.targetting;
    }

    void TargetControls()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (selectedMobInt>0)
                {
                    selectedMobInt--;
                }
                else
                {
                    selectedMobInt=0;
                }
            UpdateSelectedMob(selectedMobInt);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (selectedMobInt<enemyTeam.Count-1)
            {
                selectedMobInt++;
            }
            else
            {
                selectedMobInt=enemyTeam.Count-1;
            }
            UpdateSelectedMob(selectedMobInt);
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            int MoveTargets = 2;
            if (targetList.Contains(selectedMobInt))
            {
                targetList.Remove(selectedMobInt);
            }
            else
            {
                targetList.Add(selectedMobInt);
            }
            UpdateTargetingList();
            if (targetList.Count == MoveTargets)
            {
                currentPlayerState = playerTurnStates.isTurnOver;
            }
        }
    }

    void IsTurnOverCheck()
    {
        targetList.Clear();
        selectedMobInt = -1;
        UpdateSelectedMob(selectedMobInt);
        currentPlayerState = playerTurnStates.steppingToMove;
    }

    void UpdateTargetingList()
    {
        currentUI.targetList = targetList;
    }

    void UpdateSelectedPlayer(int inInt)
    {
        currentUI.selectedPlayerInt = selectedPlayerInt;
    }

    void UpdateSelectedMob(int inInt)
    {
        currentUI.selectedMobInt = selectedMobInt;
    }

	void CreateMenu()
	{
		currentMenu = new RPGmenu("MainMenu", null);

		//Root
		List<string> optionsString;

		optionsString = new List<string>() {"Skills","MetaMagic","Magic","Items","Run"};

		currentUI.SetSelected(currentMenu);

		PropogateMenu(currentMenu, optionsString);

		//Root : Skills
		optionsString = new List<string>() {"Barbarian","Knight"};

		PropogateMenu(currentMenu.ChildMenuAt(0), optionsString);

		//Root : Skills : Barbarian
		optionsString = new List<string>() {"Smash","Rip"};

		PropogateMenu(currentMenu.ChildMenuAt(0).ChildMenuAt(0), optionsString);

		//Root : Skills: Knight
		optionsString = new List<string>() {"Bodyguard","Tower Defense"};

		PropogateMenu(currentMenu.ChildMenuAt(0).ChildMenuAt(1), optionsString);

		//Root : MetaMagic
		optionsString = new List<string>() {"Analyze Enemy", "Validate", "Self Perfection", "Alter Enemy"};
	
		PropogateMenu(currentMenu.ChildMenuAt(1), optionsString);

		//Root : Magic
		optionsString = new List<string>() {"Magician","Cleric"};
		
		PropogateMenu(currentMenu.ChildMenuAt(2), optionsString);

		//Root : Magic
		optionsString = new List<string>() {"Fire Wall","Ice Dagger"};
		
		PropogateMenu(currentMenu.ChildMenuAt(2).ChildMenuAt(0), optionsString);

		optionsString = new List<string>() {"Radiant Glow","Heal Aura"};
		
		PropogateMenu(currentMenu.ChildMenuAt(2).ChildMenuAt(1), optionsString);

		optionsString = new List<string>() {"Pancakes", "Fried Eggplant", "Milk", "Vodka", "Iced Tea", "Soda"};

		PropogateMenu(currentMenu.ChildMenuAt(3),optionsString);


	}

	void PropogateMenu(RPGmenu parentMenu, List<string> tempNamesList)
	{
		foreach (string tempString in tempNamesList)
		{
			parentMenu.buttonList.Add(new RPGButton(tempString,parentMenu, buttonOn, buttonOff, buttonLocked));
		}

		currentMenu.buttonList[0].currentState = buttonState.On;
	}
}