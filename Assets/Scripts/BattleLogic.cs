using UnityEngine;
using System.Collections;

public class BattleLogic : MonoBehaviour {

    private BattleUI currentUI;
    private int selectedInt = 0;
    private MenuOptions selectedOption = MenuOptions.Skills;

    void Start ()
    {
        currentUI = gameObject.GetComponent<BattleUI>();
    }

    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            selectedInt++;
            if(selectedInt>4)
            {
                selectedInt = 4;
            }
            EvalSelectedOption();
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            selectedInt--;
            if(selectedInt<0)
            {
                selectedInt = 0;
            }
            EvalSelectedOption();
        }
    }

    void EvalSelectedOption()
    {
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

        UpdateUI(selectedOption);
    }

    void UpdateUI(MenuOptions update)
    {
        currentUI.skillsMenuState = MenuButtonState.Off;
        currentUI.metaMagicMenuState = MenuButtonState.Off;
        currentUI.magicMenuState = MenuButtonState.Off;
        currentUI.itemMenuState = MenuButtonState.Off;
        currentUI.runMenuState = MenuButtonState.Off;

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
        }
    }
}
