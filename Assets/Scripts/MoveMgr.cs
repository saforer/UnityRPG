using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class MoveMgr {
    public Move GetMove(ValidMove inMove)
    {
        switch (inMove)
        {
            default:
            case ValidMove.Attack:
                return new Move("Attack", inMove);
            case ValidMove.Akujiki:
                return new Move("Akujiki", inMove);
            case ValidMove.BodyGuard:
                return new Move("Body Guard", inMove);
            case ValidMove.Break:
                return new Move("Break", inMove);
            case ValidMove.Fire_Wall:
                return new Move("Fire Wall", inMove);
            case ValidMove.Hunker_Down:
                return new Move("Hunker Down", inMove);
            case ValidMove.Ice_Shard:
                return new Move("Ice Shard", inMove);
            case ValidMove.Run:
                return new Move("Run", inMove);
            case ValidMove.Self_Perfection:
                return new Move("Self Perfection", inMove);
            case ValidMove.Slam:
                return new Move("Slam", inMove);
            case ValidMove.Smash:
                return new Move("Smash", inMove);
            case ValidMove.Telekinesis:
                return new Move("Telekinesis", inMove);
            case ValidMove.Validate:
                return new Move("Validate", inMove);
        }
    }
}

public enum ValidMove
{
    //Normal Attack
    Attack,
    //Normal Skills
    Akujiki,
    BodyGuard,
    Hunker_Down,
    Smash,
    Break,
    Slam,
    Fire_Wall,
    Ice_Shard,
    Telekinesis,
    //MetaMagic
    Self_Perfection,
    Validate,
    //Run
    Run
}
