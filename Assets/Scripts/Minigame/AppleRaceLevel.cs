using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleRaceLevel : MonoBehaviour
{
    private AudioSource _audioSource;
    [SerializeField] private AudioClip appleSound;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
    }

    public void DestroyApple()
    {
        StartCoroutine("VFXOn");
    }

    private IEnumerator VFXOn()
    {
        GetComponent<SpriteRenderer>().enabled = false; // Asi se puede ver el efecto visual
        Destroy(gameObject.GetComponent<BoxCollider2D>()); // Destruye el collider para que el player no colisione con este hasta que se detrya todo el objeto
        _audioSource.PlayOneShot(appleSound);
        gameObject.transform.GetChild(0).gameObject.SetActive(true); // Accede al hijo del objeto uq es el que tiene el efecto visual
        yield return new WaitForSeconds(0.3f);
        Destroy(gameObject); // Destruye ambos 
    }
}
