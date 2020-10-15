using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Cheat : MonoBehaviour
{

    [MenuItem("DoSomething/UseDoor0")]
    static void UseDoor0()
    {
        Debug.Log("UseDoor0 Start");
        Room room = RoomManager.Instance.GetRoomById(0);

        if(room == null)
        {
            Debug.Log("room0 notexist");
            return;
        }

        room.UseDoor(0);
    }

    [MenuItem("DoSomething/UseDoor1")]
    static void UseDoor1()
    {
        Debug.Log("UseDoor1 Start");
        Room room = RoomManager.Instance.GetRoomById(1);

        if(room == null)
        {
            Debug.Log("room1 notexist");
            return;
        }

        room.UseDoor(1);
    }

    [MenuItem("DoSomething/CheckFreeWayR0R1")]
    static void CheckFreeWayR0R1()
    {
        Debug.Log("CheckFreeWayR0R1 Start");

        bool isFreeWay = RoomManager.Instance.CheckFreeWay(0,1);
        string info = isFreeWay == true ? "Way is open beetween R0 and R1" : "Way is block beetween R0 and R1";

        Debug.Log(info);
    }
}
