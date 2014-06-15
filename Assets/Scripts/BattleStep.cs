using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class BattleStep {
    public Mob caster;
    public List<Mob> target;
    public bool usingMove = false;
    public ValidItem itemUsed;
    public ValidMove moveUsed;
    public int speed;

    public BattleStep(Mob inCaster, List<Mob> inTargets, ValidItem inItem)
    {
        caster = inCaster;
        speed = inCaster.speed;
        target = inTargets;
        itemUsed = inItem;
        usingMove = false;
    }

    public BattleStep(Mob inCaster, List<Mob> inTargets, ValidMove inMove)
    {
        caster = inCaster;
        speed = inCaster.speed;
        target = inTargets;
        moveUsed = inMove;
        usingMove = true;
    }

    public override string ToString()
    {
        string output;
        output = "Caster: " + caster;
        output += " Speed: " + speed;
        if (usingMove == true) output += "Move Used: " + moveUsed;
        if (usingMove == false) output += "Item Used: " + itemUsed;

        foreach (Mob targ in target)
        {
            output += "TargetMob: " + targ.name;
        }
        
        return output;
    }
}
