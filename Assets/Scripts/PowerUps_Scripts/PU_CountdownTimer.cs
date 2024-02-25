using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PU_CountdownTimer : MonoBehaviour
{
    [SerializeField] private AudioClip powerUpSound;
    private AudioSource _audiosource;

    private void Start()
    {
        _audiosource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        StartCoroutine("Destroy");
    }

    private IEnumerator Destroy()
    {
        yield return new WaitForSeconds(3.0f);
        _audiosource.PlayOneShot(powerUpSound);
        Destroy(this.gameObject);
    }
}
