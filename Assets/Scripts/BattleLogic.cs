using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class BattleLogic : MonoBehaviour {
    List<Mob> playerTeam;
    List<Mob> enemyTeam;

    void Start()
    {
        //Make teams
        playerTeam = GetTeam(ValidTeam.Player);
        enemyTeam = GetTeam(ValidTeam.Enemy);

        //Move teams to correct area
        MoveTeam(playerTeam, ValidTeam.Player);
        MoveTeam(enemyTeam, ValidTeam.Enemy);
    }

    List<Mob> GetTeam(ValidTeam teamIn)
    {
        List<Mob> tempList = new List<Mob>();
        GameObject tempPlayer;

        tempPlayer = GetUnit(ValidMob.Player);
        tempList.Add(tempPlayer.GetComponent<Mob>());

        tempPlayer = GetUnit(ValidMob.Player);
        tempList.Add(tempPlayer.GetComponent<Mob>());

        return tempList;
    }


    GameObject GetUnit(ValidMob mobType)
    {
        GameObject player = Instantiate(Resources.Load("GameObject/Mobject"),Vector3.zero,Quaternion.identity) as GameObject;
        player.AddComponent<Mob>();
        player.GetComponent<Mob>().YouAre(ValidMob.Jelly);
        
        return player;
    }

    void MoveTeam (List<Mob> inTeam, ValidTeam teamType)
    {
        int i = 0;
        int j = inTeam.Count();
        foreach (Mob mob in inTeam)
        {
            MoveUnit(mob, i, j, teamType);
            i++;
        }
    }

    void MoveUnit(Mob inMob, int i, int j, ValidTeam inTeam)
    {
        Vector3 tempPos = Vector3.zero;
        float spacing = .9f;

        tempPos.x += (i * spacing);
        tempPos.x -= (j * spacing) / 2;

        switch (inTeam)
        {
            default:
            case ValidTeam.Player:
                tempPos.y -= 2;
                break;
            case ValidTeam.Enemy:
                tempPos.y += 2;
                break;
        }

        inMob.transform.position = tempPos;
    }
}

public enum ValidTeam
{
    Player,
    Enemy
}