using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Common.CustomEvents;
using Assets.Scripts.Common.Enums;
using Assets.Scripts.UI.Console;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class ConsoleCommandRetriever : MonoBehaviour
{
    [SerializeField] private TMP_Text _inputText;
    [SerializeField] private const string AutoResponsePrefix = ">";

    [SerializeField] private ConsoleOutputTypeStringStringUnityEvent _consoleOutput;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /// <summary>
    /// Event handler called when a new command is input by the player.
    /// </summary>
    /// <param name="newInput"></param>
    public void NewCommandDelivered(string newInput)
    {
        _consoleOutput?.Invoke(ConsoleOutputType.Regular, AutoResponsePrefix, newInput);
    }
}
