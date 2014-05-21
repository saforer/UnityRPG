using UnityEngine;
using System.Collections;

public class RPGButton {
    public Texture textureOn;
    public Texture textureOff;
    public Texture textureLock;
    public string buttonName;
    public MenuButtonState currentState;
    
    public RPGButton (Texture inOn, Texture inOff, Texture inLock, string inName) 
    {
        currentState = MenuButtonState.Off;

        textureOn = inOn;
        textureOff = inOff;
        textureLock = inLock;
        
        buttonName = inName;
    }
}
