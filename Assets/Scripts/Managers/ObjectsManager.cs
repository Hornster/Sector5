using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsManager : Singleton<ObjectsManager>
{
    [SerializeField]
    private List<InteractiveObject> objects;

    public List<InteractiveObject> Objects { get => objects; private set => objects = value; }

    public InteractiveObject GetObject(int id, CommandReceivers type)
    {
        for (int i = 0; i < Objects.Count; i++)
        {
            if(Objects[i].CommandReceiverType == type && Objects[i].Id == id)
            {
                return Objects[i];
            }
        }

        return null;
    }

    public void AddObject(InteractiveObject obj)
    {
        InteractiveObject interactiveObject = GetObject(obj.Id, obj.CommandReceiverType);

        if(interactiveObject == null)
        {
            Objects.Add(obj);
        }
        else
        {
            Debug.Log($"Object: {obj.CommandReceiverType} {obj.Id} not exist");
        }
    }
}
