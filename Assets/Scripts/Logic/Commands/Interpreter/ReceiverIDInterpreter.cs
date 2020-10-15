using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Common.Data.ScriptableObjects;
using Assets.Scripts.Logic.Data;

namespace Assets.Scripts.Logic.Commands.Interpreter
{
    public class ReceiverIDInterpreter : ICommandInterpreter
    {
        private ReceiverIDInterpreterConfigSO _receiverIdInterpreterConfigSo;
        public (bool, Command) Interpret(List<string> input, Command command)
        {
            var idRequiringReceivers = _receiverIdInterpreterConfigSo.IDRequiringReceivers;
            if (idRequiringReceivers.Contains(command.CommandReceiver) == false)
            {
                //If the command doesn't require a receiver id, no need to check for it.
                return (true, command);
            }

            //If we got here, then surely the input for receiver is present.
            var potentialReceiverId = RemoveReceiverName(input[0], command.CommandReceiver);
            if (potentialReceiverId.Length <= 0)
            {
                return (false, null);
            }

            if (int.TryParse(potentialReceiverId, out int receiverId))
            {
                command.ReceiverID = receiverId;
                return (true, command);
            }

            //If we got here, then something more is present in there indeed, but it is definitely not an ID.
            return (false, null);
        }

        private string RemoveReceiverName(string commandValue, CommandReceivers receiverType)
        {
            return commandValue.Replace(receiverType.ToString(), "");
        }
    }
}
