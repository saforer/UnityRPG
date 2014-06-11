using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum ValidMob
{
    Player,
    Jelly,
    Skeleton
}

public class MobManager {
    public string GetMobName(ValidMob inMob)
    {
        switch (inMob)
        {
            case ValidMob.Jelly:
            default:
                return "Jelly";
            case ValidMob.Player:
                return "Player";
            case ValidMob.Skeleton:
                return "Skeleton";
        }
    }

    public Sprite GetPicture(ValidMob inMob)
    {
        SpriteBox currentBox = GameObject.FindGameObjectWithTag("GameController").GetComponent<SpriteBox>();
        switch (inMob)
        {
            case ValidMob.Jelly:
            default:
                return currentBox.Jelly;
            case ValidMob.Player:
                return currentBox.Player;
            case ValidMob.Skeleton:
                return currentBox.Skeleton;
        }
    }

    public List<Job> GetJobs(ValidMob inMob)
    {
        ValidJobs tempJob;
        List<ValidMove> tempMovesLearned = new List<ValidMove>();
        List<Job> mobJobs = new List<Job>(); ;
        switch (inMob)
        {
            case ValidMob.Jelly:
            default:
                tempJob = ValidJobs.Ninja;
                tempMovesLearned = new List<ValidMove>() { ValidMove.Akujiki };
                mobJobs.Add(AddJob(tempJob, tempMovesLearned));
                return mobJobs;
            case ValidMob.Player:
                return mobJobs;
            case ValidMob.Skeleton:
                return mobJobs;
        }
    }

    public List<ValidItem> GetItems(ValidMob inMob)
    {
        switch (inMob)
        {
            case ValidMob.Jelly:
            default:
                return new List<ValidItem>() {};
            case ValidMob.Player:
                return new List<ValidItem>() {ValidItem.Pancakes,ValidItem.Yogurt_Smoothie};
            case ValidMob.Skeleton:
                return new List<ValidItem>() { };
        }
    }
    public List<ValidMove> GetMetaMagic(ValidMob inMob)
    {
        switch (inMob)
        {
            case ValidMob.Jelly:
            default:
                return new List<ValidMove>() { };
            case ValidMob.Player:
                return new List<ValidMove>() { };
            case ValidMob.Skeleton:
                return new List<ValidMove>() { };
        }
    }

    public Job AddJob(ValidJobs inJob, List<ValidMove> inMoves)
    {
        JobManager jobManager = new JobManager();
        Job tempJob = jobManager.LoadJob(inJob);

        foreach (ValidMove moves in inMoves)
        {
            tempJob.learnedSkills.Add(moves);
        }

        return tempJob;
    }
}
