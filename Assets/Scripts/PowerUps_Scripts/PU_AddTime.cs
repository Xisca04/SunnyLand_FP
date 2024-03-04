using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PU_AddTime : MonoBehaviour
{
    // PowerUp to add time to the Countdown timer

    // Audio
    [SerializeField] private AudioClip powerUpSound;
    private AudioSource _audiosource;

    // Coroutine's variable
    private float timeLeftCoroutine = 0.3f;

    private void Start()
    {
        _audiosource = GetComponent<AudioSource>();
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player")) // Add time to the timer + VFX on
        {
            CountdownTimer.Instance.timeLeft += CountdownTimer.Instance.timeToAdd;
            StartCoroutine("VFXOn");
        }
    }

    private IEnumerator VFXOn() // Deactivate the sprite -> Destroy the collider --> we can see the VFX
    {
        GetComponent<SpriteRenderer>().enabled = false; 
        Destroy(gameObject.GetComponent<BoxCollider2D>()); 
        gameObject.transform.GetChild(0).gameObject.SetActive(true); // Acces to the first children 
        _audiosource.PlayOneShot(powerUpSound);
        yield return new WaitForSeconds(timeLeftCoroutine);
        Destroy(this.gameObject); // Destroy both
    }
}
