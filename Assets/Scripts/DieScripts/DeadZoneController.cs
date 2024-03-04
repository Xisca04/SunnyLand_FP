using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZoneController : MonoBehaviour
{
    [SerializeField] private GameOver _gameOver; 


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _gameOver.GameOverLevels();
        }

    }
}
