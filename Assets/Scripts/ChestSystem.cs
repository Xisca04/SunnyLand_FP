using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestSystem : MonoBehaviour
{
    // Chest system -> collision --> animaci�n --> panel --> scene

    // escenas
    // panel abrir o no cofre
    // animaci�n apertura y cierre
    // env�o a las escenas
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
            // A�adir sitema part�culas al abrir el cofre
            StartCoroutine("PanelActive");
        }
    }

    private IEnumerator PanelActive()
    {
        yield return new WaitForSeconds(1);
        panelAdvise.SetActive(true);
    }
}
