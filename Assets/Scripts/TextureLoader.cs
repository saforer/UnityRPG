using UnityEngine;
using System.Collections;

public enum ValidSprites
{
    Jelly,
    Player,
    Skeleton
}

public class TextureLoader : MonoBehaviour {
    public Sprite Jelly;
    
    public Texture GetTexture(ValidSprites desiredSprite)
    {
        switch (desiredSprite)
        {
            case ValidSprites.Jelly:
                return Jelly.texture;
            default:
                return Jelly.texture;
        }
    }
}
