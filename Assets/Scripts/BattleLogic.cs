using UnityEngine;
using System.Collections;

public class BattleLogic : MonoBehaviour {

    private BattleUI currentUI;
    private int selectedInt = 0;
    private MenuOptions selectedOption = MenuOptions.Attack;

    void Start ()
    {
        currentUI = gameObject.GetComponent<BattleUI>();
    }

    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            selectedInt++;
            if(selectedInt>2)
            {
                selectedInt = 2;
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
                selectedOption = MenuOptions.Attack;
                break;
            case 1:
                selectedOption = MenuOptions.MetaMagic;
                break;
            case 2:
                selectedOption = MenuOptions.Run;
                break;
        }

        UpdateUI(selectedOption);
    }

    void UpdateUI(MenuOptions update)
    {
        currentUI.attackMenuState = MenuButtonState.Off;
        currentUI.metaMagicMenuState = MenuButtonState.Off;
        currentUI.runMenuState = MenuButtonState.Off;

        switch (update)
        {
            case MenuOptions.Attack:
                currentUI.attackMenuState = MenuButtonState.On;
                break;
            case MenuOptions.MetaMagic:
                currentUI.metaMagicMenuState = MenuButtonState.On;
                break;
            case MenuOptions.Run:
                currentUI.runMenuState = MenuButtonState.On;
                break;
        }
    }
}
