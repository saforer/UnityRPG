using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum Targets
{
    None,
    Single,
    Multi
}

public enum TeamHit
{
    Enemy,
    Player,
    All
}

public class Move {

    string name;
    Targets peopleHit;
    TeamHit teamToHit;

    public Move (string inName, Targets inTargets, TeamHit inTeam)
    {
        name = inName;
        peopleHit = inTargets;
        teamToHit = inTeam;
    }
}
