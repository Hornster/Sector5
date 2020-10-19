using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Common.CustomEvents;
using Assets.Scripts.Common.Enums;
using Assets.Scripts.Logic.Data;
using UnityEngine;

public class Drone : MonoBehaviour
{
    [SerializeField]
    private int currentRoomId = 0;
    [SerializeField]
    private int droneId = 1;
    [SerializeField]
    private NavMeshComponent navMeshComponent;

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

            if (currentlyProcessedCommand.ReceiverID != droneId)
            {
                continue;
            }

            if(currentlyProcessedCommand.IssuedCommand == AvailableCommands.Go)
            {
                GoToTargetRoom(currentlyProcessedCommand);
            }
            else
            {
                _response?.Invoke(NegativeResponse(currentlyProcessedCommand));
            }
        }
    }

    private void GoToTargetRoom(Command currentlyProcessedCommand)
    {
        int targetRoomId = currentlyProcessedCommand.Args[0];
        Room room = RoomManager.Instance.GetRoomById(targetRoomId);

        if (room == null)
        {
            _response?.Invoke(RoomNotExistResponse(currentlyProcessedCommand));
            return;
        }

        Vector3 targetRoomCenterPosition = room.GetCenter();

        navMeshComponent.SetDestination(targetRoomCenterPosition);
        currentRoomId = targetRoomId;

        _response?.Invoke(PositiveResponse(currentlyProcessedCommand));
    }

    private void ToggleAirLock(Command currentlyProcessedCommand)
    {
        Room room = RoomManager.Instance.GetRoomById(currentRoomId);
        int targetDoorId = currentlyProcessedCommand.Args[0];

        room.UseDoor(targetDoorId);

        _response?.Invoke(DoorUsedResponse(currentlyProcessedCommand));
    }

    private CommandResponse NegativeResponse(Command command)
    {
        return new CommandResponse()
        {
            ConsoleOutputType = ConsoleOutputType.Error,
            MessagePrefix = _whoAmI.ToString() + droneId.ToString() + '>',
            Message = $"Error: Command not recognized: {command.IssuedCommand.ToString()}!"
        };
    }

    private CommandResponse RoomNotExistResponse(Command command)
    {
        return new CommandResponse()
        {
            ConsoleOutputType = ConsoleOutputType.Error,
            MessagePrefix = _whoAmI.ToString() + droneId.ToString() + '>',
            Message = $"Error: Room {command.Args[0]} not exist!"
        };
    }

    private CommandResponse PositiveResponse(Command command)
    {
        return new CommandResponse()
        {
            ConsoleOutputType = ConsoleOutputType.Positive,
            MessagePrefix = _whoAmI.ToString() + droneId.ToString() + '>',
            Message = $"Moving to room {command.Args[0]}."
        };
    }

    private CommandResponse DoorUsedResponse(Command command)
    {
        return new CommandResponse()
        {
            ConsoleOutputType = ConsoleOutputType.Positive,
            MessagePrefix = _whoAmI.ToString() + droneId.ToString() + '>',
            Message = $"Used Airlock {command.Args[0]}."
        };
    }
}
