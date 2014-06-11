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

public class JobManager
{

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

        List<ValidMove> tempSkills = new List<ValidMove>() { ValidMove.Fire_Wall, ValidMove.Ice_Shard, ValidMove.Telekinesis };

        foreach (ValidMove move in tempSkills)
        {
            output.classSkills.Add(move);
        }


        return output;
    }

    Job Barbarian()
    {
        Job output = new Job("Barbarian");
        List<ValidMove> tempSkills = new List<ValidMove>() { ValidMove.Smash, ValidMove.Slam, ValidMove.Break };

        foreach (ValidMove move in tempSkills)
        {
            output.classSkills.Add(move);
        }

        return output;
    }

    Job Knight()
    {
        Job output = new Job("Knight");

        List<ValidMove> tempSkills = new List<ValidMove>() { ValidMove.BodyGuard, ValidMove.Hunker_Down };

        foreach (ValidMove move in tempSkills)
        {
            output.classSkills.Add(move);
        }

        return output;
    }

    Job Ninja()
    {
        Job output = new Job("Ninja");

        List<ValidMove> tempSkills = new List<ValidMove>() { ValidMove.Akujiki };

        foreach (ValidMove move in tempSkills)
        {
            output.classSkills.Add(move);
        }

        return output;
    }

    public void SetLearned(ValidMove moveToLearn, Job jobFrom)
    {
        MoveManager moveManager = new MoveManager();

        jobFrom.learnedSkills.Add(moveToLearn);
    }
}