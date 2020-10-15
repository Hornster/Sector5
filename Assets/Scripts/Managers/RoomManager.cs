using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : Singleton<RoomManager>
{
    [SerializeField]
    private List<Room> rooms;

    public List<Room> Rooms { get => rooms; private set => rooms = value; }

    public Room GetRoomById(int id)
    {
        for (int i = 0; i < rooms.Count; i++)
        {
            if(rooms[i].RoomId == id)
            {
                return rooms[i];
            }
        }

        return null;
    }

    public bool CheckFreeWay(int actualRoomId, int targetRoomId)
    {
        Room actualRoom = GetRoomById(actualRoomId);
        Room targetRoom = GetRoomById(targetRoomId);

        if (actualRoom == null || targetRoom == null)
        {
            Debug.Log("Wrong rooms ID");
            return false;
        }

        return CheckDoorOpen(actualRoom.Doors, targetRoom.Doors);
    }

    private bool CheckDoorOpen(List<Door> actualRoomDoors, List<Door> targetRoomDoors)
    {
        for (int i = 0; i < actualRoomDoors.Count; i++)
        {
            if (targetRoomDoors.Contains(actualRoomDoors[i]))
            {
                return actualRoomDoors[i].IsOpen;
            }
        }

        return false;
    }
}
