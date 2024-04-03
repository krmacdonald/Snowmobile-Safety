using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingFollowPath : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private int MaxNum;
    int pointIndex;
    Transform movePoint;
    [SerializeField] Transform[] points;

    // Start is called before the first frame update
    void Start()
    {
        pointIndex = 0;
        movePoint = points[pointIndex];
    }

    // Update is called once per frame
    void Update()
    {
        //moves the AI towards the next waypoint
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, speed * Time.deltaTime);
        
        //if to far from waypoint then will find the next closest
        if (Vector3.Distance(transform.position, movePoint.position) <= 0)
        {
            if (pointIndex > MaxNum)
            {
                pointIndex = 0;
            }

            pointIndex++;
            movePoint = points[pointIndex];
            transform.LookAt(movePoint = points[pointIndex]); //looks in the direction of the next waypoint
        }

    }
}
