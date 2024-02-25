using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructiblePlatform : MonoBehaviour
{
    // Destructible platform when the player collisions it
    [SerializeField] private AudioClip destroyPlatform;
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        gameObject.transform.GetChild(0).gameObject.SetActive(false); // Nos aseguramos de que este desactivado desde el principio
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine("DestroyPlatform");
        }
    }

    private IEnumerator DestroyPlatform() // toca player --> se oculta quitando el collider --> vfx --> se detruyen ambos
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject.GetComponent<BoxCollider2D>()); // Destruye el collider para que el player no colisione con este hasta que se detrya todo el objeto
        GetComponent<SpriteRenderer>().enabled = false; // Asi se puede ver el efecto visual
        gameObject.transform.GetChild(0).gameObject.SetActive(true); // Accede al hijo del objeto uq es el que tiene el efecto visual
        _audioSource.PlayOneShot(destroyPlatform);
        yield return new WaitForSeconds(0.2f);
        Destroy(gameObject); // Destruye ambos 
    }
}
