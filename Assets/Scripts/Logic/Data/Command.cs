﻿using System;
using System.Collections.Generic;
using Assets.Scripts.Common.Enums;
using UnityEngine;


namespace Assets.Scripts.Logic.Data
{
    [Serializable]
    public class Command
    {
        /// <summary>
        /// Who is the receiver of the command?
        /// </summary>
        public CommandReceivers CommandReceiver { get; set; }
        /// <summary>
        /// What is the ID of the receiver (if applicable)?
        /// </summary>
        public int ReceiverID { get; set; }
        /// <summary>
        /// What should the receiver do?
        /// </summary>
        public AvailableCommands IssuedCommand { get; set; }
        /// <summary>
        /// Arguments for the command (if applicable).
        /// </summary>
        public List<int> Args { get; set; }
        public CommandError CommandParseError { get; set; }

        public Command()
        {
            CommandReceiver = CommandReceivers.None;
            IssuedCommand = AvailableCommands.NoCommand;
        }

        public override string ToString()
        {
            var result = $"Command: {CommandReceiver.ToString()}{ReceiverID} {IssuedCommand}";
            if (Args?.Count > 0)
            {
                foreach (var arg in Args)
                {
                    result = result += $" {arg}";
                }
            }
            return result;
        }
    }
}
