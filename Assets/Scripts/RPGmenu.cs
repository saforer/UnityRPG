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

    public void AddChild (RPGButton inButton) 
    {
        children.Add(inButton);
    }

    public void MenuDown ()
    {
        if (selectedOption<(children.Count-1))
        {
            selectedOption++;
            UpdateButtons();
        }
    }

    public void MenuUp ()
    {
        if (selectedOption > 0)
        {
            selectedOption--;
            UpdateButtons();
        }
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
