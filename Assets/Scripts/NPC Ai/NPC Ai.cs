using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAi : MonoBehaviour
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
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, speed * Time.deltaTime);
        
        if (Vector3.Distance(transform.position, movePoint.position) <= 0)
        {
            if (pointIndex > MaxNum)
            {
                pointIndex = 0;
            }

            pointIndex++;
            movePoint = points[pointIndex];
            transform.LookAt(movePoint = points[pointIndex]);
        }

    }
}
