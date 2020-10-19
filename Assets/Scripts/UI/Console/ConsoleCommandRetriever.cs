using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Assets.Scripts.Common.CustomEvents;
using Assets.Scripts.Common.Enums;
using Assets.Scripts.Logic.Commands;
using Assets.Scripts.Logic.Data;
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
    /// <summary>
    /// Checks if given receiver has a doable by them command assigned.
    /// </summary>
    [SerializeField] private CommandMeaningEvaluator _commandMeaningEvaluator;
    /// <summary>
    /// Event handler called when a new command is input by the player.
    /// </summary>
    /// <param name="newInput"></param>
    public void NewCommandDelivered(string newInput)
    {
        _consoleOutput?.Invoke(ConsoleOutputType.Regular, AutoResponsePrefix, newInput);
        var result = _commandParser.TryParseCommand(newInput, out var commands);
        bool isCommandLogical = false;
        if (result)
        {
            isCommandLogical = _commandMeaningEvaluator.ValidateMultipleCommands(commands);
        }

        if (result == false)
        {
            ReportCommandError(commands[commands.Count - 1]);
        }
        else if(isCommandLogical == false)
        {
            for (int i = 0; i < commands.Count; i++)
            {
                if(commands[i].CommandParseError != CommandError.NoError)
                {
                    ReportCommandError(commands[i]);
                }
            }
        }
        else
        {
            var stringBuilder = new StringBuilder();
            for(int i = 0; i < commands.Count; i++)
            {
                stringBuilder.AppendLine(commands[i].ToString());
            }
            _consoleOutput?.Invoke(ConsoleOutputType.Positive, AutoResponsePrefix, stringBuilder.ToString());
        }
    }

    private void ReportCommandError(Command command)
    {
        _consoleOutput?.Invoke(ConsoleOutputType.Error, AutoResponsePrefix, command.ToString());
        _consoleOutput?.Invoke(ConsoleOutputType.Error, AutoResponsePrefix, command.CommandParseError.ToString());
    }
}
