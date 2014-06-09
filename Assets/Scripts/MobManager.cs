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
    SpriteBox currentBox;


    public Sprite GetPicture(ValidMob inMob)
    {
        currentBox = GameObject.FindGameObjectWithTag("GameController").GetComponent<SpriteBox>();
        switch (inMob)
        {
            case ValidMob.Skeleton:
                return currentBox.Skeleton;
            case ValidMob.Player:
                return currentBox.Player;
            case ValidMob.Jelly:
            default:
                return currentBox.Jelly;
        }
    }

    public int[] GetStats(ValidMob inMob)
    {
        switch (inMob)
        {
            case ValidMob.Skeleton:
                return new int[4] { 5, 4, 3, 2};
            case ValidMob.Player:
                return new int[4] { 5, 4, 3, 2};
            case ValidMob.Jelly:
            default:
                return new int[4] { 5, 4, 3, 2};
        }
    }
}
