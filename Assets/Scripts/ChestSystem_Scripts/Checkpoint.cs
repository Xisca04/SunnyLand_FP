using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    // Checkpoint --> detecta player --> detecta que ha pasado por el checkpoint

    [SerializeField] private GameManager _gameManager;

    public bool activatedCheckpoint;

    private void Start()
    {
        activatedCheckpoint = false;
    }
    /*
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Checkpoint"))
        {
            Debug.Log($"Has pasado por el checkpoint");
            activatedCheckpoint = true;
            _gameManager.Save();
        }
    }
    */
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Checkpoint"))
        {
            Debug.Log($"checkpoint collision");
        }
    }
}
