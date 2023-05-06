using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointFollower : MonoBehaviour
{
    // waypoints which we move from to 
    [SerializeField] GameObject[] waypoints;

    // index of wanted way point
    int currWayPointIndex = 0;


    // speed of movement
    [SerializeField] float speed = 1f;


    void Update()
    {
        // loop in all way points
        if (Vector3.Distance(transform.position, waypoints[currWayPointIndex].transform.position) < .1f)
        {
            currWayPointIndex++;
            if (currWayPointIndex >= waypoints.Length)
            {
                currWayPointIndex = 0;
            }
        }
        // transform of any this script added to (From Pos, To pos, speed, 
        transform.position = Vector3.MoveTowards(transform.position, waypoints[currWayPointIndex].transform.position, speed * Time.deltaTime);
    }
}
