using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class Mob : MonoBehaviour {
    public string mobName;
    public Sprite picture;

    public void YouAre(ValidMob mobType)
    {
        //Make template mob
        MobMgr mobmanager = new MobMgr(mobType);


        //Set mob information from the template
        mobName = mobmanager.outName;
        picture = mobmanager.outSprite;



        //Set Sprite in renderer
        gameObject.GetComponent<SpriteRenderer>().sprite = picture;
    }
}
