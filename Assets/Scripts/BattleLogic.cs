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

        sublist[0].AddChild(new RPGButton("Attack", buttonOn, buttonOff, buttonLocked));
        sublist[0].AddChild(new RPGButton("Parry", buttonOn, buttonOff, buttonLocked));
        sublist[0].AddChild(new RPGButton("Feint", buttonOn, buttonOff, buttonLocked));

        sublist[1].AddChild(new RPGButton("Analyze", buttonOn, buttonOff, buttonLocked));
        sublist[1].AddChild(new RPGButton("HexEdit", buttonOn, buttonOff, buttonLocked));

        sublist[2].AddChild(new RPGButton("Fireball", buttonOn, buttonOff, buttonLocked));
        sublist[2].AddChild(new RPGButton("Ice Shards", buttonOn, buttonOff, buttonLocked));
        sublist[2].AddChild(new RPGButton("Gravity Well", buttonOn, buttonOff, buttonLocked));

        sublist[3].AddChild(new RPGButton("Pancakes", buttonOn, buttonOff, buttonLocked));
        sublist[3].AddChild(new RPGButton("Pizza", buttonOn, buttonOff, buttonLocked));
        sublist[3].AddChild(new RPGButton("Chocolate Milk", buttonOn, buttonOff, buttonLocked));
        sublist[3].AddChild(new RPGButton("Vodka", buttonOn, buttonOff, buttonLocked));


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
            if (currentSelection.children.Count > 0)
            {
                totalList.Add(currentSelection.children);
                pointerDepth++;
                selectInt = 0;

                currentSelection = totalList[pointerDepth][selectInt];
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (pointerDepth > 0)
            {
                totalList.RemoveAt(pointerDepth);
                pointerDepth--;
                selectInt = 0;

                currentSelection = totalList[pointerDepth][selectInt];
            }
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
