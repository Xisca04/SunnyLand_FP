using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalChest : MonoBehaviour
{
    // Chest system -> collision --> animaci�n --> scene --> panel explicativo

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
            // A�adir sitema part�culas al abrir el cofre
            StartCoroutine("SendPlayer");
        }

    }

    private IEnumerator SendPlayer()
    {
        yield return new WaitForSeconds(0.3f);
        SceneManager.LoadScene("C_Final_Level");
    }
}
