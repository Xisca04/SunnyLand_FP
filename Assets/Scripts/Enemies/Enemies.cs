using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemies : MonoBehaviour
{
    // Enemies controller damage

    [SerializeField] private Transform[] waypoints;
    [SerializeField] private float speed;
    [SerializeField] private LayerMask groundLayerMask;

    private BoxCollider2D boxCollider2D;
    private int indexWaypointActual = 0;
    private int nextWaypoint = 1;
    private bool waypointsOrder = true;

    private void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        // Inicializar la posición del enemigo al primer waypoint
        transform.position = waypoints[indexWaypointActual].position;
    }

    private void Update()
    {
        EnemyMovement();
        //TakeDamage();
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


    // RAYCAST --> detección colisión player solo si le salta por encima
    /*
    private void TakeDamage() // Raycast to detect if the player killed it
    {
        float extraHeightTest = 0.05f;
        RaycastHit2D raycastHit2D = Physics2D.Raycast(boxCollider2D.bounds.center, Vector2.up, boxCollider2D.bounds.extents.y + extraHeightTest, groundLayerMask);

        bool isTookDamage = raycastHit2D.collider != null;

        if (isTookDamage)
        {
            Debug.Log($"death enemigo");
        }
        else
        {
            Debug.Log($"Damage al player");
        }
        

       
    }
    */

}
