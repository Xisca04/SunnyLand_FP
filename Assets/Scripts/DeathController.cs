using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathController : MonoBehaviour
{
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private GameOver _gameOver;

    private void Start()
    {
        _playerController.GetComponent<PlayerController>();
        _gameOver.GetComponent<GameOver>();
    }

    private void OnCollisionEnter2D(Collision2D collision) // detecta si es un enemigo a lo que toca por debajo de �l, pero si toca este que no sea desde arriba el enemigo mata al player
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Obtener la direcci�n del contacto
            ContactPoint2D contact = collision.contacts[0];
            Vector2 normal = contact.normal;

            // Si el jugador est� cayendo sobre el enemigo, destruye al enemigo
            /* Vector2.Dot(Vector.up, normal) > 0.5f
             *  est� calculando el producto escalar entre el vector "up" (que apunta hacia arriba) y 
             *  la normal de la colisi�n entre el jugador y el enemigo. 
             *  Esto se usa para determinar si el jugador est� colisionando con 
             *  el enemigo desde arriba o desde los lados. Si el resultado es mayor que 0.5, 
             *  se considera que el jugador est� cayendo sobre el enemigo, lo que indica que deber�a destruir al enemigo.
             * */
            if (Vector2.Dot(Vector2.up, normal) > 0.5f)
            {
                _playerController.ReboteJump();
                collision.gameObject.GetComponent<DeathEnemiesController>().TakeDamage();
                //Destroy(collision.gameObject); // Destruye ambos 
            }
            else // Si el jugador choca con el enemigo desde los lados o por debajo, recibe da�o
            {
                _gameOver.GameOverLevels();
            }
        }
    }
}
