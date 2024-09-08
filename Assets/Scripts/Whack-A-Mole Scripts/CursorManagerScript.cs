using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManagerScript : MonoBehaviour
{
    public Texture2D[] cursorTexture;

    public void setCursorMalletIdle()
    {
        Cursor.SetCursor(cursorTexture[0], new Vector2(cursorTexture[0].width / 2, cursorTexture[0].height / 2), CursorMode.ForceSoftware);
    }

    public void setCursorMalletHit()
    {
        Cursor.SetCursor(cursorTexture[1], new Vector2(cursorTexture[1].width / 2, cursorTexture[1].height / 2), CursorMode.ForceSoftware);
    }

    public void setCursorDefault()
    {
        Cursor.SetCursor(null, new Vector2(32, 32), CursorMode.Auto);
    }
}
