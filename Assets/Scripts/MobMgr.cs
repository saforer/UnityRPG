using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class MobMgr {

    public string outName;
    public Sprite outSprite;

    public MobMgr(ValidMob inType)
    {
        SpriteBox currBox = GameObject.FindGameObjectWithTag("GameController").GetComponent<SpriteBox>();
        switch (inType)
        {
            case ValidMob.Jelly:
            default:
                outName = "Jelly";
                outSprite = currBox.Jelly;
                break;
        }
    }
}

public enum ValidMob
{
    Player,
    Jelly,
    Skeleton
}
