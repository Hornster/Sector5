using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Common.CustomEvents;
using Assets.Scripts.Common.Enums;
using Assets.Scripts.Logic.Data;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Drone : InteractiveObject
{
    [SerializeField]
    private Interface interfaceComponent;
    [SerializeField]
    private NavMeshComponent navMeshComponent;
    [SerializeField]
    bool pathBlocked = false;
    [SerializeField]
    NavMeshPathStatus NavMeshPathStatus;

    public override void Use()
    {

    }

    public void SetDestination(Vector3 position)
    {
        navMeshComponent.SetDestination(position);
    }

    private CommandResponse PathBlockedResponse()
    {
        return new CommandResponse()
        {
            ConsoleOutputType = ConsoleOutputType.Warning,
            MessagePrefix = CommandReceiverType.ToString() + Id.ToString() + '>',
            Message = string.Format("Path blocked")
        };
    }

    private CommandResponse ReachedDestination()
    {
        return new CommandResponse()
        {
            ConsoleOutputType = ConsoleOutputType.Positive,
            MessagePrefix = CommandReceiverType.ToString() + Id.ToString() + '>',
            Message = $"D{Id.ToString()} reached target"
        };
    }

    private void Start()
    {
        GetComponentInChildren<TextMesh>().text = $"D{Id.ToString()}";
    }

    private void Update()
    {
        NavMeshPathStatus = navMeshComponent.PathStatus;

        if (navMeshComponent.PathStatus.Equals(NavMeshPathStatus.PathPartial) && !pathBlocked)
        {
            pathBlocked = true;
            // _response?.Invoke(PathBlockedResponse());
        }

        if (navMeshComponent.PathStatus.Equals(NavMeshPathStatus.PathComplete) && pathBlocked)
        {
            pathBlocked = false;
        }

        if(navMeshComponent.CheckDestination())
        {
            // _response?.Invoke(ReachedDestination());
            navMeshComponent.Stop();
        }
    }
}
