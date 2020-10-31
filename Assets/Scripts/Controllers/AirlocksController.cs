using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Common.CustomEvents;
using Assets.Scripts.Common.Enums;
using Assets.Scripts.Logic.Data;
using UnityEngine;

public class AirlocksController : MonoBehaviour
{
    private AvailableCommands _myCommand = AvailableCommands.ToggleAirlock;
    private CommandReceivers _whoAmI = CommandReceivers.Airlock;

    public void ReceiveCommand(List<Command> commands)
    {
        for (int i = 0; i < commands.Count; i++)
        {
            var currentlyProcessedCommand = commands[i];
            if (currentlyProcessedCommand.CommandReceiver != _whoAmI)
            {
                continue;
            }

            if(currentlyProcessedCommand.IssuedCommand == _myCommand)
            {
                UseTargetAirlock(currentlyProcessedCommand);
            }
            else
            {
                ResponseManager.Instance.CommandNotRecognized(_whoAmI.ToString() + '>', currentlyProcessedCommand.IssuedCommand.ToString());
            }
        }
    }

    private void UseTargetAirlock(Command currentlyProcessedCommand)
    {
        int targetAirlockId = currentlyProcessedCommand.ReceiverID;
        Airlock airlock = AirlockManager.Instance.GetAirlockById(targetAirlockId);

        if (airlock == null)
        {
            ResponseManager.Instance.AirlockNotExist(_whoAmI.ToString() + '>', currentlyProcessedCommand.ReceiverID.ToString());
            return;
        }

        airlock.Use();
        ResponseManager.Instance.UsedAirlock(_whoAmI.ToString() + '>', currentlyProcessedCommand.ReceiverID.ToString());
    }
}
