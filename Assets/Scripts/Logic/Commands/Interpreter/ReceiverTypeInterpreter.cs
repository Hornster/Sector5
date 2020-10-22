using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Assets.Scripts.Common.CustomCollections.DefaultCollectionsSerialization.Dictionary;
using Assets.Scripts.Common.Data.ScriptableObjects;
using Assets.Scripts.Common.Enums;
using Assets.Scripts.Logic.Data;
using JetBrains.Annotations;
using UnityEngine;

namespace Assets.Scripts.Logic.Commands.Interpreter
{
    public class ReceiverTypeInterpreter : MonoBehaviour, ICommandInterpreter 
    {
        /// <summary>
        /// Position of the receiver part of command among the values.
        /// </summary>
        private const int ReceiverPosition = 0;

        [Tooltip("Data about known receivers.")]
        [SerializeField]
        private ReceiverTypeInterpreterConfigSO _receiverTypeInterpreterConfigSO;
        private List<CommandReceivers> _allReceivers;

        private void Start()
        {
            _allReceivers = (Enum.GetValues(typeof(CommandReceivers)) as CommandReceivers[]).ToList();
            _allReceivers.Remove(CommandReceivers.None); //We don't use this receiver anyway.
        }
        /// <summary>
        /// Performs interpretation of the first argument of the command.
        /// Returns false and null if failed to interpret the value.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public (bool, Command) Interpret(List<string> input, Command command)
        {
            var knownReceivers = _receiverTypeInterpreterConfigSO.KnownReceivers;
            
            if (input.Count <= ReceiverPosition)
            {
                return InvalidCommandType(command);
            }

            var testedCommand = input[ReceiverPosition];

            for (int i = 0; i < _allReceivers.Count; i++)
            {
                //No TryGets - all of the positions need to be supplied to the ScriptableObject.
                //If something's missing - this shall scream in terror and pain.
                var knownCommand = knownReceivers[_allReceivers[i]];
                knownCommand = knownCommand.ToLower();
                if (testedCommand.Contains(knownCommand))
                {
                    if (testedCommand.IndexOf(knownCommand) != 0)
                    {
                        //The checked against receiver name was found but not in the beginning of the command segment.
                        //Ignore this try.
                        continue;
                    }

                    if(IsReceiverLengthEqual(testedCommand, knownCommand.Length) == false)
                    {
                        continue;   //This means that the receiver name was indeed found but there's something more in the segment that
                                    //has a meaning. Most likely it is another receiver name that contains the currently checked one.
                                    //Think of the 'a' letter in "cat".
                    }

                    command.CommandReceiver = _allReceivers[i];

                    return (true, command);
                }
            }

            return InvalidCommandType(command);
        }
        /// <summary>
        /// Checks if the length of the receiver that was found is equal to the length
        /// of entire command segment minus the digits at the end. Returns TRUE if the lengths match,
        /// false otherwise.
        /// </summary>
        /// <param name="receiverFromCommandName">The full receiver name segment that was found in the command.</param>
        /// <param name="receiverLength">The length that the receiver name segment minus digits should have.</param>
        /// <returns></returns>
        private bool IsReceiverLengthEqual(string receiverFromCommandName, int receiverLength)
        {
            string receiverNameWithoutDigits = "";
            for (int i = receiverFromCommandName.Length-1; i >= 0; i--)
            {
                //If the loop reaches to the end by some weird magical means, this means that
                //the receiver name contains only digits and it is not good one.
                //Overwrite the string only when you find non-digit characters.
                if(char.IsDigit(receiverFromCommandName[i]) == false)
                {
                    if(i == receiverFromCommandName.Length - 1)
                    {
                        receiverNameWithoutDigits = receiverFromCommandName;
                        break;//No digits found - don't remove anything or we will get an OutOfRange exception.
                    }

                    receiverNameWithoutDigits = receiverFromCommandName.Remove(i+1);
                    break;
                }
            }

            return receiverNameWithoutDigits.Length == receiverLength;
        }
        private (bool, Command) InvalidCommandType(Command command)
        {
            command.CommandParseError = CommandError.ParseErrorIncorrectCommandReceiver;
            return (false, command);
        }
    }
}
