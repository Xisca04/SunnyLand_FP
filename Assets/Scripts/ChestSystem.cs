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
    private void Start()
    {
        _anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            _anim.SetBool("IsOpened", true);
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            _anim.SetBool("IsOpened", false);
        }
    }
    /*
    private void OnCollisionEnter(Collision otherCollider)
    {
        if (otherCollider.gameObject.CompareTag("Player"))
        {
            _anim.SetBool("IsOpened", true);
        }
        else
        {
            _anim.SetBool("IsOpened", false);
        }
    }*/
}
