using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BattleScreenUI : MonoBehaviour {

    public Camera currentCamera;
    public List<GameObject> uiPlayerTeam;
    public List<GameObject> uiEnemyTeam;
    public GameObject uiCurrentPlayer;
    public GameObject uiCurrentEnemy;
    public MenuListing uiCurrentMenu;
    public string uiString;
    public bool playerMenuDrawing = false;


    void OnGUI()
    {
        DrawReticule(uiCurrentEnemy);
    }

    void DrawReticule(GameObject inUnit)
    {
        Bounds spriteBounds = inUnit.GetComponent<SpriteRenderer>().sprite.bounds;
        Vector3 centerObject = Camera.main.WorldToScreenPoint(new Vector3(inUnit.transform.position.x, inUnit.transform.position.y, 0));
        

        Vector3 topLeft = Camera.main.WorldToScreenPoint(new Vector3(spriteBounds.max.x, -1 * spriteBounds.max.y, 0));
        Vector3 bottomRight = Camera.main.WorldToScreenPoint(new Vector3(spriteBounds.min.x, -1 * spriteBounds.min.y, 0));
        

        Debug.Log(topLeft);
        Debug.Log(bottomRight);

        Rect Location = new Rect(topLeft.x, topLeft.y, bottomRight.x - topLeft.x, topLeft.y -bottomRight.y);
        GUI.DrawTexture(Location, Resources.Load("Reticule") as Texture);
    }
}