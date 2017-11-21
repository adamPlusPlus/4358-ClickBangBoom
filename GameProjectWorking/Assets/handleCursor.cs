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
        SetMouse();
    }

    private void Update()
    {
        
    }

    public void SetMouse()
    {
        Cursor.SetCursor(mouse, hotSpot, cursorMode);
    }

    public void SetInteractObject()
    {
        Cursor.SetCursor(interactObject, hotSpot, cursorMode);
    }

    public void SetInteractFriendly()
    {
        Cursor.SetCursor(interactFriendly, hotSpot, cursorMode);
    }

    void SetInteractHostile()
    {
        Cursor.SetCursor(interactHostile, hotSpot, cursorMode);
    }
}