using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructiblePlatform : MonoBehaviour
{
    // Destructible platform when the player collisions it

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine("DestroyPlatform");
        }
    }

    private IEnumerator DestroyPlatform()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
