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

    public List<List<RPGButton>> totalList = new List<List<RPGButton>>();
    public List<RPGButton> tempSublist = new List<RPGButton>();

    void Start ()
    {
        currentUI = gameObject.GetComponent<BattleUI>();

        List<RPGButton> sublist = new List<RPGButton>();

        sublist.Add(new RPGButton("Skills", buttonOn, buttonOff, buttonLocked));
        sublist.Add(new RPGButton("MetaMagic", buttonOn, buttonOff, buttonLocked));
        sublist.Add(new RPGButton("Magic", buttonOn, buttonOff, buttonLocked));
        sublist.Add(new RPGButton("Items", buttonOn, buttonOff, buttonLocked));
        sublist.Add(new RPGButton("Run", buttonOn, buttonOff, buttonLocked));

        totalList.Add(sublist);

        currentSelection = totalList[0][0];
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
            if (0 < selectInt)
            {
                selectInt--;
            }
            else
            {
                selectInt = 0;
            }


            currentSelection = totalList[pointerDepth][selectInt];
        }


        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if ((totalList[pointerDepth].Count-1)>selectInt)
            {
                selectInt++;
            }
            else
            {
                selectInt = (totalList[pointerDepth].Count-1);
            }


            currentSelection = totalList[pointerDepth][selectInt];
        }

        //Depth
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {

        }
    }

    void ListCleanup()
    {
        foreach (List<RPGButton> sublist in totalList)
        {
            foreach (RPGButton input in sublist)
            {
                input.currentState = buttonState.Off;
            }
        }

        currentSelection.currentState = buttonState.On;

    }
}
