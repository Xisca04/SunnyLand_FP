using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlatform : MonoBehaviour
{
    // Movement of the movement's platforms

    // Move
    [SerializeField] private Transform[] movementPoints;
    [SerializeField] private float moveSpeed;
    private int nextPoint = 1;
    private bool pointsOrder = true;

    private void Update()
    {
        Movement();
    }

    // Platforms move to the points of the array in order
    private void Movement()
    {
        if (pointsOrder && nextPoint + 1 >= movementPoints.Length)
        {
            pointsOrder = false;
        }

        if (!pointsOrder && nextPoint <= 0)
        {
            pointsOrder = true;
        }

        if (Vector2.Distance(transform.position, movementPoints[nextPoint].position) < 0.1f)
        {
            if (pointsOrder)
            {
                nextPoint += 1;
            }
            else
            {
                nextPoint -= 1;
            }
        }

        transform.position = Vector2.MoveTowards(transform.position, movementPoints[nextPoint].position,
         moveSpeed * Time.deltaTime);
    }

    // If the Player collisions with the platform --> the platform takes the player with it
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.SetParent(this.transform);
        }
    }

    // When the player exits the collision --> the platfrom deactivate the set parent for the player
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.SetParent(null);
        }
    }
}
