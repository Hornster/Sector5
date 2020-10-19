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
    public class CommandArgInterpreter : MonoBehaviour, ICommandInterpreter
    {
        private const int CommandArgPosition = 2;
        [SerializeField]
        private CommandArgInterpreterConfigSO _commandsWithArgs;
        public (bool, Command) Interpret(List<string> input, Command command)
        {
            command.Args = new List<int>();

            var argValue = -1;
            var knownCommands = _commandsWithArgs.CommandsWithArgs;

            if (knownCommands.TryGetValue(command.IssuedCommand, out var commandArgMarker))
            {
                commandArgMarker = commandArgMarker.ToLower();
                if (input.Count < CommandArgPosition+1)
                {
                    //Command requires an argument but none was supplied.
                    return InvalidArg(command);
                }

                var potentialArgValue = input[CommandArgPosition];

                if (potentialArgValue.Contains(commandArgMarker) == false)
                {
                    //Command requires an argument but it wasn't marked properly.
                    return InvalidArg(command);
                }

                //The command has properly marked argument - try to parse its value. Get rid of the marker...
                potentialArgValue = potentialArgValue.Replace(commandArgMarker, "");
                //...and try parsing the number.
                if (int.TryParse(potentialArgValue, out int argParsedValue) == false)
                {
                    //Read argument could not be parsed. Bad argument.
                    return InvalidArg(command);
                }
                //Everything's fine, we got the argument.
                command.Args.Add(argParsedValue);
                return (true, command);
            }
            //Getting here means that there are no arguments assigned to this command. We can safely leave.
            return (true, command);

        }

        private (bool, Command) InvalidArg(Command command)
        {
            command.CommandParseError = CommandError.ParseErrorIncorrectCommandArgs;
            return (false, command);
        }
    }
}
