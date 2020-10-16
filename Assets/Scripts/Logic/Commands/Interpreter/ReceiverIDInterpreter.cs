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
    public class ReceiverIDInterpreter : ICommandInterpreter
    {
        [SerializeField]
        private ReceiverIDInterpreterConfigSO _receiverIdInterpreterConfigSo;
        [SerializeField]
        private ReceiverTypeInterpreterConfigSO _receiverTypeInterpreterConfigSo;
        public (bool, Command) Interpret(List<string> input, Command command)
        {
            var idRequiringReceivers = _receiverIdInterpreterConfigSo.IDRequiringReceivers;
            if (idRequiringReceivers.Contains(command.CommandReceiver) == false)
            {
                //If the command doesn't require a receiver id, no need to check for it.
                return (true, command);
            }

            //If we got here, then surely the input for receiver is present.
            var receiverMark = _receiverTypeInterpreterConfigSo.KnownReceivers[command.CommandReceiver];
            var potentialReceiverId = RemoveReceiverName(input[0], receiverMark);
            
            if (potentialReceiverId.Length <= 0)
            {
                return InvalidReceiverID(command);
            }

            if (int.TryParse(potentialReceiverId, out int receiverId))
            {
                command.ReceiverID = receiverId;
                return (true, command);
            }

            //If we got here, then something more is present in there indeed, but it is definitely not an ID.
            return InvalidReceiverID(command);
        }

        private string RemoveReceiverName(string commandValue, string receiverMark)
        {
            return commandValue.Replace(receiverMark.ToLower(), "");
        }

        private (bool, Command) InvalidReceiverID(Command command)
        {
            command.CommandParseError = CommandError.ParseErrorIncorrectReceiverID;
            return (false, command);
        }
    }
}
