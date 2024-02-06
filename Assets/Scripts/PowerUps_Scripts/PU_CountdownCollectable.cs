using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PU_CountdownCollectable : MonoBehaviour
{
    [SerializeField] private GameObject gems;
    
    private void Start()
    {
        gems.SetActive(false);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gems.SetActive(true);
            Destroy(this.gameObject);
        }
    }
}
