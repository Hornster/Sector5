using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Common.Data.ScriptableObjects;
using Assets.Scripts.Common.Enums;
using Assets.Scripts.Logic.Data;
using UnityEngine;

namespace Assets.Scripts.Logic.Commands.Interpreter
{
    /// <summary>
    /// Intepretes command type from provided command list.
    /// </summary>
    public class CommandTypeInterpreter : MonoBehaviour, ICommandInterpreter
    {
        [Tooltip("Configuration of available commands.")]
        [SerializeField]
        private CommandTypeInterpreterConfigSO _commandInterpreterConfig;
        /// <summary>
        /// All command types that are present in the game.
        /// </summary>
        private AvailableCommands[] _availableCommands;
        /// <summary>
        /// The index under which the command value is hidden.
        /// </summary>
        private const int CommandIndex = 1;

        private void Start()
        {
            _availableCommands = Enum.GetValues(typeof(AvailableCommands)) as AvailableCommands[];
        }
        /// <summary>
        /// Parses the command type part of the command. If failure, returns false and puts the
        /// reason in command error field.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        public (bool, Command) Interpret(List<string> input, Command command)
        {
            if (input.Count < 2)
            {
                //Some commands may have no action assigned and that is fine. In terms of
                //grammar at least.
                command.IssuedCommand = AvailableCommands.NoCommand;
                return (true, command);
            }

            var knownCommands = _commandInterpreterConfig.KnownCommands;
            var potentialCommand = input[CommandIndex];

            for (int i = 0; i < _availableCommands.Length; i++)
            {
                if (_availableCommands[i] == AvailableCommands.NoCommand)
                {
                    continue;   //We do not check this case as it was already checked before.
                }

                var availableCommand = _availableCommands[i];
                if (knownCommands.TryGetValue(availableCommand, out var commandName))
                {
                    commandName = commandName.ToLower();
                    if (potentialCommand.Contains(commandName))
                    {
                        if (potentialCommand.IndexOf(commandName) != 0)
                        {
                            //The checked against receiver name was found but not in the beginning of the command segment.
                            //Ignore this try.
                            continue;
                        }

                        if (IsReceiverLengthEqual(potentialCommand, commandName.Length) == false)
                        {
                            continue;   //This means that the command name was indeed found but there's something more in the segment that
                                        //has a meaning. Most likely it is another receiver name that contains the currently checked one.
                                        //Think of the 'a' letter in "cat".
                        }

                        command.IssuedCommand = availableCommand;
                        return (true, command);
                    }
                }

            }
            //If we got here, that means there was a value but it was not a known command value.
            command.CommandParseError = CommandError.ParseErrorIncorrectCommandType;
            return (false, command);
        }
        /// <summary>
        /// Checks if the length of the receiver that was found is equal to the length
        /// of entire command segment minus the digits at the end. Returns TRUE if the lengths match,
        /// false otherwise.
        /// </summary>
        /// <param name="foundCommandName">The full receiver name segment that was found in the command.</param>
        /// <param name="commandExpectedLength">The length that the receiver name segment minus digits should have.</param>
        /// <returns></returns>
        private bool IsReceiverLengthEqual(string foundCommandName, int commandExpectedLength)
        {
            string commandNameWIthoutDigits = "";
            for (int i = foundCommandName.Length - 1; i >= 0; i--)
            {
                //If the loop reaches to the end by some weird magical means, this means that
                //the command name contains only digits and it is not good one.
                //Overwrite the string only when you find non-digit characters.
                if (char.IsDigit(foundCommandName[i]) == false)
                {
                    if (i == foundCommandName.Length - 1)
                    {
                        commandNameWIthoutDigits = foundCommandName;
                        break;//No digits found - don't remove anything or we will get an OutOfRange exception.
                    }

                    commandNameWIthoutDigits = foundCommandName.Remove(i + 1);
                    break;
                }
            }

            return commandNameWIthoutDigits.Length == commandExpectedLength;
        }
    }
}
