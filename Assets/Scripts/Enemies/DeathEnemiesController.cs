using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathEnemiesController : MonoBehaviour
{
    [SerializeField] private AudioClip enemyDeath;
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        gameObject.transform.GetChild(0).gameObject.SetActive(false); // desactiva el hijo
    }

    public void TakeDamage()
    {
        StartCoroutine("VFXDeath");
    }

    private IEnumerator VFXDeath()
    {
        GetComponent<SpriteRenderer>().enabled = false; // Asi se puede ver el efecto visual
        gameObject.transform.GetChild(0).gameObject.SetActive(true); // Accede al hijo del objeto uq es el que tiene el efecto visual
        _audioSource.PlayOneShot(enemyDeath);
        yield return new WaitForSeconds(0.5f);
        Destroy(this.gameObject); // Destruye ambos 

        // a�adir el score de cada enemigo
    }
}
