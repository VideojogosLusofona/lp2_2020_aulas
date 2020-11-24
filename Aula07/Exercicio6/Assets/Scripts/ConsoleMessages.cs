using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsoleMessages : MonoBehaviour
{
    // Reference to the event master
    private EventMaster em;

    // Awake is called one time at the beginning
    private void Awake()
    {
        // Get reference to the event master
        em = GetComponent<EventMaster>();
    }

    // Use this to add event listeners
    private void OnEnable()
    {
        em.KeyPress += ShowConsoleMessage;
    }

    // Use this to remove event listeners
    private void OnDisable()
    {
        em.KeyPress -= ShowConsoleMessage;
    }

    // Show in the console which key was pressed
    private void ShowConsoleMessage(object sender, KeyEventArgs kea)
    {
        Debug.Log($"{kea.Key} was pressed (event sent by {sender})");
    }
}