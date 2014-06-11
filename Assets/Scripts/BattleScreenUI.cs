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
    public bool SomeBool = false;

    void OnGUI()
    {

     DrawReticule(uiCurrentEnemy);

    }

    public void DrawReticule(GameObject inUnit)
    {
        Bounds spriteBounds = inUnit.GetComponent<SpriteRenderer>().sprite.bounds;
        Vector3 centerObject = Camera.main.WorldToScreenPoint(new Vector3(inUnit.transform.position.x, inUnit.transform.position.y, 0));

        //Center is now in gui coordinates 0 0 top left
        centerObject.y = Screen.height - centerObject.y;

        Vector3 topLeft = Camera.main.WorldToScreenPoint(new Vector3(spriteBounds.min.x, spriteBounds.max.y, 0));
        Vector3 bottomRight = Camera.main.WorldToScreenPoint(new Vector3(spriteBounds.max.x, spriteBounds.min.y, 0));

        topLeft.y = Screen.height - topLeft.y;
        bottomRight.y = Screen.height - bottomRight.y;


        Rect Location = new Rect(centerObject.x - ((bottomRight.x - topLeft.x)/2), centerObject.y + ((bottomRight.y - topLeft.y)/2), bottomRight.x - topLeft.x, topLeft.y - bottomRight.y);
        //Location = new Rect(0, 0, 100, 100);
        GUI.DrawTexture(Location, Resources.Load("Reticule") as Texture);
    }
}