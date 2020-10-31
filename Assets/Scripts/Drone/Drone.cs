using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Common.CustomEvents;
using Assets.Scripts.Common.Enums;
using Assets.Scripts.Logic.Data;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Drone : MonoBehaviour
{
    [SerializeField]
    private int currentRoomId = 0;
    [SerializeField]
    private int droneId = 1;
    public int DroneId { get { return droneId; } }
    [SerializeField]
    private Interface interfaceComponent;
    [SerializeField]
    private NavMeshComponent navMeshComponent;
    [SerializeField]
    bool pathBlocked = false;
    [SerializeField]
    NavMeshPathStatus NavMeshPathStatus;

    private AvailableCommands commandInterface = AvailableCommands.Interface;
    private AvailableCommands commandGo = AvailableCommands.Go;
    private CommandReceivers _whoAmI = CommandReceivers.Drone;

    public void ReceiveCommand(List<Command> commands)
    {
        for (int i = 0; i < commands.Count; i++)
        {
            var currentlyProcessedCommand = commands[i];
            ProcessCommand(currentlyProcessedCommand);
        }
    }

    public void ProcessCommand(Command currentlyProcessedCommand)
    {
        if (currentlyProcessedCommand.CommandReceiver != _whoAmI)
        {
            return;
        }

        if (currentlyProcessedCommand.ReceiverID != droneId)
        {
            return;
        }

        if (currentlyProcessedCommand.IssuedCommand == commandGo)
        {
            GoToTargetRoom(currentlyProcessedCommand);
        }
        else if (currentlyProcessedCommand.IssuedCommand == commandInterface)
        {
            navMeshComponent.SetDestination(interfaceComponent.gameObject.transform.position);
            ResponseManager.Instance.DroneMoveTo(_whoAmI.ToString() + droneId.ToString() + '>', "Interface");
        }
        else
        {
            ResponseManager.Instance.CommandNotRecognized(_whoAmI.ToString() + droneId.ToString() + '>', currentlyProcessedCommand.IssuedCommand.ToString());
        }
    }

    private void GoToTargetRoom(Command currentlyProcessedCommand)
    {
        int targetRoomId = currentlyProcessedCommand.Args[0];
        Room room = RoomManager.Instance.GetRoomById(targetRoomId);

        if (room == null)
        {
            ResponseManager.Instance.RoomNotExist(_whoAmI.ToString() + droneId.ToString() + '>', currentlyProcessedCommand.Args[0].ToString());
            return;
        }

        Vector3 targetRoomCenterPosition = room.GetCenter();

        navMeshComponent.SetDestination(targetRoomCenterPosition);
        currentRoomId = targetRoomId;

        ResponseManager.Instance.DroneMoveTo(_whoAmI.ToString() + droneId.ToString() + '>', "room " + currentlyProcessedCommand.Args[0].ToString());

    }

    private void Start()
    {
        GetComponentInChildren<TextMesh>().text = $"D{droneId.ToString()}";
    }

    private void Update()
    {
        NavMeshPathStatus = navMeshComponent.PathStatus;

        if (navMeshComponent.PathStatus.Equals(NavMeshPathStatus.PathPartial) && !pathBlocked)
        {
            pathBlocked = true;
            ResponseManager.Instance.PathBlocked(_whoAmI.ToString() + droneId.ToString() + '>');
        }

        if (navMeshComponent.PathStatus.Equals(NavMeshPathStatus.PathComplete) && pathBlocked)
        {
            pathBlocked = false;
        }

        if(navMeshComponent.CheckDestination())
        {
            ResponseManager.Instance.ReachDestination(_whoAmI.ToString() + droneId.ToString() + '>', droneId.ToString());
            navMeshComponent.Stop();
        }
    }
}
