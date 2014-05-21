using UnityEngine;
using System.Collections;

public class BattleLogic : MonoBehaviour {

    private BattleUI currentUI;

    void Start ()
    {
        currentUI = gameObject.GetComponent<BattleUI>();
    }

    void Update()
    {

    } 
}
