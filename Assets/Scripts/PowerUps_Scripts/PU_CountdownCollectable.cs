using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PU_CountdownCollectable : MonoBehaviour
{
    // Power up taht shows gems and after a while it disappear

    // Game object to show with collectables
    [SerializeField] private GameObject gems;

    // Sound
    [SerializeField] private AudioClip powerUpSound;
    private AudioSource _audiosource;

    private void Start()
    {
        _audiosource = GetComponent<AudioSource>();
        gems.SetActive(false);
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) // Shows the gems and destroy the power up
        {
            gems.SetActive(true);
            StartCoroutine("VFXOn");
        }
    }

    private IEnumerator VFXOn() // Deactivate the sprite + Destroy the collider -> we can see the VFX
    {
        GetComponent<SpriteRenderer>().enabled = false; 
        Destroy(gameObject.GetComponent<BoxCollider2D>()); 
        gameObject.transform.GetChild(0).gameObject.SetActive(true); // Access to the first child (VFX)
        _audiosource.PlayOneShot(powerUpSound);
        yield return new WaitForSeconds(0.5f);
        Destroy(this.gameObject); // Destroy both
    }
}
