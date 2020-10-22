using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirlockManager : Singleton<AirlockManager>
{
    [SerializeField]
    private List<Airlock> airlocks;

    public List<Airlock> Airlocks { get => airlocks; private set => airlocks = value; }

    public Airlock GetAirlockById(int id)
    {
        for (int i = 0; i < airlocks.Count; i++)
        {
            if(airlocks[i].Id == id)
            {
                return airlocks[i];
            }
        }

        return null;
    }

    private bool CheckAirlockOpen(int id)
    {
        Airlock airlock = GetAirlockById(id);
        return airlock.IsOpen;
    }
}
