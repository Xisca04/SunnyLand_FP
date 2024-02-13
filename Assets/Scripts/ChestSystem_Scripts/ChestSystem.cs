using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestSystem : MonoBehaviour
{
    // Chest system -> collision --> animación --> panel --> scene

    private Animator _anim;

    [SerializeField] private GameObject panelAdvise;
    private void Start()
    {
        _anim = GetComponent<Animator>();
        HidePanel();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Chest found");
           _anim.SetBool("IsOpened", true);
            // sistema partículas 
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
        yield return new WaitForSeconds(3);
        HidePanel();
        _anim.SetBool("IsOpened", false);
    }

    public void HidePanel()
    {
        panelAdvise.SetActive(false);
    }
}
