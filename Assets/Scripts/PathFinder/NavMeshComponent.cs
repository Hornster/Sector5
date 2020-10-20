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
    [SerializeField]
    public NavMeshPathStatus PathStatus { get { return navMeshAgent.pathStatus; } }

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    public void SetDestination(Vector3 vector3)
    {
        targetPos = vector3;
        navMeshAgent.SetDestination(vector3);
    }

    public void SetDestination(GameObject gameObject)
    {
        targetPos = gameObject.transform.position;
    }

}
