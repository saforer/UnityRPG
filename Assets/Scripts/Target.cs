using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class Target {
    public int numberTargetted;
    public ValidTeam teamTargetted;

    public Target(int inNumber, ValidTeam inTeam)
    {
        numberTargetted = inNumber;
        teamTargetted = inTeam;
    }
}
