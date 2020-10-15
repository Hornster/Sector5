using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Logic.Data;
using UnityEngine;

namespace Assets.Scripts.Logic.Commands
{
    public class CommandParser : MonoBehaviour
    {
        private const char ValueSeparator = ' ';
        private const char CommandSeparator = ' ';
        public bool TryParseCommand(string command, out Command parsedCommant)
        {

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

                }
                else
                {
                    currentlyProcessedCommand.Add(commandSegmend);
                }
            }
        }
    }
}
