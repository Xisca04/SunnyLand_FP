using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathEnemiesController : MonoBehaviour
{
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            foreach (ContactPoint2D contactPoint in other.contacts)
            {
                if (contactPoint.normal.y <= 0.9)
                {
                    other.gameObject.GetComponent<PlayerController>().ReboteJump();
                    Debug.Log($"muerte enemigo");
                    Destroy(gameObject);
                }
            }
        }

    }
}
