using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathController : MonoBehaviour
{
    // Controlls the collision between Player and Enemy

    // To get the component
     public PlayerController _playerController;
     public GameOver _gameOver;

    private void Start()
    {
        _playerController.GetComponent<PlayerController>();
        _gameOver.GetComponent<GameOver>();
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.CompareTag("Enemy_Easy") || collision.gameObject.CompareTag("Enemy_Medium") || collision.gameObject.CompareTag("Enemy_Hard"))
        {
            // Gets the direction's contact
            ContactPoint2D contact = collision.contacts[0];
            Vector2 normal = contact.normal;

            // If the player collision the enemy from the Up's direction
            // Calculates the scale product between the Up vetor and the nomral one 
            // If the result is more than 0.5 -> is considered that the player is falling over the enemy
            if (Vector2.Dot(Vector2.up, normal) > 0.5f)
            {
                _playerController.BounceJump(); // The player makes the rebounce
                collision.gameObject.GetComponent<DeathEnemiesController>().TakeDamage(); // Kill the enemy

                // Add the score acording to the enemy's tag
                if (collision.gameObject.CompareTag("Enemy_Easy"))
                {
                    collision.gameObject.GetComponent<Score>().AddScore(Score.ENEMY_EASY_SCORE);
                }
                else if (collision.gameObject.CompareTag("Enemy_Medium"))
                {
                    collision.gameObject.GetComponent<Score>().AddScore(Score.ENEMY_MEDIUM_SCORE);
                }
                else if (collision.gameObject.CompareTag("Enemy_Hard"))
                {
                    collision.gameObject.GetComponent<Score>().AddScore(Score.ENEMY_HARD_SCORE);
                }
            }
            else // If the player collisions with the enemy from the sides or below
            {
                // Game Over
                _gameOver.GameOverLevels();
            }
        }
    }

}
