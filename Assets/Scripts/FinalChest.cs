using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalChest : MonoBehaviour
{
    // Chest system -> collision --> animación --> scene --> panel explicativo

    private Animator _anim;

    private void Start()
    {
        _anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Chest found");
            _anim.SetBool("IsOpened", true);
            // Añadir sitema partículas al abrir el cofre
            SceneManager.LoadScene("C_Final_Level");
        }

    }
}
