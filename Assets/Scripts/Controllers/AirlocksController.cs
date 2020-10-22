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

            if(currentlyProcessedCommand.IssuedCommand == _myCommand)
            {
                UseTargetAirlock(currentlyProcessedCommand);
            }
            else
            {
                _response?.Invoke(NegativeResponse(currentlyProcessedCommand));
            }
        }
    }

    private void UseTargetAirlock(Command currentlyProcessedCommand)
    {
        int targetAirlockId = currentlyProcessedCommand.ReceiverID;
        Airlock airlock = AirlockManager.Instance.GetAirlockById(targetAirlockId);

        if (airlock == null)
        {
            _response?.Invoke(AirlockNotExistResponse(currentlyProcessedCommand));
            return;
        }

        airlock.Use();
        _response?.Invoke(PositiveResponse(currentlyProcessedCommand));
    }

    private CommandResponse NegativeResponse(Command command)
    {
        return new CommandResponse()
        {
            ConsoleOutputType = ConsoleOutputType.Error,
            MessagePrefix = _whoAmI.ToString() + '>',
            Message = $"Error: Command not recognized: {command.IssuedCommand.ToString()}!"
        };
    }

    private CommandResponse AirlockNotExistResponse(Command command)
    {
        return new CommandResponse()
        {
            ConsoleOutputType = ConsoleOutputType.Error,
            MessagePrefix = _whoAmI.ToString() + '>',
            Message = $"Error: Airlock {command.ReceiverID} not exist!"
        };
    }

    private CommandResponse PositiveResponse(Command command)
    {
        return new CommandResponse()
        {
            ConsoleOutputType = ConsoleOutputType.Positive,
            MessagePrefix = _whoAmI.ToString() + '>',
            Message = $"Used airlock {command.ReceiverID}."
        };
    }
}
