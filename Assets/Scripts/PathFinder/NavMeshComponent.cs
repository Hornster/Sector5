using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class NavMeshComponent : MonoBehaviour
{
    NavMeshAgent navMeshAgent;
    [SerializeField]
    Vector3? targetPos;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    public NavMeshPathStatus SetDestination(Vector3 vector3)
    {
        targetPos = vector3;
        navMeshAgent.SetDestination(vector3);
        NavMeshPath path = new NavMeshPath();
        navMeshAgent.CalculatePath(vector3, path);
        return path.status;
    }

    public void SetDestination(GameObject gameObject)
    {
        targetPos = gameObject.transform.position;
    }

}
