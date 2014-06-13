using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class MobMgr {

    public string outName;
    public Sprite outSprite;

    public void CreateMob(GameObject objectToChange, ValidMob mobType)
    {
        SpriteBox currentBox = GameObject.FindGameObjectWithTag("GameController").GetComponent<SpriteBox>();
        Mob component = objectToChange.GetComponent<Mob>();
        JobMgr jobmgr = new JobMgr();
        string tempName;

        switch (mobType)
        {
            case ValidMob.Player:
            default:
                tempName = "Player";
                component.name = tempName;
                component.mobName = tempName;
                component.picture = currentBox.Player;
                component.speed = Random.Range(1, 1000);
                component.playerJob.Add(jobmgr.LoadJob(ValidJobs.Ninja));
                component.playerJob.Add(jobmgr.LoadJob(ValidJobs.Knight));
                component.playerJob.Add(jobmgr.LoadJob(ValidJobs.Barbarian));
                component.playerJob.Add(jobmgr.LoadJob(ValidJobs.Wizard));
                component.metaMoveList = new List<ValidMove>() { ValidMove.Self_Perfection, ValidMove.Validate };
                component.itemList = new List<ValidItem>() { ValidItem.Milk, ValidItem.Pancakes, ValidItem.Yogurt_Smoothie, ValidItem.Covered_Brick };
                break;
            case ValidMob.Jelly:
                tempName = "Jelly";
                component.name = tempName;
                component.mobName = tempName;
                component.picture = currentBox.Jelly;
                component.speed = Random.Range(1, 1000);
                component.metaMoveList = new List<ValidMove>() { };
                component.itemList = new List<ValidItem>() { };
                break;
            case ValidMob.Skeleton:
                tempName = "Skeleton";
                component.name = tempName;
                component.mobName = tempName;
                component.picture = currentBox.Skeleton;
                component.speed = Random.Range(1, 1000);
                component.metaMoveList = new List<ValidMove>() { };
                component.itemList = new List<ValidItem>() { };
                break;
        }

        component.SetSprite();
    }
}

public enum ValidMob
{
    Player,
    Jelly,
    Skeleton
}
