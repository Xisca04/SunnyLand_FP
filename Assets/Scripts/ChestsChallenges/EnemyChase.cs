using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyChase : MonoBehaviour
{
    [SerializeField] private Transform player;

    private NavMeshAgent _agent;

    private float visionRange = 5.0f;
    private bool playerInVisionRange;
    
    [SerializeField] private LayerMask playerLayer;

    [SerializeField] private Transform[] waypoints; 
    private int totalWaypoints;
    private int nextPoint;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        totalWaypoints = waypoints.Length;
        nextPoint = 1;
    }

    private void Update() // Se movera hacia el destino
    {
        Vector3 pos = transform.position;
        playerInVisionRange = Physics.CheckSphere(pos, visionRange, playerLayer);

        if (!playerInVisionRange)
        {
            Patrol();
        }

        if (playerInVisionRange)
        {
            Chase();
        }
    }

    private void Patrol()
    {
        if (Vector3.Distance(transform.position, waypoints[nextPoint].position) < 2.5f)
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

    private void Chase()
    {
        _agent.SetDestination(player.position);
        transform.LookAt(player);
    }

    private void OnDrawGizmos()
    {
        // Esfera de visión
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, visionRange);
    }
}
