using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeathEnemiesCounter : MonoBehaviour
{
    // Cave challenge --> counts every time the Player kills an enemy
    
    // Reference
    [SerializeField] private PlayerController _playerController;

    // Counter's variables
    [SerializeField] private int enemyDeaths; // Number of enemies killed
    [SerializeField] private GameObject enemies; // Game object that contents all of the enemies in the scene

    // Coroutine's variable
    private float timeLeftCroutine = 1.5f;

    // UI
    [SerializeField] private TextMeshProUGUI enemyDeathsText;
    [SerializeField] private GameObject winPanel;

    // Particles
    [SerializeField] private ParticleSystem _fireEmbersParticles;

    
    private void Start()
    {
        enemyDeaths = 0;
        winPanel.SetActive(false);
        _fireEmbersParticles.Play();
    }

    private void Update()
    {
        CheckWinner();
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.CompareTag("Enemy")) // Detect if the game object has the Enemy tag
        {
            // Get the direction of the contact
            ContactPoint2D contact = collision.contacts[0];
            Vector2 normal = contact.normal;

            if (Vector2.Dot(Vector2.up, normal) > 0.5f) // If the direction's contact is up
            {
                _playerController.BounceJump(); // The player makes the rebounce
                collision.gameObject.GetComponent<DeathEnemiesController>().TakeDamage(); // Kill the enemy
                EnemyKilled(); // Update the counter
            }
            else // If the player collisions with the enemy from the sides or below --> GameOver 
            {
                gameObject.GetComponent<GameOver>().gameOverPanel.SetActive(true);
                _playerController.Die();
                StartCoroutine("LoseLevel");
            }
        }
    }

    // Updates the counter internally and visually
    private void EnemyKilled()
    {
        enemyDeaths++;
        enemyDeathsText.text = enemyDeaths.ToString();
    }

    // Checks if the player has won --> if the player have killed 10 enemies or more
    private void CheckWinner()
    {
        if (enemyDeaths >= 10)
        {
            winPanel.SetActive(true);
            Destroy(enemies); // Destroy all enemies from the scene -> avoids the problem of the player touching an enemy again and triggering the Game Over
            StartCoroutine("WinLevel");
        }
    }

    // Coroutine that sends the Player to the Final Level
    private IEnumerator WinLevel()
    {
        _playerController.enabled = false; // At this form the player can't move
        yield return new WaitForSeconds(timeLeftCroutine);
        Loader.Load(Loader.Scene.Final_Level);
        _playerController.enabled = true;
    }

    // Coroutine that sends the Player to restart the Level 2
    private IEnumerator LoseLevel()
    {
        _playerController.enabled = false; // At this form the player can't move
        yield return new WaitForSeconds(timeLeftCroutine);
        Loader.Load(Loader.Scene.Level2);
        _playerController.enabled = true;
    }
}
