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
    public class CommandTypeInterpreter : ICommandInterpreter
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
                    if (potentialCommand.Contains(commandName))
                    {
                        command.IssuedCommand = availableCommand;
                        return (true, command);
                    }
                }
            }
            //If we got here, that means there was a value but it was not a known command value.
            command.CommandParseError = CommandError.ParseErrorIncorrectCommandType;
            return (false, command);
        }

    }
}
