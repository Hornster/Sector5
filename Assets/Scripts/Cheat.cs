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
        Airlock airlock = AirlockManager.Instance.GetAirlockById(0);

        if(airlock == null)
        {
            Debug.Log("airlock0 notexist");
            return;
        }
        airlock.Use();
    }

    [MenuItem("DoSomething/UseDoor1")]
    static void UseDoor1()
    {
        Debug.Log("UseDoor1 Start");
        Airlock airlock = AirlockManager.Instance.GetAirlockById(1);

        if(airlock == null)
        {
            Debug.Log("airlock1 notexist");
            return;
        }
        airlock.Use();
    }
}
