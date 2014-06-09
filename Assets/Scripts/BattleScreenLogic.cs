using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum Team
{
    Player,
    Enemy
}

public class BattleScreenLogic : MonoBehaviour {

    List<GameObject> enemyTeam;
    List<GameObject> playerTeam;
    BattleScreenUI currentUI;

    void Start()
    {
        //Get UI
        currentUI = gameObject.GetComponent<BattleScreenUI>();

        //Get Enemies
        enemyTeam = GetEnemies();

        //Get Players
        playerTeam = GetPlayers();

        //Move objects to correct position
        MoveUnits(enemyTeam, Team.Enemy);
        MoveUnits(playerTeam, Team.Player);

        //Tell UI about players and enemies
        currentUI.uiPlayerTeam = playerTeam;
        currentUI.uiEnemyTeam = enemyTeam;
        currentUI.uiCurrentPlayer = playerTeam[0];
        currentUI.uiCurrentEnemy = enemyTeam[0];
    }

    List<GameObject> GetEnemies()
    {
        List<GameObject> output = new List<GameObject>();
        for (int i = 0; i<1; i++)
        {
            GameObject player = (GameObject)Resources.Load("GameObject/Mobject");
            GameObject tempMob = (GameObject)Instantiate(player, new Vector3(0, 0, 0), Quaternion.identity);
            tempMob.GetComponent<Mob>().IsMob(ValidMob.Skeleton);
            output.Add(tempMob);
        }
        return output;
    }

    List<GameObject> GetPlayers()
    {
        List<GameObject> output = new List<GameObject>();
        for (int i = 0; i < 1; i++)
        {
            GameObject player = (GameObject)Resources.Load("GameObject/Mobject");
            GameObject tempMob = (GameObject)Instantiate(player, new Vector3(0, 0, 0), Quaternion.identity);
            tempMob.GetComponent<Mob>().IsMob(ValidMob.Player);
            output.Add(tempMob);
        }
        return output;
    }

    void MoveUnits(List<GameObject> inEnemies, Team k)
    {
        int i = 0;
        int j = inEnemies.Count;
        foreach (GameObject mob in inEnemies)
        {
            MoveUnit(mob, i, j, k);
            i++;
        }
    }

    void MoveUnit(GameObject inMob, int i, int j, Team k)
    {
        Vector3 tempPosition = Vector3.zero;
        float tempWidth = inMob.GetComponent<SpriteRenderer>().sprite.rect.width / 50;

        //Move the mob right the lower in the list the mob is
        //Move the list left for how many mobs there are total, so they can be centered

        switch (k)
        {
            case Team.Enemy:
            default:
                //Move enemies up to their own row
                tempPosition.y += 2;
                break;
            case Team.Player:
                //Move players down to their own row
                tempPosition.y += -2;
                break;
        }

        //Push the new position to the mob
        inMob.transform.position = tempPosition;
    }
}
