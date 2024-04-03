using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    public Transform[] waypoints;   // Array of waypoints
    public float speed = 1f;        // Speed of movement

    private int currentWaypointIndex = 0;

    void Update()
    {
        if (currentWaypointIndex < waypoints.Length)
        {
            // Move towards the current waypoint
            transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypointIndex].position, speed * Time.deltaTime);

            // Rotate to look at the current waypoint
            transform.LookAt(waypoints[currentWaypointIndex].position);

            // If the object reaches the current waypoint, move to the next one
            if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex].position) < 0.01f)
            {
                currentWaypointIndex++;
            }
        }
        else
        {
            // Optionally, perform any actions when the object reaches the final waypoint
            Debug.Log("Movement completed!");
        }
    }
}
