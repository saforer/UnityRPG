using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum ValidJobs
{
    Barbarian,
    Knight,
    Wizard,
    Ninja
}

public class JobManager {
    
    public Job LoadJob(ValidJobs inJob)
    {
        Job output;

        switch (inJob)
        {
            case ValidJobs.Wizard:
                output = Wizard();
                break;
            case ValidJobs.Barbarian:
                output = Barbarian();
                break;
            case ValidJobs.Knight:
                output = Knight();
                break;
            case ValidJobs.Ninja:
                output = Ninja();
                break;
            default:
                output = new Job("BrokenJob");
                break;
        }

        return output;
    }

    Job Wizard()
    {
        Job output;

        output = new Job("Wizard");

        List<ValidMoves> tempSkills = new List<ValidMoves>() { ValidMoves.Fire_Wall, ValidMoves.Ice_Shard, ValidMoves.Telekinesis };

        foreach (ValidMoves validmoves in tempSkills)
        {
            output.classSkills.Add(validmoves);
        }


        return output;
    }

    Job Barbarian()
    {
        Job output = new Job("Barbarian");
        List<ValidMoves> tempSkills = new List<ValidMoves>() { ValidMoves.Smash, ValidMoves.Slam, ValidMoves.Break };

        foreach (ValidMoves validmoves in tempSkills)
        {
            output.classSkills.Add(validmoves);
        }

        return output;
    }

    Job Knight()
    {
        Job output = new Job("Knight");

        List<ValidMoves> tempSkills = new List<ValidMoves>() { ValidMoves.BodyGuard, ValidMoves.Hunker_Down };

        foreach (ValidMoves validmoves in tempSkills)
        {
            output.classSkills.Add(validmoves);
        }

        return output;
    }

    Job Ninja()
    {
        Job output = new Job("Ninja");

        List<ValidMoves> tempSkills = new List<ValidMoves>() { ValidMoves.Akujiki };

        foreach (ValidMoves validmoves in tempSkills)
        {
            output.classSkills.Add(validmoves);
        }

        return output;
    }

    public void SetLearned(ValidMoves moveToLearn, Job jobFrom)
    {
        MoveManager moveManager = new MoveManager();

        jobFrom.learnedSkills.Add(moveToLearn);
    }
}
