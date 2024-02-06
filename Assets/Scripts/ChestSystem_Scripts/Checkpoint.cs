using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    // Checkpoint --> detecta player --> detecta que ha pasado por el checkpoint

    [SerializeField] private GameManager _gameManager;

    public bool activatedCheckpoint = false;

    private void Start()
    {
        activatedCheckpoint = false;
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Checkpoint"))
        {
            Debug.Log($"checkpoint");
            activatedCheckpoint = true;
            _gameManager.Save();
        }
    }

}
