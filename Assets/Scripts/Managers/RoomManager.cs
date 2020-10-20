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
}
