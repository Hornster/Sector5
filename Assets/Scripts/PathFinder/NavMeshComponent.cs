using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class NavMeshComponent : MonoBehaviour
{
    NavMeshAgent navMeshAgent;
    [SerializeField]
    GameObject target;
    Vector3 targetPos;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        SetDestination(target.transform.position);
    }

    public void SetDestination(Vector3 vector3)
    {
        targetPos = vector3;
    }

    public void SetDestination(GameObject gameObject)
    {
        targetPos = gameObject.transform.position;
    }

    public void Move()
    {
        //navMeshAgent.SetDestination(vector3);
        NavMeshPath navMeshPath = new NavMeshPath();
        navMeshAgent.CalculatePath(targetPos, navMeshPath);

        if (navMeshPath.status.Equals(NavMeshPathStatus.PathComplete))
        {
            navMeshAgent.isStopped = false;
            navMeshAgent.SetPath(navMeshPath);
        }
        else
        {
            navMeshAgent.isStopped = true;
        }

    }
    // Update is called once per frame
    void Update()
    {
        Move();
    }
}
