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
                    ResponseManager.Instance.CommandNotRecognized(_whoAmI.ToString() + MyId.ToString() + '>', currentlyProcessedCommand.IssuedCommand.ToString());
                }
                else
                {
                    ResponseManager.Instance.DroneMoveTo(_whoAmI.ToString() + MyId.ToString() + '>', "room " + currentlyProcessedCommand.Args[0].ToString());
                }
            }
        }
    }
}
