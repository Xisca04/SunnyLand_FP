using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Enemies : MonoBehaviour
{
    // Enemies movement

    // Movement
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private float speed;
    private int indexWaypointActual = 0;
    private int nextWaypoint = 1;
    private bool waypointsOrder = true;

    private void Start()
    {
        // Initialize the enemy in the first waypoint
        transform.position = waypoints[indexWaypointActual].position;
    }

    private void Update()
    {
        EnemyMovement();
    }

    // Enemy move to the next waypint in order and turn around
    private void EnemyMovement()
    {
        if (waypointsOrder && nextWaypoint + 1 >= waypoints.Length)
        {
            waypointsOrder = false;
        }

        if (!waypointsOrder && nextWaypoint <= 0)
        {
            waypointsOrder = true;
        }

        if (Vector2.Distance(transform.position, waypoints[nextWaypoint].position) < 0.1f)
        {
            if (waypointsOrder)
            {
                nextWaypoint += 1;
                TurnAroundSprite();
            }
            else
            {
                nextWaypoint -= 1;
                TurnAroundSprite();
            }
        }

        transform.position = Vector2.MoveTowards(transform.position, waypoints[nextWaypoint].position, speed * Time.deltaTime);
    }


    void TurnAroundSprite()
    {
        // Invest the X scale to turn around the sprite
        Vector2 newScale = transform.localScale;
        newScale.x *= -1; // The scale multiplies to -1 = sprite turn around
        transform.localScale = newScale;
    }
    
}
