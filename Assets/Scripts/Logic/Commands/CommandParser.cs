using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        private const char ValueSeparator = ' ';
        private const char CommandSeparator = ';';
        public bool TryParseCommand(string command, out Command parsedCommand)
        {
            parsedCommand = new Command();
            var segmentedCommand = SegmentCommand(command);
            bool isSuccess;
            (isSuccess, parsedCommand) = _receiverTypeInterpreter.Interpret(segmentedCommand, parsedCommand);
            if (isSuccess == false)
            {
                return false;
            }
            (isSuccess, parsedCommand) = _receiverIDInterpreter.Interpret(segmentedCommand, parsedCommand);
            if (isSuccess == false)
            {
                return false;
            }
            (isSuccess, parsedCommand) = _commandTypeInterpreter.Interpret(segmentedCommand, parsedCommand);
            if (isSuccess == false)
            {
                return false;
            }
            (isSuccess, parsedCommand) = _commandArgInterpreter.Interpret(segmentedCommand, parsedCommand);
            if (isSuccess == false)
            {
                return false;
            }

            return true;
        }
        private List<string> SegmentCommand(string command)
        {
            var segmentedCommand = command.Split(ValueSeparator).ToList();
            var commands = new List<List<string>>();
            var currentlyProcessedCommand = new List<string>();

            for (int i = 0; i < segmentedCommand.Count; i++)
            {
                var commandSegmend = segmentedCommand[i];
                if (commandSegmend.Contains(CommandSeparator))
                {
                    //TODO add additional separation for multiple commands. currentlySeparatedCommand should
                    //TODO: have the last piece (before ';') added and then entire list should be tossed into
                    //TODO commands list. currentlySeparatedCommand is created as new list and first element
                    //TODO is what is behuind the ';' sign. Unless it's an empty string.
                }
                else
                {
                    currentlyProcessedCommand.Add(commandSegmend);
                }
            }

            return currentlyProcessedCommand;
        }
    }
}
