using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestSystem : MonoBehaviour
{
    // Chest system -> collision --> animación --> panel --> scene

    private Animator _anim;

    [SerializeField] private GameObject panelAdvise;
    [SerializeField] private ParticleSystem _particles;
    private void Start()
    {
        _anim = GetComponent<Animator>();
        HidePanel();
        _particles.Stop();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Chest found");
            _anim.SetBool("IsOpened", true);
            _particles.Play();
            StartCoroutine("PanelActive");
        }
        
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Chest closed");
            StartCoroutine("ChestClosed");
        }

    }

    private IEnumerator PanelActive()
    {
        yield return new WaitForSeconds(1);
        panelAdvise.SetActive(true);
    }

    private IEnumerator ChestClosed()
    {
        yield return new WaitForSeconds(1.5f);
        HidePanel();
        _particles.Stop();
        _anim.SetBool("IsOpened", false);
    }

    public void HidePanel()
    {
        panelAdvise.SetActive(false);
    }
}
