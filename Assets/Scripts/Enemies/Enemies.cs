using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Enemies : MonoBehaviour
{
    // Enemies controller damage

    [SerializeField] private Transform[] waypoints;
    [SerializeField] private float speed;
    
    private int indexWaypointActual = 0;
    private int nextWaypoint = 1;
    private bool waypointsOrder = true;

    private void Start()
    {
        // Inicializar la posición del enemigo al primer waypoint
        transform.position = waypoints[indexWaypointActual].position;
    }

    private void Update()
    {
        EnemyMovement();
    }

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
        // Invertir la escala en el eje X para girar el sprite
        Vector2 nuevaEscala = transform.localScale;
        nuevaEscala.x *= -1; // la escala se mutiplica por -1 así el sprite da la vuelta
        transform.localScale = nuevaEscala;
    }
    
}
