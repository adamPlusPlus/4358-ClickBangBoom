using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class handleCursor : MonoBehaviour {

    public Texture2D mouse;
    public Texture2D interactObject;
    public Texture2D interactFriendly;
    public Texture2D interactHostile;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    private void Start()
    {
        setMouse();
    }

    void setMouse()
    {
        Cursor.SetCursor(mouse, hotSpot, cursorMode);
    }

    void setInteractObject()
    {
        Cursor.SetCursor(interactObject, Vector2.zero, cursorMode);
    }

    void setInteractFriendly()
    {
        Cursor.SetCursor(interactFriendly, Vector2.zero, cursorMode);
    }

    void setInteractHostile()
    {
        Cursor.SetCursor(interactHostile, Vector2.zero, cursorMode);
    }
}