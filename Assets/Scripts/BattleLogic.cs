using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BattleLogic : MonoBehaviour {

    private BattleUI currentUI;

    public int selectInt = 0;
    public int pointerDepth = 0;

    public Texture buttonOn;
    public Texture buttonOff;
    public Texture buttonLocked;

    RPGButton currentSelection;

    public List<RPGButton> menuList = new List<RPGButton>();

    void Start ()
    {
        currentUI = gameObject.GetComponent<BattleUI>();
        

        menuList.Add(new RPGButton("Skills",buttonOn,buttonOff,buttonLocked));
        menuList.Add(new RPGButton("MetaMagic", buttonOn, buttonOff, buttonLocked));
        menuList.Add(new RPGButton("Magic", buttonOn, buttonOff, buttonLocked));
        menuList.Add(new RPGButton("Items", buttonOn, buttonOff, buttonLocked));
        menuList.Add(new RPGButton("Run", buttonOn, buttonOff, buttonLocked));

        currentSelection = menuList[0];

    }

    void Update()
    {
        Controls();
        ListCleanup();
    } 

    void Controls()
    {
        //Basic Navigation
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (selectInt>0)
            {
                selectInt--;
                currentSelection = menuList[pointerDepth];
            }
            else
            {
                selectInt = 0;
                currentSelection = menuList[pointerDepth];
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (selectInt < (menuList.Count - 1))
            {
                selectInt++;
                currentSelection = menuList[pointerDepth];
            }
            else
            {
                selectInt = menuList.Count - 1;
                currentSelection = menuList[pointerDepth];
            }
        }

        //Depth
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            foreach (RPGButton input in currentSelection.children)
            {

            }
        }
    }

    void ListCleanup()
    {
        foreach (RPGButton input in menuList)
        {
            input.currentState = buttonState.Off;
        }

        currentSelection.currentState = buttonState.On;

    }
}
