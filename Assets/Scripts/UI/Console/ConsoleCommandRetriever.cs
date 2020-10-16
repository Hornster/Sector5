using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Common.CustomEvents;
using Assets.Scripts.Common.Enums;
using Assets.Scripts.Logic.Commands;
using Assets.Scripts.UI.Console;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class ConsoleCommandRetriever : MonoBehaviour
{
    [SerializeField] private TMP_Text _inputText;
    [SerializeField] private const string AutoResponsePrefix = ">";

    [SerializeField] private ConsoleOutputTypeStringStringUnityEvent _consoleOutput;

    [SerializeField] private CommandParser _commandParser;
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
        var result = _commandParser.TryParseCommand(newInput, out var command);
        if (result == false)
        {
            _consoleOutput?.Invoke(ConsoleOutputType.Error, AutoResponsePrefix, newInput);
            _consoleOutput?.Invoke(ConsoleOutputType.Error, AutoResponsePrefix, command.CommandParseError.ToString());
        }
        else
        {
            _consoleOutput?.Invoke(ConsoleOutputType.Positive, AutoResponsePrefix, command.ToString());
        }
    }
}
