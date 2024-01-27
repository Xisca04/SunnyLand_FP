using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestSystem : MonoBehaviour
{
    // Chest system -> collision --> animación --> panel --> scene

    // escenas
    // panel abrir o no cofre
    // animación apertura y cierre
    // envío a las escenas
    private Animator _anim;

    [SerializeField] private GameObject panelAdvise;
    private void Start()
    {
        _anim = GetComponent<Animator>();
        panelAdvise.SetActive(false);
    }

    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Chest found");
           _anim.SetBool("IsOpened", true);
            // Añadir sitema partículas al abrir el cofre
            StartCoroutine("PanelActive");
        }
    }

    private IEnumerator PanelActive()
    {
        yield return new WaitForSeconds(1);
        panelAdvise.SetActive(true);
    }
}
