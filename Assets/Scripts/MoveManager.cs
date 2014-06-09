using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum ValidMoves
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

public class MoveManager {
    public Move GetMove(ValidMoves inMove)
    {
        Move output;

        switch (inMove)
        {
            case ValidMoves.Attack:
                output = new Move("Attack");
                break;
            case ValidMoves.Akujiki:
                output = new Move("Akujiki");
                break;
            case ValidMoves.BodyGuard:
                output = new Move("Body Guard");
                break;
            case ValidMoves.Break:
                output = new Move("Break");
                break;
            case ValidMoves.Fire_Wall:
                output = new Move("Fire Wall");
                break;
            case ValidMoves.Hunker_Down:
                output = new Move("Hunker Down");
                break;
            case ValidMoves.Ice_Shard:
                output = new Move("Ice Shard");
                break;
            case ValidMoves.Run:
                output = new Move("Run");
                break;
            case ValidMoves.Self_Perfection:
                output = new Move("Self Perfection");
                break;
            case ValidMoves.Slam:
                output = new Move("Slam");
                break;
            case ValidMoves.Smash:
                output = new Move("Smash");
                break;
            case ValidMoves.Telekinesis:
                output = new Move("Telekinesis");
                break;
            case ValidMoves.Validate:
                output = new Move("Validate");
                break;
            default:
                output = new Move("Attack");
                break;
        }

        return output;
    }
}
