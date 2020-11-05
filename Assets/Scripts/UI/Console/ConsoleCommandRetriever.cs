using System.Text;
using Assets.Scripts.Common.CustomEvents;
using Assets.Scripts.Common.Enums;
using Assets.Scripts.Logic.Commands;
using Assets.Scripts.Logic.Data;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.UI.Console
{
    public class ConsoleCommandRetriever : MonoBehaviour
    {
        [SerializeField] private UnityEvent _clearConsoleInput;
        [SerializeField] private TMP_Text _inputText;
        [SerializeField] private const string AutoResponsePrefix = ">";

        [SerializeField] private ConsoleOutputTypeStringStringUnityEvent _consoleOutput;
        [Tooltip("Called whenever a command was input and its parsing process was a success.")]
        [SerializeField] private CommandListUnityEvent _onCommandRetrieved;

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
            _clearConsoleInput?.Invoke();
            //Clear the input of the console.
            _inputText.text = "";

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
                _consoleOutput?.Invoke(ConsoleOutputType.Regular, AutoResponsePrefix, stringBuilder.ToString());
                _onCommandRetrieved?.Invoke(commands);
            }
        }

        private void ReportCommandError(Command command)
        {
            _consoleOutput?.Invoke(ConsoleOutputType.Error, AutoResponsePrefix, command.ToString());
            if (command.CommandParseError.ToString() == "ParseErrorIncorrectCommandType")
            {
            _consoleOutput?.Invoke(ConsoleOutputType.Error, AutoResponsePrefix, "Error! Incorrect command type");
            }
            else if (command.CommandParseError.ToString() == "ParseErrorIncorrectCommandReceiver")
            {
                _consoleOutput?.Invoke(ConsoleOutputType.Error, AutoResponsePrefix, "Error! Incorrect chosen receiver");
            }
            else if (command.CommandParseError.ToString() == "ParseErrorIncorrectReceiverID")
            {
                _consoleOutput?.Invoke(ConsoleOutputType.Error, AutoResponsePrefix, "Error! Incorrect receiver ID");
            }
            else if (command.CommandParseError.ToString() == "ParseErrorIncorrectCommandArgs")
            {
                _consoleOutput?.Invoke(ConsoleOutputType.Error, AutoResponsePrefix, "Error! Incorrect arguments");
            }
            else
            {
                _consoleOutput?.Invoke(ConsoleOutputType.Error, AutoResponsePrefix, "Error! Logic evaluation error");
            }
        }
    }
}
