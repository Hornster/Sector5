using Assets.Scripts.Common.CustomEvents;
using Assets.Scripts.Common.Enums;
using Assets.Scripts.Logic.Data;
using Assets.Scripts.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class DroneController : MonoBehaviour
    {
        private List<Common.Enums.AvailableCommands> _myCommands = new List<Common.Enums.AvailableCommands>() { AvailableCommands.Go, AvailableCommands.Interface };
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

                if (!_myCommands.Contains(currentlyProcessedCommand.IssuedCommand))
                {
                    continue;
                }

                if (currentlyProcessedCommand.ReceiverID == 0)
                {
                    continue;
                }
                else
                {
                    Drone drone = DroneManager.Instance.Drones.FirstOrDefault(x => x.DroneId == currentlyProcessedCommand.ReceiverID);
                    if (drone != null)
                        drone.ProcessCommand(currentlyProcessedCommand);
                    else
                        ResponseManager.Instance.DroneNotExist(_whoAmI.ToString() + '>', currentlyProcessedCommand.ReceiverID.ToString());                    
                }
            }
        }
    }
}
