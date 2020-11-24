using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventMaster : MonoBehaviour
{

    // The background image
    [SerializeField] private Texture background = null;

    // Number of key presses to raise a multiple key press event
    [SerializeField] private int multiplePresses = 10;

    // Number of key presses for each key
    private IDictionary<char, int> numberOfKeyPresses;

    // Called once in the beginning
    private void Awake()
    {
        numberOfKeyPresses = new Dictionary<char, int>()
        {
            {'W', 0},
            {'S', 0},
            {'A', 0},
            {'D', 0}
        };
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)) ActOnKeyPress('W');
        if (Input.GetKeyDown(KeyCode.S)) ActOnKeyPress('S');
        if (Input.GetKeyDown(KeyCode.A)) ActOnKeyPress('A');
        if (Input.GetKeyDown(KeyCode.D)) ActOnKeyPress('D');
    }

    private void ActOnKeyPress(char key)
    {
        // Increment number of presses for current key
        numberOfKeyPresses[key]++;

        // Was this press a multiple of multiplePresses variable?
        if (numberOfKeyPresses[key] % multiplePresses == 0)
            // If so, raise the respective event
            OnKeyPressMultiple(key, numberOfKeyPresses[key]);

        // Raise the simple key press event
        OnKeyPress(key);
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


    // This method triggers the key press event. It can only be called from
    // this class or subclasses
    protected virtual void OnKeyPress(char key)
    {
        KeyEventArgs kea = new KeyEventArgs(key);
        if (KeyPress != null) KeyPress(this, kea);
    }

    // This method triggers the key pressed multiple times event. It can only
    // be called from this class or subclasses
    protected virtual void OnKeyPressMultiple(char key, int times)
    {
        if (KeyPressMultiple != null) KeyPressMultiple.Invoke(key, times);
    }

    // This event will be raised when a WSAD key is pressed
    // Others can add or remove listeners to the key press event
    public event EventHandler<KeyEventArgs> KeyPress;

    // This event will be raised when one of W, S, A, D key is pressed a number
    // of times equal to the multiplePresses variable
    // Listeners can be added or removed in code (using Add/RemoveListener()
    // methods) or in the Unity Editor
    [SerializeField]
    private KeyTimesUnityEvent KeyPressMultiple;

    // When we use a unity event with parameters, we must create a class like
    // this one, extending UnityEvent<T1, ...> according to the number of
    // parameters we want
    [Serializable]
    public class KeyTimesUnityEvent : UnityEvent<char, int> { }
}
