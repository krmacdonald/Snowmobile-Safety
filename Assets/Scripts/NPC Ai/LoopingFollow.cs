using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class LoopingFollow : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints;
    //[SerializeField] int X, Y, Z;
    private int currentWaypointIndex = 0;

    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        SetDestination();
    }

    void Update()
    {
        if (agent.remainingDistance < 0.1f && !agent.pathPending)
        {
            SetDestination();
        }
    }

    void SetDestination()
    {
        if (waypoints.Length == 0)
            return;

        agent.SetDestination(waypoints[currentWaypointIndex].position);
        currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        transform.LookAt(waypoints[currentWaypointIndex].position);
        //transform.Rotate(X, Y, Z);
    }
}
