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
    private void Start()
    {
        _anim = GetComponent<Animator>();
    }

    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Chest found");
            _anim.SetBool("IsOpened", true);
        }
    }
}
