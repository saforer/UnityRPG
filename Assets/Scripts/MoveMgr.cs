using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class MoveMgr {
    public Move GetMove(ValidMove inMove)
    {
        List<Target> output = new List<Target>();
        switch (inMove)
        {
            default:
            case ValidMove.Attack:
                output.Add(new Target(1, ValidTeam.Enemy));
                return new Move("Attack", inMove, output);
            case ValidMove.Akujiki:
                output.Add(new Target(1, ValidTeam.Enemy));
                return new Move("Akujiki", inMove, output);
            case ValidMove.BodyGuard:
                output.Add(new Target(1, ValidTeam.Player));
                return new Move("Body Guard", inMove, output);
            case ValidMove.Break:
                output.Add(new Target(1, ValidTeam.Enemy));
                return new Move("Break", inMove, output);
            case ValidMove.Fire_Wall:
                output.Add(new Target(3, ValidTeam.Enemy));
                return new Move("Fire Wall", inMove, output);
            case ValidMove.Hunker_Down:
                output.Add(new Target(0, ValidTeam.Player));
                return new Move("Hunker Down", inMove, output);
            case ValidMove.Ice_Shard:
                output.Add(new Target(3, ValidTeam.Enemy));
                return new Move("Ice Shard", inMove, output);
            case ValidMove.Run:
                output.Add(new Target(0, ValidTeam.Player));
                return new Move("Run", inMove, output);
            case ValidMove.Self_Perfection:
                output.Add(new Target(1, ValidTeam.Player));
                return new Move("Self Perfection", inMove, output);
            case ValidMove.Slam:
                output.Add(new Target(1, ValidTeam.Enemy));
                return new Move("Slam", inMove, output);
            case ValidMove.Smash:
                output.Add(new Target(1, ValidTeam.Enemy));
                return new Move("Smash", inMove, output);
            case ValidMove.Telekinesis:
                output.Add(new Target(2, ValidTeam.Enemy));
                return new Move("Telekinesis", inMove, output);
            case ValidMove.Validate:
                output.Add(new Target(1, ValidTeam.Enemy));
                return new Move("Validate", inMove, output);
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
