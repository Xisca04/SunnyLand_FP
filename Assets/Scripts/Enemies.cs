using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    // Enemies controller damage

    // Score enemies
    private const int EAGLE_SCORE = 150;
    private const int BAT_SCORE = 100;
    private const int VULTURE_SCORE = 100;
    private const int OPOSSUM_SCORE = 70;
    private const int PIG_SCORE = 70;
    private const int FROG_SCORE = 50;

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

    private void OnCollisionEnter(Collision otherCollider)
    {
        if (otherCollider.gameObject.CompareTag("Player"))
        {
            // Daño al player --> GAME OVER
        }
    }
}
