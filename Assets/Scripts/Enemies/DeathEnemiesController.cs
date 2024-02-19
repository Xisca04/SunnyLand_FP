using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathEnemiesController : MonoBehaviour
{
    [SerializeField] private PlayerController _playerController;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Verifica si el jugador está saltando
             _playerController = other.gameObject.GetComponent<PlayerController>();
            
            if (_playerController.isJumping == true)
            {
                // El jugador está saltando, por lo que eliminamos al enemigo
                Destroy(gameObject);
            }
        }

    }
}
