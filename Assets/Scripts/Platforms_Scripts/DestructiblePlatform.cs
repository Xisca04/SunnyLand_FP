using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructiblePlatform : MonoBehaviour
{
    // Destructible platform when the player collisions it

    // Sound
    [SerializeField] private AudioClip destroyPlatform;
    private AudioSource _audioSource;

    // Coroutine's variables
    private float timeLeft1 = 0.5f;
    private float timeLeft2 = 0.2f;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        gameObject.transform.GetChild(0).gameObject.SetActive(false); 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine("DestroyPlatform");
        }
    }

    private IEnumerator DestroyPlatform() // Destroy the collider + Deactivate sprite
    {
        yield return new WaitForSeconds(timeLeft1);
        Destroy(gameObject.GetComponent<BoxCollider2D>());
        GetComponent<SpriteRenderer>().enabled = false; 
        gameObject.transform.GetChild(0).gameObject.SetActive(true); // Access to the first children
        _audioSource.PlayOneShot(destroyPlatform);
        yield return new WaitForSeconds(timeLeft2);
        Destroy(gameObject); // Destroy both 
    }
}
