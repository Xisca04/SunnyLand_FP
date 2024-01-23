using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemies : MonoBehaviour
{
    // Enemies controller damage

    // References
    private NavMeshAgent _agent;

    [SerializeField] private LayerMask playerLayer;

    // PATRULLA - Variables
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private int nextPoint;
    private int totalWaypoints;
    
    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        totalWaypoints = waypoints.Length;
        nextPoint = 1;
    }

    private void Update()
    {
        Patrol();
    }

    private void OnCollisionEnter(Collision otherCollider)
    {
        if (otherCollider.gameObject.CompareTag("Player"))
        {
            // Daño al player --> GAME OVER
        }
    }

    private void Patrol()
    {
        if (Vector2.Distance(transform.position, waypoints[nextPoint].position) < 2.5f)
        {
            nextPoint++;

            if (nextPoint == totalWaypoints)
            {
                nextPoint = 0;

            }

            transform.LookAt(waypoints[nextPoint].position);
        }

        _agent.SetDestination(waypoints[nextPoint].position);
    }

    // RAYCAST --> detección colisión player solo si le salta por encima
    /*
    private bool IsOnTheGround() // impide el doble salto -- Raycast
    {
        float extraHeightTest = 0.05f;
        RaycastHit2D raycastHit2D = Physics2D.Raycast(boxCollider2D.bounds.center, Vector2.down, boxCollider2D.bounds.extents.y + extraHeightTest, groundLayerMask);

        bool isOnTheGround = raycastHit2D.collider != null;

        return isOnTheGround;
    }
    */
}
