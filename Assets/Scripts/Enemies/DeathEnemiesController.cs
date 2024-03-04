using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathEnemiesController : MonoBehaviour
{
    // Enemy's systemm when it dies

    // Sound
    [SerializeField] private AudioClip enemyDeath;
    private AudioSource _audioSource; // To get the component

    // Coroutine's variable
    private float timeLeftCoroutine = 0.25f;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        gameObject.transform.GetChild(0).gameObject.SetActive(false); // Deactivate the first children (VFX effect)
    }

    public void TakeDamage()
    {
        StartCoroutine("VFXDeath");
    }

    // Coroutine to see the VFX of the enemy
    private IEnumerator VFXDeath()
    {
        GetComponent<SpriteRenderer>().enabled = false; // Deactivate the sprite of the enemy
        Destroy(gameObject.GetComponent<BoxCollider2D>()); // Deactivate the sprite of the enemy -> at this fomr the player doesn't collide with it
        gameObject.transform.GetChild(0).gameObject.SetActive(true); // Access to the first children 
        _audioSource.PlayOneShot(enemyDeath); // Activates the audioclip
        yield return new WaitForSeconds(timeLeftCoroutine);
        Destroy(gameObject); // Destroy both 
    }
}
