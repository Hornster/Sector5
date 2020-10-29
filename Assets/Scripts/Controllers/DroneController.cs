using Assets.Scripts.Common.CustomEvents;
using Assets.Scripts.Common.Enums;
using Assets.Scripts.Logic.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class DroneController : Controller
{
    protected override void Initialize()
    {
        MyCommands = new List<AvailableCommands>() { AvailableCommands.Go, AvailableCommands.Interface };
        WhoAmI = CommandReceivers.Drone;
    }

    protected override void Execute(InteractiveObject obj, Command command)
    {
        Drone drone = obj as Drone;

        if(drone == null)
        {
            return;
        }

        if(command.IssuedCommand == AvailableCommands.Interface)
        {
            GoToTargetInterface(command, drone);
        }
        else if(command.IssuedCommand == AvailableCommands.Go)
        {
            GoToTargetRoom(command, drone);
        }
    }

    private void GoToTargetInterface(Command command, Drone drone)
    {
        InteractiveObject interfaceObject = ObjectsManager.Instance.GetObject(0, CommandReceivers.Interface);

        if (interfaceObject == null)
        {
            // _response?.Invoke(InterfaceNotExistResponse(command));
            return;
        }

        drone.SetDestination(interfaceObject.gameObject.transform.position);
        // _response?.Invoke(InterfaceResponse(command));
    }

    private void GoToTargetRoom(Command command, Drone drone)
    {
        int targetRoomId = command.Args[0];
        Room room = RoomManager.Instance.GetRoomById(targetRoomId);

        if (room == null)
        {
            // _response?.Invoke(RoomNotExistResponse(command));
            return;
        }

        Vector3 targetRoomCenterPosition = room.GetCenter();
        drone.SetDestination(targetRoomCenterPosition);
        // _response?.Invoke(PositiveResponse(command));
    }
}