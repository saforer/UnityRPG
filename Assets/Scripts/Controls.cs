using UnityEngine;
using System.Collections;

public class Controls : MonoBehaviour {

    public bool UpArrow = false;
    public bool DownArrow = false;
    public bool Z = false;
    public bool X = false;
	
	// Update is called once per frame
	void Update () {
       UpArrow = CheckButton(KeyCode.UpArrow);
       DownArrow = CheckButton(KeyCode.DownArrow);
       Z = CheckButton(KeyCode.Z);
       X = CheckButton(KeyCode.X);
	}

    bool CheckButton(KeyCode inButton)
    {
        if (Input.GetKeyDown(inButton)) return true;
        return false;
    }
}
