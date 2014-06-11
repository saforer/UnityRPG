using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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

public class MoveManager
{
    public Move GetMove(ValidMove inMove)
    {
        Move output;

        switch (inMove)
        {
            case ValidMove.Attack:
                output = new Move("Attack");
                break;
            case ValidMove.Akujiki:
                output = new Move("Akujiki");
                break;
            case ValidMove.BodyGuard:
                output = new Move("Body Guard");
                break;
            case ValidMove.Break:
                output = new Move("Break");
                break;
            case ValidMove.Fire_Wall:
                output = new Move("Fire Wall");
                break;
            case ValidMove.Hunker_Down:
                output = new Move("Hunker Down");
                break;
            case ValidMove.Ice_Shard:
                output = new Move("Ice Shard");
                break;
            case ValidMove.Run:
                output = new Move("Run");
                break;
            case ValidMove.Self_Perfection:
                output = new Move("Self Perfection");
                break;
            case ValidMove.Slam:
                output = new Move("Slam");
                break;
            case ValidMove.Smash:
                output = new Move("Smash");
                break;
            case ValidMove.Telekinesis:
                output = new Move("Telekinesis");
                break;
            case ValidMove.Validate:
                output = new Move("Validate");
                break;
            default:
                output = new Move("Attack");
                break;
        }

        return output;
    }
}