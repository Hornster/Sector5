using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Assets.Scripts.Logic.Commands.Interpreter;
using Assets.Scripts.Logic.Data;
using UnityEngine;

namespace Assets.Scripts.Logic.Commands
{
    public class CommandParser : MonoBehaviour
    {
        [SerializeField]
        private CommandTypeInterpreter _commandTypeInterpreter;
        [SerializeField]
        private ReceiverTypeInterpreter _receiverTypeInterpreter;
        [SerializeField]
        private CommandArgInterpreter _commandArgInterpreter;
        [SerializeField]
        private ReceiverIDInterpreter _receiverIDInterpreter;

        public const char ValueSeparator = ' ';
        public const char CommandSeparator = ';';
        /// <summary>
        /// Tries to parse provided command. Provided command can be made of several commands
        /// divided with CommandSeparator. Single command segments shall be divided with ValueSeparators.
        /// Returns TRUE if parsing was successful. Returns FALSE if error was found. The error
        /// can be found inside parsedCommands, in the command at the end of the list.
        /// </summary>
        /// <param name="command">Data to parse.</param>
        /// <param name="parsedCommands">Result of parsing.</param>
        /// <returns></returns>
        public bool TryParseCommand(string command, out List<Command> parsedCommands)
        {
            parsedCommands = new List<Command>();
            command = TrimCommand(command);
            var segmentedCommands = SegmentCommand(command);

            for(int i = 0; i < segmentedCommands.Count; i++)
            {
                //bool isSuccess;
                var parsedCommand = new Command();
                //(isSuccess, parsedCommand) = _receiverTypeInterpreter.Interpret(segmentedCommands[i], parsedCommand);
                if (TryParseSingleCommand(parsedCommands, segmentedCommands[i], parsedCommand, _receiverTypeInterpreter) == false)
                {
                    return false;
                }
                if (TryParseSingleCommand(parsedCommands, segmentedCommands[i], parsedCommand, _receiverIDInterpreter) == false)
                {
                    return false;
                }
                if (TryParseSingleCommand(parsedCommands, segmentedCommands[i], parsedCommand, _commandTypeInterpreter) == false)
                {
                    return false;
                }
                if (TryParseSingleCommand(parsedCommands, segmentedCommands[i], parsedCommand, _commandArgInterpreter) == false)
                {
                    return false;
                }

                parsedCommands.Add(parsedCommand);
            }

            return true;
        }
        /// <summary>
        /// Removes white characters from beginning and end of the command.
        /// Removes duplicate ValueSeparators from the inside of the command, too.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        private string TrimCommand(string command)
        {
            command =  command.Trim();
            command = Regex.Replace(command, "\\s+", ValueSeparator.ToString(), RegexOptions.Compiled);
            return command;
        }
        /// <summary>
        /// Tries to parse a single command. Returns TRUE if succeeded, FALSE otherwise.
        /// parsingResult contains info about error reason.
        /// </summary>
        /// <param name="parsedCommands">Processed command will be put at the end if something goes wrong.</param>
        /// <param name="segmentedCommand">Data for parsing the command.</param>
        /// <param name="parsingResult">Parsed data is stored here.</param>
        /// <param name="interpreter">Defines which part of command shall be interpreted?</param>
        /// <returns></returns>
        private bool TryParseSingleCommand(List<Command> parsedCommands, List<string> segmentedCommand, Command parsingResult, ICommandInterpreter interpreter)
        {
            bool isSuccess;
            (isSuccess, parsingResult) = interpreter.Interpret(segmentedCommand, parsingResult);
            if (isSuccess == false)
            {
                parsedCommands.Add(parsingResult);
                return false;
            }

            return true;
        }
        /// <summary>
        /// Segments the read command into chunks using the ValueSeparator.
        /// </summary>
        /// <param name="command">Input containing one or more commands.</param>
        /// <returns></returns>
        private List<List<string>> SegmentCommand(string command)
        {
            var segmentedCommand = command.Split(ValueSeparator).ToList();
            var commands = new List<List<string>>();
            var currentlyProcessedCommand = new List<string>();

            for (int i = 0; i < segmentedCommand.Count; i++)
            {
                var commandSegment = segmentedCommand[i].ToLower();
                if (commandSegment.Contains(CommandSeparator))
                {
                    PerformCommandSeparation(commands, ref currentlyProcessedCommand, commandSegment);
                }
                else
                {
                    if(commandSegment.Length > 0)
                    {
                        currentlyProcessedCommand.Add(commandSegment);
                    }
                }
            }

            if(currentlyProcessedCommand.Count > 0)
            {
                commands.Add(currentlyProcessedCommand);
            }

            return commands;
        }
        /// <summary>
        /// Separates commands from each other using the CommandSeparator.
        /// </summary>
        /// <param name="commands">If new command is found, the already processed one will be put in here.</param>
        /// <param name="currentlyProcessedCommand">Currently processed command. Upon finding the separator,
        /// a meaningful part on the left side of it will be added here.</param>
        /// <param name="commandSegment">Currently processed command segment.</param>
        private void PerformCommandSeparation(List<List<string>> commands, ref List<string> currentlyProcessedCommand, string commandSegment)
        {
            var separatedCommands = commandSegment.Split(CommandSeparator);

            if (separatedCommands[0].Length > 0)
            {
                //We can do that since Split will return always at least
                //2 strings. Tested.
                currentlyProcessedCommand.Add(separatedCommands[0]);
            }

            Debug.Log($"Command separator found! Separated commands count: {separatedCommands.Length}");
            for (int j = 1; j < separatedCommands.Length; j++)
            {
                Debug.Log(separatedCommands[j]);
                if (currentlyProcessedCommand.Count > 0)
                {
                    //If we have at least one command segment in current command,
                    //separate it.
                    commands.Add(currentlyProcessedCommand);
                    currentlyProcessedCommand = new List<string>();
                }
                if (separatedCommands[j].Length > 0)
                {
                    //If current separated command is actually a command, not an empty
                    //space, add it.
                    currentlyProcessedCommand.Add(separatedCommands[j]);
                }
            }
        }
    }
}
