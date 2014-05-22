using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RPGmenu {

    string name;
    int selectedOption = 0;

    public List<RPGButton> children = new List<RPGButton>();

    public RPGmenu (string inName)
    {
        name = inName;
    }

    public void Startup()
    {
        TurnOnButton(children[0]);
    }

    public void AddChildButton (RPGButton inButton) 
    {
        children.Add(inButton);
    }

    public void MenuDown (int depth)
    {
        if (depth == 0)
        {
            if (selectedOption < (children.Count - 1))
            {
                selectedOption++;
                UpdateButtons();
            }
        }
        else
        {
            RPGmenu lowerMenu = children[selectedOption].childMenu;
            lowerMenu.MenuDown((depth - 1));
        }
    }

    public void MenuUp (int depth)
    {
        if (selectedOption > 0)
        {
            selectedOption--;
            UpdateButtons();
        }
    }

    public RPGmenu Grow (int depth)
    {
        //return RPGmenu 
    }

    public RPGmenu Shrink (int depth)
    {

    }


    RPGButton SelectedButton(int selectedOption)
    {
        return children[selectedOption];
    }

    void TurnOnButton(RPGButton inButton)
    {
        inButton.currentState = buttonState.On;
    }

    public void UpdateButtons()
    {
        foreach (RPGButton button in children)
        {
            button.currentState = buttonState.Off;
        }

        TurnOnButton(SelectedButton(selectedOption));
    }
}
