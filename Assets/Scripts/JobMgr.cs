using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class JobMgr {
    public Job LoadJob(ValidJobs inJob)
    {
        switch (inJob)
        {
            default:
            case ValidJobs.Ninja:
                return Ninja();
            case ValidJobs.Wizard:
                return Wizard();
            case ValidJobs.Barbarian:
                return Barbarian();
            case ValidJobs.Knight:
                return Knight();
        }
    }

    Job Ninja()
    {
        List<ValidMove> classMoves = new List<ValidMove>() {ValidMove.Akujiki};
        List<ValidMove> startingMoves = new List<ValidMove>() {ValidMove.Akujiki};
        return new Job("Ninja", classMoves, startingMoves);
    }

    Job Wizard()
    {
        List<ValidMove> classMoves = new List<ValidMove>() { ValidMove.Fire_Wall, ValidMove.Ice_Shard };
        List<ValidMove> startingMoves = new List<ValidMove>() { ValidMove.Fire_Wall, ValidMove.Ice_Shard };
        return new Job("Wizard", classMoves, startingMoves);
    }

    Job Barbarian()
    {
        List<ValidMove> classMoves = new List<ValidMove>() { ValidMove.Slam, ValidMove.Smash, ValidMove.Break};
        List<ValidMove> startingMoves = new List<ValidMove>() { ValidMove.Slam, ValidMove.Smash, ValidMove.Break };
        return new Job("Barbarian", classMoves, startingMoves);
    }

    Job Knight()
    {
        List<ValidMove> classMoves = new List<ValidMove>() {ValidMove.Hunker_Down, ValidMove.BodyGuard};
        List<ValidMove> startingMoves = new List<ValidMove>() { ValidMove.Hunker_Down, ValidMove.BodyGuard };
        return new Job("Knight", classMoves, startingMoves);
    }
}

public enum ValidJobs
{
    Barbarian,
    Knight,
    Wizard,
    Ninja
}