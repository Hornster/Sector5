using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    [SerializeField]
    private int roomId;

    public int RoomId { get => roomId; private set => roomId = value; }

    public Vector3 GetCenter()
    {
        return transform.position;
    }
}
