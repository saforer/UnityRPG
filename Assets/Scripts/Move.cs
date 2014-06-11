using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum TeamHit
{
    Enemy,
    Player,
    Both
}

public class Move {
    public string name;
    public Move(string inName)
    {
        name = inName;
    }	
}
