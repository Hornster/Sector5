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
            ResponseManager.Instance.PathBlocked(CommandReceiverType.ToString() + Id.ToString() + '>');
        }

        if (navMeshComponent.PathStatus.Equals(NavMeshPathStatus.PathComplete) && pathBlocked)
        {
            pathBlocked = false;
        }

        if(navMeshComponent.CheckDestination())
        {
            ResponseManager.Instance.ReachDestination(CommandReceiverType.ToString() + Id.ToString() + '>', Id.ToString());
            navMeshComponent.Stop();
        }
    }
}
