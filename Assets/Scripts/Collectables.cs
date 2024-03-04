using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    // Collectables' system

    // Sound
    [SerializeField] private AudioClip[] collectableSounds;
    private AudioSource _audioSource;

    // Coroutine's variable
    private float timeLeftCoroutine = 0.3f;

    private void Start()
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(false); // Nos aseguramos de que este desactivado desde el principio
        _audioSource = GetComponent<AudioSource>();
    }

    // If the player collision with the Gem or the Cherry
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine("VFXOn"); // VFX Activates

            if (gameObject.CompareTag("Gem"))
            {
                // Activates the Gem's sound and add the respective score (from Score)
                _audioSource.PlayOneShot(collectableSounds[0]);
                collision.gameObject.GetComponent<Score>().AddScore(Score.GEM_SCORE);
            }
            else if (gameObject.CompareTag("Cherry"))
            {
                // Activates the Cherry's sound and add the respective score (from Score)
                _audioSource.PlayOneShot(collectableSounds[1]);
                collision.gameObject.GetComponent<Score>().AddScore(Score.CHERRY_SCORE);
            }
        }
    }

    private IEnumerator VFXOn() // Deactivate sprite -> Destroy the collider, so the player doesn't collision it
    {
        GetComponent<SpriteRenderer>().enabled = false;
        Destroy(gameObject.GetComponent<BoxCollider2D>()); 
        gameObject.transform.GetChild(0).gameObject.SetActive(true); // Access to the first children 
        yield return new WaitForSeconds(timeLeftCoroutine);
        Destroy(gameObject); // Destroy both
    }
}
