using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventMaster : MonoBehaviour
{

    // The background image
    [SerializeField] private Texture background = null;

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)) OnKeyPress('W');
        if (Input.GetKeyDown(KeyCode.S)) OnKeyPress('S');
        if (Input.GetKeyDown(KeyCode.A)) OnKeyPress('A');
        if (Input.GetKeyDown(KeyCode.D)) OnKeyPress('D');
    }

    // Use Unity's immediate mode GUI (IMGUI) to display information
    private void OnGUI()
    {
        // Set this GUI rendering to background
        GUI.depth = 1;

        // Draw background
        if (background != null)
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height),
            background, ScaleMode.StretchToFill);

        // Set default GUI color
        GUI.color = Color.white;

        // Show label for pressing keys
        GUI.Label(new Rect(10, 10, 200, 50), "Press W, S, A, D keys");
    }


    // This method triggers the event. It can only be called from this class
    // or subclasses
    protected virtual void OnKeyPress(char key)
    {
        KeyEventArgs kea = new KeyEventArgs(key);
        if (KeyPress != null) KeyPress(this, kea);
    }

    // Others can add or remove listeners to the key press event
    public event EventHandler<KeyEventArgs> KeyPress;
}
