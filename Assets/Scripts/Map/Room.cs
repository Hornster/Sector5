using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    [SerializeField]
    private int roomId;
    [SerializeField]
    private List<Door> doors;

    public int RoomId { get => roomId; private set => roomId = value; }
    public List<Door> Doors { get => doors; private set => doors = value; }

    public void UseDoor(int id)
    {
        Door door = GetDoorById(id);

        if(door == null)
        {
            Debug.Log(string.Format("Doors {0}, not exist in Room{1}", id, RoomId));
        }

        door.Use();
    }

    private Door GetDoorById(int id)
    {
        for (int i = 0; i < Doors.Count; i++)
        {
            if(Doors[i].Id == id)
            {
                return Doors[i];
            }
        }

        return null;
    }

    public Vector3 GetCenter()
    {
        return transform.position;
    }
}
