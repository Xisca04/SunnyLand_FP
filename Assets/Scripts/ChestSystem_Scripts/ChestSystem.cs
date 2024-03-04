using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestSystem : MonoBehaviour
{
    // Chest system -> collision --> animation --> advise panel 

    // To get the component
    private Animator _anim;

    // Coroutine's variable
    private float timeLeftCoroutine = 1.5f;

    // UI
    [SerializeField] private GameObject panelAdvise;

    // Particles
    [SerializeField] private ParticleSystem _particles;

    private void Start()
    {
        _anim = GetComponent<Animator>();
        HidePanel();
        _particles.Stop();
    }

    private void OnCollisionEnter2D(Collision2D other) // If Player collisions with the chest
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _anim.SetBool("IsOpened", true);
            _particles.Play();
            StartCoroutine("PanelActive");
        }
        
    }

    private void OnCollisionExit2D(Collision2D other) // If the Player exits the collisions with the chest
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine("ChestClosed"); // After a while the chest closes
        }

    }

    private IEnumerator PanelActive()
    {

        yield return new WaitForSeconds(timeLeftCoroutine);
        panelAdvise.SetActive(true);
    }

    private IEnumerator ChestClosed()
    {
        yield return new WaitForSeconds(timeLeftCoroutine);
        HidePanel();
        _particles.Stop();
        _anim.SetBool("IsOpened", false);
    }

    // Function for the Button NO of the Advise Panel
    public void HidePanel()
    {
        panelAdvise.SetActive(false);
    }
}
