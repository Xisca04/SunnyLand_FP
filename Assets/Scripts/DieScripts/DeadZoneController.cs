using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZoneController : MonoBehaviour
{
    // If the Player collision with the dead zone (gaps between platforms) -> Game Over

    // Reference
    [SerializeField] private GameOver _gameOver; 

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // GAME OVER
            _gameOver.GameOverLevels();
        }

    }
}
