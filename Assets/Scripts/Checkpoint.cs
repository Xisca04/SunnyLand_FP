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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log($"Has pasado por el checkpoint");
            activatedCheckpoint = true;
            _gameManager.Save();
        }
    }

    /*
    private bool CheckpointActivated()
    {
        if (activatedCheckpoint == true)
        {
            return true;
        }

        return false;
    }
    */
}
