using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Mob : MonoBehaviour {
    SpriteRenderer thisRenderer;
    MobManager mobManager;

    //Mob Variables
    public ValidMob typeOfMob;
    public Sprite mobSprite;
    public int MaxHP;
    public int CurHP;
    public int MaxMP;
    public int CurMP;

    public void IsMob(ValidMob inMobType)
    {
        typeOfMob = inMobType;

        //Get the sprite renderer for this game object.
        thisRenderer = gameObject.GetComponent<SpriteRenderer>();

        //Get a new mob manager
        mobManager = new MobManager();

        //Get the picture from the renderer
        GetPicture();

        //Get the base stats from the mob manager
        GetStats();

        //Ask the mob manager what derived stats the mob should have
        GetDerivedStats();
    }

    void GetPicture()
    {
        //Get the picture from the mob manager
        mobSprite = mobManager.GetPicture(typeOfMob);
        //Set the picture from the mob manager
        thisRenderer.sprite = mobSprite;
    }

    void GetStats()
    {
        int[] stats = mobManager.GetStats(typeOfMob);
        MaxHP = stats[0];
        CurHP = stats[1];
        MaxMP = stats[2];
        CurMP = stats[3];
    }

    void GetDerivedStats()
    {

    }
}