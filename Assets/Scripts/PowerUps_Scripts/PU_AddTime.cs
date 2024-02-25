using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PU_AddTime : MonoBehaviour
{
    [SerializeField] private AudioClip powerUpSound;
    private AudioSource _audiosource;

    private void Start()
    {
        _audiosource = GetComponent<AudioSource>();
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            CountdownTimer.Instance.timeLeft += CountdownTimer.Instance.timeToAdd;
            StartCoroutine("VFXOn");
        }
    }

    private IEnumerator VFXOn()
    {
        GetComponent<SpriteRenderer>().enabled = false; // Asi se puede ver el efecto visual
        Destroy(gameObject.GetComponent<BoxCollider2D>()); // Destruye el collider para que el player no colisione con este hasta que se detrya todo el objeto
        gameObject.transform.GetChild(0).gameObject.SetActive(true); // Accede al hijo del objeto uq es el que tiene el efecto visual
        _audiosource.PlayOneShot(powerUpSound);
        yield return new WaitForSeconds(0.5f);
        Destroy(this.gameObject); // Destruye ambos 
    }
}
