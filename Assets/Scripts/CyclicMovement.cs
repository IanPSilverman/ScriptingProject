using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CyclicMovement : MonoBehaviour
{
    public Transform[] waypoints;
    public float speed = 3f;

    private int _currentWaypointIndex = 0;

    private void Update()
    {
        if(waypoints.Length > 0)
        {
            Vector2 targetPosition = waypoints[_currentWaypointIndex].position;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

            if(Vector2.Distance(transform.position, targetPosition) < 0.1f)
            {
                _currentWaypointIndex = (_currentWaypointIndex + 1) % waypoints.Length;
            }
        }
    }
}
