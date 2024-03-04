using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleRaceLevel : MonoBehaviour
{
    // Apples VFX On when the Player collissions them

    // Sound
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
    // At this form the VFX is able to see it
    private IEnumerator VFXOn()
    {
        GetComponent<SpriteRenderer>().enabled = false; // Deactivate the sprite of the apple
        Destroy(gameObject.GetComponent<BoxCollider2D>()); // Destroy collider -> player don't collision it 
        _audioSource.PlayOneShot(appleSound); // Activate the audioclip
        gameObject.transform.GetChild(0).gameObject.SetActive(true); // Access to the first children to see the VFX 
        yield return new WaitForSeconds(0.3f);
        Destroy(gameObject); // Destroy both
    }
}
