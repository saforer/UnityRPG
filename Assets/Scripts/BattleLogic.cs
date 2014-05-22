using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BattleLogic : MonoBehaviour {

    private BattleUI currentUI;

    public Texture buttonOn;
    public Texture buttonOff;
    public Texture buttonLocked;

    public List<RPGButton> menuList = new List<RPGButton>();

    void Start ()
    {
        currentUI = gameObject.GetComponent<BattleUI>();
        

        menuList.Add(new RPGButton("Skills",buttonOn,buttonOff,buttonLocked));
        menuList.Add(new RPGButton("MetaMagic", buttonOn, buttonOff, buttonLocked));
        menuList.Add(new RPGButton("Magic", buttonOn, buttonOff, buttonLocked));
        menuList.Add(new RPGButton("Items", buttonOn, buttonOff, buttonLocked));
        menuList.Add(new RPGButton("Run", buttonOn, buttonOff, buttonLocked));
    }

    void Update()
    {

    } 
}
