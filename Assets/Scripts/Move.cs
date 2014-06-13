using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class Move {
    public string name;
    public ValidMove currentMove;

    public Move (string inName, ValidMove inMove)
    {
        name = inName;
        currentMove = inMove;
    }
}
