using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Common.CustomEvents;
using Assets.Scripts.Common.Enums;
using Assets.Scripts.Logic.Data;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Logic.Examples
{
    public class CommandListener : MonoBehaviour
    {
        private const int MyId = 1;
        private AvailableCommands _myCommand = AvailableCommands.Go;
        private CommandReceivers _whoAmI = CommandReceivers.Drone;

        [Tooltip("Used to yeet response to the console so user can see if we failed to execute the command or succeeded successfully.")]
        [SerializeField]
        private CommandResponseUnityEvent _response;

        public void ReceiveCommand(List<Command> commands)
        {
            for (int i = 0; i < commands.Count; i++)
            {
                var currentlyProcessedCommand = commands[i];
                if (currentlyProcessedCommand.CommandReceiver != _whoAmI)
                {
                    continue;
                }

                if (currentlyProcessedCommand.ReceiverID != MyId)
                {
                    continue;
                }

                if (currentlyProcessedCommand.IssuedCommand != _myCommand)
                {
                    _response?.Invoke(NegativeResponse(currentlyProcessedCommand));
                }
                else
                {
                    _response?.Invoke(PositiveResponse(currentlyProcessedCommand));
                }
            }
        }

        private CommandResponse NegativeResponse(Command command)
        {
            return new CommandResponse()
            {
                ConsoleOutputType = ConsoleOutputType.Error,
                MessagePrefix = _whoAmI.ToString() + MyId.ToString() + '>',
                Message = $"Error: Command not recognized: {command.IssuedCommand.ToString()}!"
            };
        }
        private CommandResponse PositiveResponse(Command command)
        {
            return new CommandResponse()
            {
                ConsoleOutputType = ConsoleOutputType.Positive,
                MessagePrefix = _whoAmI.ToString() + MyId.ToString() + '>',
                Message = $"Moving to room {command.Args[0]}."
            };
        }

    }
}
