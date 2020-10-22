using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class NavMeshComponent : MonoBehaviour
{
    NavMeshAgent navMeshAgent;
    [SerializeField]
    Vector3 targetPos;
    [SerializeField]
    public NavMeshPathStatus PathStatus { get { return GetPathStatus(); } }

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    public void SetDestination(Vector3 vector3)
    {
        navMeshAgent.isStopped = false;
        targetPos = vector3;
        navMeshAgent.SetDestination(vector3);
    }

    public void SetDestination(GameObject gameObject)
    {
        SetDestination(targetPos);
    }

    private NavMeshPathStatus GetPathStatus()
    {
        NavMeshPath navMeshPath = new NavMeshPath();
        navMeshAgent.CalculatePath(targetPos, navMeshPath);
        return navMeshPath.status;
    }

    public void Stop ()
    {
        navMeshAgent.isStopped = true;
    }

    public bool CheckDestination()
    {
        return !navMeshAgent.isStopped && Vector3.Distance(gameObject.transform.position, targetPos) < navMeshAgent.stoppingDistance;
    }
}
