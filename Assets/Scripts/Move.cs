using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class Move {
    public string name;
    public ValidMove currentMove;
    public List<Target> neededTargets;

    public Move (string inName, ValidMove inMove, List<Target> inTargets)
    {
        name = inName;
        currentMove = inMove;
        neededTargets = inTargets;
    }
}
