using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PU_CorrectPath : MonoBehaviour
{
    // Power Up that shows the direction to the right chest

    // Variable to show the correct path
    [SerializeField] private GameObject correctDirection;

    // Sound
    [SerializeField] private AudioClip powerUpSound;
    private AudioSource _audiosource;

    private void Start()
    {
        _audiosource = GetComponent<AudioSource>();
        correctDirection.SetActive(false);
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player")) // Shows the path to the correct chest
        {
            correctDirection.SetActive(true);
            StartCoroutine("VFXOn");
        }
    }

    private IEnumerator VFXOn() // Deactivate the sprite nad destroy the collider
    {
        GetComponent<SpriteRenderer>().enabled = false; 
        Destroy(gameObject.GetComponent<BoxCollider2D>()); 
        gameObject.transform.GetChild(0).gameObject.SetActive(true); // Access to the first children (VFX)
        _audiosource.PlayOneShot(powerUpSound);
        yield return new WaitForSeconds(0.5f);
        Destroy(this.gameObject); // Destroy both 
    }
}
