using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PU_CorrectPath : MonoBehaviour
{
    // Power Up that shows the path to the right chest

    // Colllision con el player --> mostrar un objeto

    [SerializeField] private GameObject correctPath;

    private void Start()
    {
        correctPath.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            correctPath.SetActive(true);
            Destroy(this.gameObject);
        }
    }
}
