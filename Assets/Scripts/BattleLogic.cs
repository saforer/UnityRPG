using UnityEngine;
using System.Collections;

public class BattleLogic : MonoBehaviour {

    private BattleUI currentUI;
    private int selectedInt = 0;
    private int subInt = 0;
    private MenuOptions selectedOption = MenuOptions.Skills;
    private MenuType currentMenu;

    void Start ()
    {
        currentUI = gameObject.GetComponent<BattleUI>();
    }

    void Update ()
    {
        switch (currentMenu) 
        { 
            case MenuType.Main:
                PrimarySelection();
                break;
            case MenuType.Sub:
                SecondarySelection();
                break;
        }
    }

    void PrimarySelection()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            selectedInt++;
            if (selectedInt > 4)
            {
                selectedInt = 4;
            }
            EvalSelectedOption();
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            selectedInt--;
            if (selectedInt < 0)
            {
                selectedInt = 0;
            }
            EvalSelectedOption();
        }

        if (Input.GetKeyDown (KeyCode.RightArrow))
        {
            currentMenu = MenuType.Sub;
            currentUI.drawSub = true;
            EvalSelectedOption();
        }
    }

    void SecondarySelection()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            subInt++;
            if (subInt > 2)
            {
                subInt = 2;
            }
            EvalSelectedOption();
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            subInt--;
            if (subInt < 0)
            {
                subInt = 0;
            }
            EvalSelectedOption();
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            currentMenu = MenuType.Main;
            currentUI.drawSub = false;
            EvalSelectedOption();
        }
    }

    void EvalSelectedOption()
    {
        switch (currentMenu)
        { 
            case MenuType.Main:
                switch (selectedInt)
                {
                    case 0:
                        selectedOption = MenuOptions.Skills;
                        break;
                    case 1:
                        selectedOption = MenuOptions.MetaMagic;
                        break;
                    case 2:
                        selectedOption = MenuOptions.Magic;
                        break;
                    case 3:
                        selectedOption = MenuOptions.Items;
                        break;
                    case 4:
                        selectedOption = MenuOptions.Run;
                        break;
                }
                break;
            case MenuType.Sub:
                switch (subInt)
                {
                    case 0:
                        selectedOption = MenuOptions.Attack;
                        break;
                    case 1:
                        selectedOption = MenuOptions.Parry;
                        break;
                    case 2:
                        selectedOption = MenuOptions.Feint;
                        break;
                }
                break;
        }

        UpdateUI(selectedOption);
    }

    void UpdateUI(MenuOptions update)
    {
        currentUI.skillsMenuState = MenuButtonState.Off;
        currentUI.metaMagicMenuState = MenuButtonState.Off;
        currentUI.magicMenuState = MenuButtonState.Off;
        currentUI.itemMenuState = MenuButtonState.Off;
        currentUI.runMenuState = MenuButtonState.Off;
        currentUI.option1State = MenuButtonState.Off;
        currentUI.option2State = MenuButtonState.Off;
        currentUI.option3State = MenuButtonState.Off;

        switch (update)
        {
            case MenuOptions.Skills:
                currentUI.skillsMenuState = MenuButtonState.On;
                break;
            case MenuOptions.MetaMagic:
                currentUI.metaMagicMenuState = MenuButtonState.On;
                break;
            case MenuOptions.Magic:
                currentUI.magicMenuState = MenuButtonState.On;
                break;
            case MenuOptions.Items:
                currentUI.itemMenuState = MenuButtonState.On;
                break;
            case MenuOptions.Run:
                currentUI.runMenuState = MenuButtonState.On;
                break;
            case MenuOptions.Attack:
                currentUI.option1State = MenuButtonState.On;
                break;
            case MenuOptions.Parry:
                currentUI.option2State = MenuButtonState.On;
                break;
            case MenuOptions.Feint:
                currentUI.option3State = MenuButtonState.On;
                break;
        }
    }
}
