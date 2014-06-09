using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum ValidMob
{
    jelly,
    skeleton,
    player
}

public class MobManager {

    JobManager jobManager = new JobManager();

    public Mob GetMob(ValidMob inMob)
    {
        Mob tempMob;
        List<ValidMoves> tempMovesLearned;
        List<ValidMoves> tempMetaList;
        List<ValidItems> tempItemsList;
        ValidJobs tempJob;

        switch (inMob)
        {
            case ValidMob.jelly:
            default: //JELLY
                tempItemsList = new List<ValidItems>() { ValidItems.Pancakes, ValidItems.Milk };
                tempMetaList = new List<ValidMoves>() { ValidMoves.Self_Perfection, ValidMoves.Validate };

                tempMob = new Mob("Jelly", tempItemsList, tempMetaList, ValidSprites.Jelly);

                tempJob = ValidJobs.Ninja;
                tempMovesLearned = new List<ValidMoves>() { ValidMoves.Akujiki };
                tempMob.playerJobs.Add(AddJob(tempJob, tempMovesLearned));
                break;

            case ValidMob.player:
                tempItemsList = new List<ValidItems>() { ValidItems.Milk, ValidItems.Milk };
                tempMetaList = new List<ValidMoves>() { ValidMoves.Self_Perfection, ValidMoves.Validate };

                tempMob = new Mob("Player", tempItemsList, tempMetaList, ValidSprites.Player);

                tempJob = ValidJobs.Barbarian;
                tempMovesLearned = jobManager.LoadJob(ValidJobs.Barbarian).classSkills;
                tempMob.playerJobs.Add(AddJob(tempJob, tempMovesLearned));
                break;

            case ValidMob.skeleton:
                tempItemsList = new List<ValidItems>() { ValidItems.Covered_Brick, ValidItems.Yogurt_Smoothie };
                tempMetaList = new List<ValidMoves>() { ValidMoves.Self_Perfection, ValidMoves.Validate };

                tempMob = new Mob("Skeleton", tempItemsList, tempMetaList, ValidSprites.Skeleton);

                tempJob = ValidJobs.Knight;
                tempMovesLearned = jobManager.LoadJob(ValidJobs.Knight).classSkills;
                tempMob.playerJobs.Add(AddJob(tempJob, tempMovesLearned));
                break;
        }

        return tempMob;
    }

    public Job AddJob(ValidJobs inJob, List<ValidMoves> inMoves)
    {
        Job tempJob = jobManager.LoadJob(inJob);

        foreach (ValidMoves moves in inMoves)
        {
            tempJob.learnedSkills.Add(moves);
        }

        return tempJob;
    }
}
